namespace Lab1.Entities;

public class SystemOfLimitations
{
    private readonly List<ILimitation> _limitations;
    private List<Equation>? _equations;

    public SystemOfLimitations(List<ILimitation> limitations)
    {
        if (limitations.Count == 0)
        {
            throw new ArgumentException("Empty limitations list.");
        }

        _limitations = limitations;
    }

    public IReadOnlyList<Equation>? Equations => _equations;
    public IReadOnlyList<ILimitation> Limitations => _limitations;

    public int[] Canonize()
    {
        var oldXCount = _limitations[0].Expression.Coefficients.Count;
        var newXCount = oldXCount + _limitations.Count(l => l is Inequality);

        var basis = new List<int>();
        if (_equations is not null)
        {
            for (var i = newXCount - 1; i >= oldXCount; i--)
            {
                basis.Add(i);
            }

            while (basis.Count < _limitations.Count)
            {
                basis.Add(-1);
            }

            return basis.ToArray();
        }

        var newXNumber = _limitations[0].Expression.Coefficients.Count;
        var equations = new List<Equation>();
        foreach (var limitation in _limitations)
        {
            switch (limitation)
            {
                case Equation equation:
                    equation.Expression.Resize(newXCount);
                    equations.Add(equation);
                    break;
                case Inequality inequality:
                    var eq = new Equation(inequality, newXNumber);
                    eq.Expression.Resize(newXCount);
                    equations.Add(eq);
                    newXNumber++;
                    break;
            }
        }

        _equations = equations;

        for (var i = newXCount - 1; i >= oldXCount; i--)
        {
            basis.Add(i);
        }

        while (basis.Count < _limitations.Count)
        {
            basis.Add(-1);
        }

        return basis.ToArray();
    }
}
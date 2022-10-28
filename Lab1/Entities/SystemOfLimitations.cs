namespace Lab1.Entities;

public class SystemOfLimitations
{
    private readonly List<Equation> _equations;

    public SystemOfLimitations(List<ILimitation> limitations)
    {
        if (limitations.Count == 0)
        {
            throw new ArgumentException("Empty limitations list.");
        }

        var equations = new List<Equation>();
        var newXNumber = limitations[0].Expression.Coefficients.Count;
        foreach (var limitation in limitations)
        {
            switch (limitation)
            {
                case Equation equation:
                    equations.Add(equation);
                    break;
                case Inequality inequality:
                    equations.Add(new Equation(inequality, newXNumber));
                    newXNumber++;
                    break;
            }
        }

        _equations = equations;
    }

    public IReadOnlyList<Equation> Equations => _equations;
}
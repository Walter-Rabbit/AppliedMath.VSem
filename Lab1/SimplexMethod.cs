using Lab1.Entities;

namespace Lab1;

public class SimplexMethod
{
    public SimplexMethodResult Maximize(Expression function, SystemOfLimitations systemOfLimitations,
        int[]? basis = null)
    {
        function *= -1;
        var maximizationResult = Maximize(function, systemOfLimitations, basis);

        return new SimplexMethodResult(maximizationResult.X, -maximizationResult.FunctionValue);
    }

    public SimplexMethodResult Minimize(Expression function, SystemOfLimitations systemOfLimitations,
        int[]? basis = null)
    {
        var table = BuildSimplexTable(function, systemOfLimitations, basis);

        while (table.Deltas.Any(x => x > 0.001))
        {
            var resolvingColumn = table.GetResolvingColumn();
            var resolvingRow = table.GetResolvingRow(resolvingColumn);

            table.SwapBasis(resolvingRow, resolvingColumn);
            table.CalculateDeltas();
        }

        var x = new double[function.Coefficients.Count];

        for (int i = 0; i < table.Basis.Count; i++)
        {
            var basisIndex = table.Basis.ElementAt(i);
            x[basisIndex] = table.FreeCoefficients.ElementAt(i);
        }

        return new SimplexMethodResult(x, table.FreeDelta);
    }

    public SimplexTable BuildSimplexTable(Expression function, SystemOfLimitations systemOfLimitations,
        int[]? basis = null)
    {
        var table = new Table(systemOfLimitations.Equations.Count,
            systemOfLimitations.Equations[0].Expression.Coefficients.Count);

        for (int i = 0; i < systemOfLimitations.Equations.Count; i++)
        {
            var equation = systemOfLimitations.Equations[i];
            table[i] = new Row(equation.Expression.Coefficients.ToArray());
        }

        var stable = new SimplexTable(table, systemOfLimitations.Equations.Select(x => x.FreeElement).ToArray(),
            function.Coefficients.ToArray(), basis);

        return stable;
    }
}
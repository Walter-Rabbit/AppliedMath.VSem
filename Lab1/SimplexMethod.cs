using System.Drawing;
using Lab1.Entities;

namespace Lab1;

public class SimplexMethod
{
    /// <summary>
    /// Максимизирует функцию с ограничениями, заданными системой уравнений.
    /// </summary>
    /// <param name="function">Целевая функция для максимизации.</param>
    /// <param name="systemOfEquations">Системак ограничений.</param>
    /// <param name="basis">Базис</param>
    /// <returns>Значения x, при которых функция максимальна.</returns>
    /// <exception cref="NotImplementedException"></exception>
    public SimplexMethodResult Maximize(Expression function, SystemOfEquations systemOfEquations, int[]? basis = null)
    {
        function *= -1;
        var maximizationResult = Maximize(function, systemOfEquations, basis);

        return new SimplexMethodResult(maximizationResult.X, -maximizationResult.FunctionValue);
    }

    /// <summary>
    /// Минимизирует функцию с ограничениями, заданными системой уравнений.
    /// </summary>
    /// <param name="function">Целевая функция для минимизации.</param>
    /// <param name="systemOfEquations">Система ограничений.</param>
    /// <param name="basis"></param>
    /// <returns>Значения x, при которых функция минимальна.</returns>
    /// <exception cref="NotImplementedException"></exception>
    public SimplexMethodResult Minimize(Expression function, SystemOfEquations systemOfEquations, int[]? basis = null)
    {
        var table = BuildSimplexTable(function, systemOfEquations, basis);

        while (table.Deltas.Any(x => x > 0))
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

    public SimplexTable BuildSimplexTable(Expression function, SystemOfEquations systemOfEquations, int[]? basis = null)
    {
        var table = new Table(systemOfEquations.Equations.Count, systemOfEquations.Equations[0].LeftExpression.Coefficients.Count);

        for (int i = 0; i < systemOfEquations.Equations.Count; i++)
        {
            var equation = systemOfEquations.Equations[i];
            table[i] = new Row(equation.LeftExpression.Coefficients.ToArray());
        }

        var stable = new SimplexTable(table, systemOfEquations.Equations.Select(x => x.FreeElement).ToArray(), function.Coefficients.ToArray() ,basis);

        return stable;
    }
}
using Lab3.EquationSystemSolvers.Tools;
using MathNet.Numerics.LinearAlgebra;

namespace Lab3.MarkovChainSolvers;

public class MarkovChainSolverInLimit
{
    public (Vector<double>, List<double>) Solve(
        Matrix<double> transitions,
        Vector<double> startCondition,
        double eps = 0.001,
        int maxIteration = 100)
    {
        MarkovChainChecker.ThrowIfIncorrect(transitions, eps);
        if (startCondition.Count != transitions.ColumnCount || startCondition.Sum() != 1) throw new ArgumentException("Incorrect start condition");

        var previousCondition = Vector<double>.Build.Random(startCondition.Count);
        var errors = new List<double>();

        for (var i = 0; i < maxIteration; i++)
        {
            var error = Error(startCondition, previousCondition);
            errors.Add(error);
            if (error < eps)
            {
                break;
            }

            previousCondition = startCondition;
            startCondition = IterationSolve(previousCondition, transitions);
        }

        return (startCondition, errors);
    }

    private Vector<double> IterationSolve(Vector<double> condition, Matrix<double> transition)
    {
        return condition * transition;
    }

    private double Error(Vector<double> v1, Vector<double> v2)
    {
        var sum = v1.Select((t, i) => Math.Pow(t - v2[i], 2)).Sum();
        return Math.Sqrt(sum / v1.Count);
    }
}
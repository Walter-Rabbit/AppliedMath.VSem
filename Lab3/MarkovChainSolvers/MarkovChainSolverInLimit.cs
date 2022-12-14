using MathNet.Numerics.LinearAlgebra;

namespace Lab3.MarkovChainSolvers;

public class MarkovChainSolverInLimit
{
    public Vector<double> Solve(Vector<double> startCondition, Matrix<double> transition, double eps)
    {
        var previousCondition = Vector<double>.Build.Random(startCondition.Count);
        while (Error(startCondition, previousCondition) > eps)
        {
            previousCondition = startCondition;
            startCondition = IterationSolve(previousCondition, transition);
        }

        return startCondition;
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
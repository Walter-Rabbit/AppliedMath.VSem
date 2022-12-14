using Lab3.EquationSystemSolvers;
using Lab3.EquationSystemSolvers.ValueObjects;
using MathNet.Numerics.LinearAlgebra;

namespace Lab3.MarkovChainSolvers;

public class MarkovChainSolverAnalytical
{
    private GaussianEquationSystemSolver _equationSystemSolver;

    public MarkovChainSolverAnalytical()
    {
        _equationSystemSolver = new GaussianEquationSystemSolver();
    }

    public Vector<double> Solve(Matrix<double> transition)
    {
        var vector = Vector<double>.Build.Dense(transition.RowCount, 0.0);
        vector[0] = 1.0;

        transition = transition.Transpose();
        for (var i = 0; i < transition.RowCount; i++)
        {
            transition[i, i] -= 1.0;
            transition[0, i] += 1.0;
        }

        var request = new EquationSystemSolverRequest(transition, vector);
        var response = _equationSystemSolver.Solve(request);

        return response.Solution;
    }
}
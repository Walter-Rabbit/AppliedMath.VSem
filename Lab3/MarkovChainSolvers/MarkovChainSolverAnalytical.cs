using Lab3.EquationSystemSolvers;
using Lab3.EquationSystemSolvers.ValueObjects;
using MathNet.Numerics.LinearAlgebra;

namespace Lab3.MarkovChainSolvers;

public class MarkovChainSolverAnalytical
{
    private readonly GaussianEquationSystemSolver _equationSystemSolver;

    public MarkovChainSolverAnalytical()
    {
        _equationSystemSolver = new GaussianEquationSystemSolver();
    }

    public Vector<double> Solve(Matrix<double> transitions)
    {
        MarkovChainChecker.ThrowIfIncorrect(transitions);

        var vector = Vector<double>.Build.Dense(transitions.RowCount, 0.0);
        vector[0] = 1.0;

        transitions = transitions.Transpose();
        for (var i = 0; i < transitions.RowCount; i++)
        {
            transitions[i, i] -= 1.0;
            transitions[0, i] += 1.0;
        }

        var request = new EquationSystemSolverRequest(transitions, vector);
        var response = _equationSystemSolver.Solve(request);

        return response.Solution;
    }
}
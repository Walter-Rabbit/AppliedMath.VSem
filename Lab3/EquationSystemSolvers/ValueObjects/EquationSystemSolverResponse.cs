using MathNet.Numerics.LinearAlgebra;

namespace Lab3.EquationSystemSolvers.ValueObjects;

public class EquationSystemSolverResponse
{
    public EquationSystemSolverResponse(Vector<double> solution)
    {
        Solution = solution;
    }

    public Vector<double> Solution { get; }
}
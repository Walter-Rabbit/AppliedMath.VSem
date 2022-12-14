using MathNet.Numerics.LinearAlgebra;

namespace Lab3.EquationSystemSolvers.ValueObjects;

public class EquationSystemSolverRequest
{
    public EquationSystemSolverRequest(Matrix<double> matrix, Vector<double> result)
    {
        Matrix = matrix;
        Result = result;
    }

    public Matrix<double> Matrix { get; }
    public Vector<double> Result { get; }
}
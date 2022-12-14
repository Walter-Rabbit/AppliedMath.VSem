using Lab3.EquationSystemSolvers.Tools;
using Lab3.EquationSystemSolvers.ValueObjects;
using MathNet.Numerics.LinearAlgebra;

namespace Lab3.EquationSystemSolvers;

public class GaussianEquationSystemSolver
{
    public EquationSystemSolverResponse Solve(EquationSystemSolverRequest request)
    {
        var (matrix, result) = (request.Matrix, request.Result);

        var n = result.Count;
        Matrix<double> extendedMatrix = MatrixPool<double>.Get(matrix.RowCount, matrix.ColumnCount + 1);
        extendedMatrix.SetSubMatrix(0, 0, matrix);
        extendedMatrix.SetColumn(matrix.ColumnCount, result);

        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (i == j)
                    continue;

                var multiplier = extendedMatrix[j, i] / extendedMatrix[i, i];

                for (var k = 0; k <= n; k++)
                {
                    extendedMatrix[j, k] -= multiplier * extendedMatrix[i, k];
                }
            }
        }

        Vector<double> solution = VectorPool<double>.Get(n);

        for (var i = 0; i < n; i++)
        {
            solution[i] = extendedMatrix[i, n] / extendedMatrix[i, i];
        }

        MatrixPool<double>.Return(extendedMatrix);
        return new EquationSystemSolverResponse(solution);
    }
}
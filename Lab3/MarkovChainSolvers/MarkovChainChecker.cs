using MathNet.Numerics.LinearAlgebra;

namespace Lab3.MarkovChainSolvers;

public static class MarkovChainChecker
{
    public static void ThrowIfIncorrect(Matrix<double> matrix, double eps = 0.001)
    {
        if (matrix.ColumnCount != matrix.RowCount)
        {
            throw new ArgumentException("Number of columns and rows must be equal");
        }

        for (var i = 0; i < matrix.ColumnCount; i++)
        {
            if (matrix.RowSums().Any(r => Math.Abs(r - 1) > eps))
            {
                throw new AggregateException("All condition vectors must return 1 as a sum of their elements");
            }
        }
    }
}
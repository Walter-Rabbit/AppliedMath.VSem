namespace Lab1.Entities;

public class SimplexTable
{
    private double[] _functionCoefficients;
    private readonly int[] _basis;
    private readonly double[] _freeCoefficients;
    private readonly Table _table;
    private readonly double[] _deltas;


    // TODO: fix?
    public IReadOnlyCollection<double> Deltas => _deltas;

    public double FreeDelta { get; private set; }

    public IReadOnlyCollection<int> Basis => _basis;

    public IReadOnlyCollection<double> FreeCoefficients => _freeCoefficients;

    public SimplexTable(Table table, double[] freeCoefficients, double[] functionCoefficients, int[]? basis = null)
    {
        _table = table;
        _freeCoefficients = freeCoefficients;
        _functionCoefficients = functionCoefficients;
        if (basis is null)
        {
            _basis = new int[table.Height];
            _basis.AsSpan().Fill(-1);
        }
        else
        {
            _basis = basis;
        }
        _deltas = new double[table.Width];
        _deltas.AsSpan().Fill(-1);
        EnsureBasisDefined();
        EnsureFreeCoefficientsPositive();
        CalculateDeltas();
    }

    private void EnsureBasisDefined()
    {
        for (int i = 0; i < _basis.Length; i++)
        {
            int nextBasisIndex = 0;
            if (_basis[i] != -1)
                continue;

            while (_table[i, nextBasisIndex] == 0 || _basis.Contains(nextBasisIndex))
                nextBasisIndex++;

            var basisIndex = nextBasisIndex++;
            SwapBasis(i, basisIndex);
        }
    }

    private void EnsureFreeCoefficientsPositive()
    {
        while (_freeCoefficients.Any(x => x < 0))
        {
            var oldBasisIndex = Array.IndexOf(_freeCoefficients, _freeCoefficients.Min());
            var newBasis = _table[oldBasisIndex].IndexOf(coefs => coefs.Min());
            
            SwapBasis(oldBasisIndex, newBasis);
        }
    }

    public void CalculateDeltas()
    {
        for (int i = 0; i < _deltas.Length; i++)
        {
            _deltas[i] = -_functionCoefficients[i];
            for (int j = 0; j < _table.Height; j++)
            {
                _deltas[i] += _table[j, i] * _functionCoefficients[_basis[j]];
            }
        }

        FreeDelta = 0;
        for (int i = 0; i < _table.Height; i++)
        {
            FreeDelta += _functionCoefficients[_basis[i]] * _freeCoefficients[i];
        }
    }

    public int GetResolvingColumn()
    {
        return Array.IndexOf(_deltas, _deltas.Max());
    }

    public int GetResolvingRow(int column)
    {
        var Q = new double[_table.Height];
        for (int i = 0; i < _table.Height; i++)
        {
            Q[i] = _table[i, column] < 0 ? double.MaxValue : _freeCoefficients[i] / _table[i, column];
        }

        return Array.IndexOf(Q, Q.Min());
    }

    public void SwapBasis(int basisIndex, int newBasis)
    {
        _basis[basisIndex] = newBasis;
        var delimeter = _table[basisIndex, newBasis];
        _table[basisIndex] /= delimeter;
        _freeCoefficients[basisIndex] /= delimeter;
        for (int row = 0; row < _table.Height; row++)
        {
            if (row == basisIndex)
                continue;

            var multiplier = _table[row, newBasis];
            _table[row] -= _table[basisIndex] * multiplier;
            _freeCoefficients[row] -= _freeCoefficients[basisIndex] * multiplier;
        }
    }
}
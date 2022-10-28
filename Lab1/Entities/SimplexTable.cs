namespace Lab1.Entities;

public class SimplexTable
{
    private readonly double[] _functionCoefficients;
    private readonly int[] _basis;
    private readonly double[] _freeCoefficients;
    private readonly Table _table;
    private readonly double[] _deltas;


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
        for (var i = 0; i < _basis.Length; i++)
        {
            var nextBasisIndex = 0;
            if (_basis[i] != -1)
                continue;

            while (_table[i, nextBasisIndex] == 0 || _basis.Contains(nextBasisIndex))
                nextBasisIndex++;

            SwapBasis(i, nextBasisIndex);
        }
    }

    private void EnsureFreeCoefficientsPositive()
    {
        while (_freeCoefficients.Any(x => x < 0))
        {
            var oldBasisIndex = Array.IndexOf(_freeCoefficients, _freeCoefficients.Min());
            var newBasis = _table[oldBasisIndex].IndexOf(args => args.Min());

            SwapBasis(oldBasisIndex, newBasis);
        }
    }

    public void CalculateDeltas()
    {
        for (var i = 0; i < _deltas.Length; i++)
        {
            _deltas[i] = -_functionCoefficients[i];
            for (var j = 0; j < _table.Height; j++)
            {
                _deltas[i] += _table[j, i] * _functionCoefficients[_basis[j]];
            }
        }

        FreeDelta = 0;
        for (var i = 0; i < _table.Height; i++)
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
        var delimiter = _table[basisIndex, newBasis];
        _table[basisIndex] /= delimiter;
        _freeCoefficients[basisIndex] /= delimiter;
        for (var row = 0; row < _table.Height; row++)
        {
            if (row == basisIndex)
                continue;

            var multiplier = _table[row, newBasis];
            _table[row] -= _table[basisIndex] * multiplier;
            _freeCoefficients[row] -= _freeCoefficients[basisIndex] * multiplier;
        }
    }
}
namespace Lab1.Entities;

public class Row
{
    private readonly double[] _values;

    public int Length => _values.Length;

    public Row(double[] values)
    {
        _values = values;
    }

    public double this[int index]
    {
        get => _values[index];
        set => _values[index] = value;
    }

    public int IndexOf(Func<double[], double> f)
    {
        return Array.IndexOf(_values, f.Invoke(_values));
    }
    
    public static Row operator *(Row row, double value)
    {
        double[] result = new double[row._values.Length];
        for (var i = 0; i < row._values.Length; i++)
        {
            result[i] = row._values[i] * value;
        }
        return new Row(result);
    }

    public static Row operator +(Row row1, Row row2)
    {
        double[] result = new double[row1._values.Length];
        for (var i = 0; i < row1._values.Length; i++)
        {
            result[i] = row1._values[i] + row2._values[i];
        }
        return new Row(result);
    }

    public static Row operator -(Row row1, Row row2)
    {
        double[] result = new double[row1._values.Length];
        for (var i = 0; i < row1._values.Length; i++)
        {
            result[i] = row1._values[i] - row2._values[i];
        }
        return new Row(result);
    }

    public static Row operator /(Row row, double value)
    {
        double[] result = new double[row._values.Length];
        for (var i = 0; i < row._values.Length; i++)
        {
            result[i] = row._values[i] / value;
        }
        return new Row(result);
    }
}
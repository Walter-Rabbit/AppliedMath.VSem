namespace Lab1.Entities;

public class Table
{
    private readonly Row[] _table;

    public Table(Row[] table)
    {
        _table = table;
    }

    public Table(int height, int width)
    {
        _table = new Row[height];
        for (int i = 0; i<height; i++)
        {
            _table[i] = new Row(new double[width]);
        }
    }

    public int Height => _table.Length;
    public int Width => _table.Length > 0 ? _table[0].Length : 0;

    public Row this[int i]
    {
        get => _table[i];
        set => _table[i] = value;
    }

    public double this[int i, int j]
    {
        get => _table[i][j];
        set => _table[i][j] = value;
    }
}
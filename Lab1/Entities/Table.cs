namespace Lab1.Entities;

public class Table
{
    // TODO: Вероятно тут нужно будет что-то изменить в зависимости от того, как будет симлекс таблица реализовываться.
    private List<Expression> _grid;

    public Table()
    {
        _grid = new List<Expression>();
    }

    public IReadOnlyList<Expression> Grid => _grid;
    
    public void AddColumn(int columnNumber, Expression expression)
    {
        if (_grid.Count - 1 < columnNumber)
        {
            _grid.AddRange(new Expression[columnNumber - _grid.Count + 1]);
        }

        _grid[columnNumber] = expression;
    }
}
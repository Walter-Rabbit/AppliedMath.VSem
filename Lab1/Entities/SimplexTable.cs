namespace Lab1.Entities;

public class SimplexTable
{
    public int FreeVariablesCount { get; }
    public Table Table { get; }

    // TODO: Возможно стоит добавлять столбцы, а строчки. Ну в общем тут думать надо, как лучше реализовать.
    public SimplexTable(Function function, SystemOfEquations systemOfEquations)
    {
        Table = new Table();

        for (int i = 0; i < function.Expression.Coefficients.Count; i++)
        {
            if (function.Expression.Coefficients[i] != 0)
            {
                Table.AddColumn(i, new Expression());
            }
        }
    }
}
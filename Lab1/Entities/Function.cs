namespace Lab1.Entities;

public class Function
{
    public Function(Expression expression)
    {
        Expression = expression;
    }

    public Expression Expression { get; }
}
using Lab1.Entities.Enums;

namespace Lab1.Entities;

public class Inequality : ILimitation
{
    public Inequality(Expression expression, double freeElement, Term term)
    {
        Expression = expression;
        FreeElement = freeElement;
        Term = term;
    }

    public Expression Expression { get; }
    public double FreeElement { get; }
    public Term Term { get; }
}
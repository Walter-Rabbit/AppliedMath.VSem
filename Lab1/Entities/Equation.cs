using Lab1.Entities.Enums;

namespace Lab1.Entities;

public class Equation : ILimitation
{
    public Equation(Expression leftExpression, double freeElement)
    {
        Expression = leftExpression;
        FreeElement = freeElement;
    }

    public Equation(Inequality inequality, int newXNumber)
    {
        Expression = inequality.Expression;
        FreeElement = inequality.FreeElement;

        if (inequality.Term is Term.GreaterEqual)
        {
            Expression *= -1;
            FreeElement *= -1;
        }
        
        Expression.AddCoefficient(newXNumber, 1);
    }

    public Expression Expression { get; }
    public double FreeElement { get; }
}
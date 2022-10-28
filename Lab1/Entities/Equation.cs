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

        switch (inequality.Term)
        {
            case Term.GreaterEqual:
                Expression.AddCoefficient(newXNumber, -1);
                break;
            case Term.LowerEqual:
                Expression.AddCoefficient(newXNumber, 1);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public Expression Expression { get; }
    public double FreeElement { get; }
}
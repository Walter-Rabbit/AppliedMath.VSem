using Lab1.Entities.Enums;

namespace Lab1.Entities;

public class Equation
{
    /// <summary>
    /// Создать уравнение, заданное выражением и свободным членом. Считается, что свободный член стоит в правой части.
    /// </summary>
    /// <param name="leftExpression">Выражение, заданное коэффициентами, все x стоят слева от знака равенства.</param>
    /// <param name="freeElement">Свободный член, расположенный справа от знака равно.</param>
    public Equation(Expression leftExpression, double freeElement)
    {
        LeftExpression = leftExpression;
        FreeElement = freeElement;
        RightExpression = new Expression();
    }

    /// <summary>
    /// Создать уравнение, заданное неравенством. Знак неравенства заменяется на добавление нового x.
    /// </summary>
    /// <param name="inequality">Неравенство, заданное выражением.</param>
    /// <param name="newXNumber">Номер для нового x.</param>
    public Equation(Inequality inequality, int newXNumber)
    {
        LeftExpression = inequality.Expression;
        FreeElement = inequality.FreeElement;
        RightExpression = new Expression();

        switch (inequality.Term)
        {
            case Term.GreaterEqual:
                LeftExpression.AddCoefficient(newXNumber, -1);
                break;
            case Term.LowerEqual:
                LeftExpression.AddCoefficient(newXNumber, 1);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public Expression LeftExpression { get; }
    public Expression RightExpression { get; }
    public double FreeElement { get; }

    /// <summary>
    /// Приводит уравнение к виду, когда слева стоит только выбранный x с его коэффициентом,
    /// а справа все остальные x с их коэффициентами и свободный член.
    /// </summary>
    /// <param name="xNumber">Порядковый номер x.</param>
    public void ExpressX(int xNumber)
    {
        if (RightExpression.TryGetCoefficient(xNumber, out var savedCoefficient))
        {
            LeftExpression.AddCoefficient(xNumber, -savedCoefficient);
            RightExpression.RemoveCoefficient(xNumber);
        }

        if (!LeftExpression.TryGetCoefficient(xNumber, out _))
        {
            throw new ArgumentException($"There is no such x with number {xNumber}");
        }

        for (int i = 0; i < LeftExpression.Coefficients.Count; i++)
        {
            if (i == xNumber) continue;
            RightExpression.AddCoefficient(i, -LeftExpression.Coefficients[i]);
            LeftExpression.RemoveCoefficient(i);
        }
    }
}
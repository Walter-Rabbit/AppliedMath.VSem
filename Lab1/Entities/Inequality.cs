using Lab1.Entities.Enums;

namespace Lab1.Entities;

public class Inequality
{
    /// <summary>
    /// Создать неравенство, заданное выражением, свободным членом и знаком неравенство.
    /// Считается, что свободный член стоит в правой части, а все x в левой.
    /// </summary>
    /// <param name="expression">Выражение, заданное коэффициентами, все x стоят слева от знака равенства.</param>
    /// <param name="freeElement">Свободный член, расположенный справа от знака ранеравенства.</param>
    /// <param name="term">Условие: больше равно или меньше равно.</param>
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
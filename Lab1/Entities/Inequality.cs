using Lab1.Entities.Enums;

namespace Lab1.Entities;

public class Inequality
{
    private readonly Dictionary<int, double> _coefficients;

    /// <summary>
    /// Неравенство задаётся набором коэффициентов, свободным членом и знаком неравенство.
    /// Считается, что свободный член стоит в правой части, а коэффициенты в левой.
    /// </summary>
    /// <param name="coefficients">Ключ в словаре - это номер x. Все x стоят слева от знака неравенства.</param>
    /// <param name="freeElement">Свободный член, расположенный справа от знака ранеравенства.</param>
    /// <param name="term">Условие: больше равно или меньше равно.</param>
    public Inequality(Dictionary<int, double> coefficients, double freeElement, Term term)
    {
        _coefficients = coefficients;
        FreeElement = freeElement;
        Term = term;
    }

    public IReadOnlyDictionary<int, double> Coefficients => _coefficients;
    public double FreeElement { get; }
    public Term Term { get; }

}
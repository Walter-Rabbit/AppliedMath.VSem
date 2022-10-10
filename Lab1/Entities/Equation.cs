using Lab1.Entities.Enums;

namespace Lab1.Entities;

public class Equation
{
    private readonly List<double> _leftCoefficients;
    private readonly List<double> _rightCoefficients;

    /// <summary>
    /// Уравнение задаётся набором коэффициентов и свободным членом. Считается, что свободный член стоит в правой части.
    /// </summary>
    /// <param name="leftCoefficients">Номер элемента в массиве - это номер x. Все x стоят слева от знака равно</param>
    /// <param name="freeElement">Свободный член, расположенный справа от знака равно.</param>
    public Equation(List<double> leftCoefficients, double freeElement)
    {
        _leftCoefficients = leftCoefficients;
        FreeElement = freeElement;
        _rightCoefficients = new List<double>();
    }

    public Equation(Inequality inequality)
    {
        _leftCoefficients = inequality.Coefficients.ToList();
        FreeElement = inequality.FreeElement;
        _rightCoefficients = new List<double>();

        switch (inequality.Term)
        {
            case Term.GreaterEqual:
                _leftCoefficients.Add(-1);
                break;
            case Term.LowerEqual:
                _leftCoefficients.Add(1);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public IReadOnlyList<double> LeftCoefficients => _leftCoefficients.AsReadOnly();
    public double FreeElement { get; }

    /// <summary>
    /// Приводит уравнение к виду, когда слева стоит только выбранный x с его коэффициентом,
    /// а справа все остальные x с их коэффициентами и свободный член.
    /// </summary>
    /// <param name="xNumber">Порядковый номер x.</param>
    /// <exception cref="NotImplementedException"></exception>
    public void ExpressX(int xNumber)
    {
        throw new NotImplementedException();
    }
}
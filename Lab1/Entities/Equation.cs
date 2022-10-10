using Lab1.Entities.Enums;

namespace Lab1.Entities;

public class Equation
{
    private readonly Dictionary<int, double> _leftCoefficients;
    private readonly Dictionary<int, double> _rightCoefficients;

    /// <summary>
    /// Уравнение задаётся набором коэффициентов и свободным членом. Считается, что свободный член стоит в правой части.
    /// </summary>
    /// <param name="leftCoefficients">Ключ в словаре - это номер x. Все x стоят слева от знака равенства.</param>
    /// <param name="freeElement">Свободный член, расположенный справа от знака равно.</param>
    public Equation(Dictionary<int, double> leftCoefficients, double freeElement)
    {
        _leftCoefficients = leftCoefficients;
        FreeElement = freeElement;
        _rightCoefficients = new Dictionary<int, double>();
    }

    public Equation(Inequality inequality, int newXNumber)
    {
        _leftCoefficients = inequality.Coefficients as Dictionary<int, double> ?? throw new InvalidOperationException();
        FreeElement = inequality.FreeElement;
        _rightCoefficients = new Dictionary<int, double>();

        switch (inequality.Term)
        {
            case Term.GreaterEqual:
                _leftCoefficients.Add(newXNumber, -1);
                break;
            case Term.LowerEqual:
                _leftCoefficients.Add(newXNumber, 1);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public IReadOnlyDictionary<int, double> LeftCoefficients => _leftCoefficients;
    public IReadOnlyDictionary<int, double> RightCoefficients => _rightCoefficients;
    public double FreeElement { get; }

    /// <summary>
    /// Приводит уравнение к виду, когда слева стоит только выбранный x с его коэффициентом,
    /// а справа все остальные x с их коэффициентами и свободный член.
    /// </summary>
    /// <param name="xNumber">Порядковый номер x.</param>
    /// <exception cref="NotImplementedException"></exception>
    public void ExpressX(int xNumber)
    {
        if (_rightCoefficients.TryGetValue(xNumber, out var savedCoefficient))
        {
            _leftCoefficients.Add(xNumber, -savedCoefficient);
            _rightCoefficients.Remove(xNumber);
        }

        foreach (var coefficient in _leftCoefficients
                     .Where(coefficient => coefficient.Key != xNumber))
        {
            _rightCoefficients.Add(coefficient.Key, -coefficient.Value);
            _leftCoefficients.Remove(coefficient.Key);
        }
    }
}
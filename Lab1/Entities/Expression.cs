namespace Lab1.Entities;

public class Expression
{
    private readonly List<double> _coefficients;

    /// <summary>
    /// Создать пустого выражения.
    /// </summary>
    public Expression()
    {
        _coefficients = new List<double>();
    }

    /// <summary>
    /// Создать выражение, заданное набором коэффициентов. Номер элемента в листе - номер коэффициента при соответствующем x.
    /// </summary>
    public Expression(List<double> coefficients)
    {
        _coefficients = coefficients;
    }

    public IReadOnlyList<double> Coefficients => _coefficients.AsReadOnly();

    /// <summary>
    /// Вставляет новый x с указанным номером и коэффициентом.
    /// </summary>
    /// <param name="xNumber">Номер для нового x.</param>
    /// <param name="coefficient">Коэффициент для нового x.</param>
    public void AddCoefficient(int xNumber, double coefficient)
    {
        if (_coefficients.Count - 1 < xNumber)
        {
            _coefficients.AddRange(new double[xNumber - _coefficients.Count + 1]);
        }

        _coefficients[xNumber] = coefficient;
    }

    /// <summary>
    /// Приравнивает коэффициент выбранного x к 0.
    /// </summary>
    /// <param name="xNumber">Номер x.</param>
    public void RemoveCoefficient(int xNumber)
    {
        if (_coefficients.Count - 1 >= xNumber)
        {
            _coefficients[xNumber] = 0;
        }
    }

    /// <summary>
    /// Попробовать достать коэффициент. Если такого коэффициента нет или он равен 0, будет возвращаено false.
    /// </summary>
    /// <param name="xNumber">Номер x.</param>
    /// <param name="coefficient">Если x с таким номером существует, то тут будет находиться коэффициент.</param>
    /// <returns></returns>
    public bool TryGetCoefficient(int xNumber, out double coefficient)
    {
        if (_coefficients.Count - 1 < xNumber || _coefficients[xNumber] == 0)
        {
            coefficient = 0;
            return false;
        }

        coefficient = _coefficients[xNumber];
        return true;
    }

    public static Expression operator *(Expression expression, double number)
    {
        var newCoefficients = expression._coefficients.Select(x => x * number).ToList();
        return new Expression(newCoefficients);
    }

    public static Expression operator /(Expression expression, double number)
    {
        var newCoefficients = expression._coefficients.Select(x => x / number).ToList();
        return new Expression(newCoefficients);
    }
}
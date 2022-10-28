namespace Lab1.Entities;

public class Expression
{
    private readonly List<double> _coefficients;

    public Expression()
    {
        _coefficients = new List<double>();
    }

    public Expression(List<double> coefficients)
    {
        _coefficients = coefficients;
    }

    public IReadOnlyList<double> Coefficients => _coefficients.AsReadOnly();

    public void AddCoefficient(int xNumber, double coefficient)
    {
        if (_coefficients.Count - 1 < xNumber)
        {
            _coefficients.AddRange(new double[xNumber - _coefficients.Count + 1]);
        }

        _coefficients[xNumber] = coefficient;
    }

    public void Resize(int newSize)
    {
        if (newSize - _coefficients.Count < 0)
        {
            throw new ArgumentException("You can only add coefficients.");
        }

        _coefficients.AddRange(new double[newSize - _coefficients.Count]);
    }

    public void RemoveCoefficient(int xNumber)
    {
        if (_coefficients.Count - 1 >= xNumber)
        {
            _coefficients[xNumber] = 0;
        }
    }

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
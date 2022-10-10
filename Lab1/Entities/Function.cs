namespace Lab1.Entities;

public class Function
{
    private Dictionary<int, double> _coefficients;

    public Function(Dictionary<int, double> coefficients)
    {
        _coefficients = coefficients;
    }

    public IReadOnlyDictionary<int, double> Coefficients => _coefficients;
}
namespace Lab1.Entities;

public class SystemOfEquations
{
    private List<Equation> _equations;

    public SystemOfEquations(List<Equation> equations)
    {
        _equations = equations;
    }

    public IReadOnlyList<Equation> Equations => _equations;

    /// <summary>
    /// Минимизирует функцию с ограничениями, заданными системой уравнений.
    /// </summary>
    /// <param name="function">Целевая функция для минимизации.</param>
    /// <returns>Значения x, при которых функция минимальна.</returns>
    /// <exception cref="NotImplementedException"></exception>
    public Dictionary<int, double> Minimize(Function function)
    {
        throw new NotImplementedException();
    }
    
    /// <summary>
    /// Максимизирует функцию с ограничениями, заданными системой уравнений.
    /// </summary>
    /// <param name="function">Целевая функция для максимизации.</param>
    /// <returns>Значения x, при которых функция максимальна.</returns>
    /// <exception cref="NotImplementedException"></exception>
    public Dictionary<int, double> Maximize(Function function)
    {
        throw new NotImplementedException();
    }
}
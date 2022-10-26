using Lab1.Entities;

namespace Lab1;

public class SimplexMethod
{
    /// <summary>
    /// Минимизирует функцию с ограничениями, заданными системой уравнений.
    /// </summary>
    /// <param name="function">Целевая функция для минимизации.</param>
    /// <param name="systemOfEquations">Системак ограничений.</param>
    /// <returns>Значения x, при которых функция минимальна.</returns>
    /// <exception cref="NotImplementedException"></exception>
    public Dictionary<int, double> Minimize(Function function, SystemOfEquations systemOfEquations)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Максимизирует функцию с ограничениями, заданными системой уравнений.
    /// </summary>
    /// <param name="function">Целевая функция для максимизации.</param>
    /// <param name="systemOfEquations">Система ограничений.</param>
    /// <returns>Значения x, при которых функция максимальна.</returns>
    /// <exception cref="NotImplementedException"></exception>
    public Dictionary<int, double> Maximize(Function function, SystemOfEquations systemOfEquations)
    {
        throw new NotImplementedException();
    }
}
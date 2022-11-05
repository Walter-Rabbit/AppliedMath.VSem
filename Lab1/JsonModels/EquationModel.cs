using Lab1.Entities;

namespace Lab1.JsonModels;

public class EquationModel
{
    public List<double> Coefficients { get; set; }
    public double FreeElement { get; set; }

    public ILimitation GetEntity()
    {
        return new Equation(new Expression(Coefficients), FreeElement);
    }
}
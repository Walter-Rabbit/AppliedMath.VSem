using Lab1.Entities;

namespace Lab1.JsonModels;

public class FunctionModel
{
    public List<double> Coefficients { get; set; }

    public Expression GetEntity()
    {
        return new Expression(Coefficients);
    }
}
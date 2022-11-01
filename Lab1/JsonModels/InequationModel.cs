using Lab1.Entities;
using Lab1.Entities.Enums;

namespace Lab1.JsonModels;

public class InequalityModel
{
    public List<double> Coefficients { get; set; }
    public double FreeElement { get; set; }
    public Term Term { get; set; }

    public ILimitation GetEntity()
    {
        return new Inequality(new Expression(Coefficients), FreeElement, Term);
    }
}
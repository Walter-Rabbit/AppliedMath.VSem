using Lab1.Entities;

namespace Lab1.JsonModels;

public class SimplexTaskModel
{
    public List<EquationModel> Equations { get; set; }
    public List<InequalityModel> Inequalities { get; set; }
    public FunctionModel Function { get; set; }
    public Mode Mode { get; set; }

    public (SystemOfLimitations, Expression) GetEntity()
    {
        var limitations = new List<ILimitation>();
        limitations.AddRange(Equations.Select(e => e.GetEntity()));
        limitations.AddRange(Inequalities.Select(i => i.GetEntity()));
        return (new SystemOfLimitations(limitations), Function.GetEntity());
    }
}
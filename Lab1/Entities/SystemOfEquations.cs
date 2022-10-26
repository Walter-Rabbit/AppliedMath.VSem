namespace Lab1.Entities;

public class SystemOfEquations
{
    private List<Equation> _equations;

    public SystemOfEquations(List<Equation> equations)
    {
        _equations = equations;
    }

    public IReadOnlyList<Equation> Equations => _equations;
}
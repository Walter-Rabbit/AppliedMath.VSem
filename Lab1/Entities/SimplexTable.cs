namespace Lab1.Entities;

public class SimplexTable
{
    public int FreeVariablesCount { get; }
    public Dictionary<int, Dictionary<int, double>> Table { get; }

    public SimplexTable(Function function, SystemOfEquations systemOfEquations)
    {
        Table = new Dictionary<int, Dictionary<int, double>>();
        
        foreach (var coefficient in function.Coefficients)
        {
            Table.Add(coefficient.Key, new Dictionary<int, double>());
        }
    }
}
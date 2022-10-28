namespace Lab1;

public class SimplexMethodResult
{
    public double[] X { get; }
    public double FunctionValue { get; }

    public SimplexMethodResult(double[] x, double functionValue)
    {
        X = x;
        FunctionValue = functionValue;
    }
}
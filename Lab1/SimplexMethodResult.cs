namespace Lab1;

public class SimplexMethodResult : IEquatable<SimplexMethodResult>
{
    public double[] X { get; }
    public double FunctionValue { get; }

    public SimplexMethodResult(double[] x, double functionValue)
    {
        X = x;
        FunctionValue = functionValue;
    }


    public bool Equals(SimplexMethodResult? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;

        if (Math.Abs(FunctionValue - other.FunctionValue) > 0.01)
        {
            return false;
        }

        if (X.Length != other.X.Length)
        {
            return false;
        }

        return !X.Where((x, i) => Math.Abs(x - other.X[i]) > 0.01).Any();
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SimplexMethodResult)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, FunctionValue);
    }
}
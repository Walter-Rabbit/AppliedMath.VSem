using System.Drawing;
using Lab3.MarkovChainSolvers;
using MathNet.Numerics.LinearAlgebra;
using ScottPlot;

void Write(Vector<double> vector)
{
    Console.Write("{ ");
    foreach (var elm in vector)
    {
        Console.Write(Math.Round(elm, 5) + "; ");
    }

    Console.WriteLine("}");
}

var matrix = Matrix<double>.Build.DenseOfArray(new[,]
{
    { 0.05, 0.65, 0.0, 0.0, 0.0, 0.0, 0.2, 0.1 },
    { 0.1, 0.01, 0.1, 0.79, 0.0, 0.0, 0.0, 0.0 },
    { 0.0, 0.1, 0.02, 0.88, 0.0, 0.0, 0.0, 0.0 },
    { 0.1, 0.0, 0.0, 0.1, 0.3, 0.4, 0.1, 0.0 },
    { 0.0, 0.0, 0.0, 0.3, 0.2, 0.5, 0.0, 0.0 },
    { 0.0, 0.0, 0.0, 0.6, 0.35, 0.05, 0.0, 0.0 },
    { 0.25, 0.0, 0.0, 0.3, 0.0, 0.0, 0.45, 0.0 },
    { 0.67, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.33 }
});

var (solution1, errors1) = new MarkovChainSolverInLimit().Solve(matrix, 1);
var (solution2, errors2) = new MarkovChainSolverInLimit().Solve(matrix, 6);

var plt = new Plot(1200, 800);
var ones1 = Enumerable.Range(0, errors1.Count).Select(x => (double)x).ToArray();
var ones2 = Enumerable.Range(0, errors2.Count).Select(x => (double)x).ToArray();
plt.AddScatter(ones1, errors1.ToArray(), Color.Blue, lineWidth: 3f, label: "1");
plt.AddScatter(ones2, errors2.ToArray(), Color.Red, lineWidth: 3f, lineStyle: LineStyle.Dash, label: "3");
plt.Legend(location: Alignment.UpperRight);
plt.XLabel("Iteration");
plt.YLabel("Error");
plt.SaveFig("..\\..\\..\\plot.png");
plt.Clear();

Console.WriteLine("Solution in limit (Start position - 1):");
Console.WriteLine("Number of iterations: " + errors1.Count);
Write(solution1);
Console.WriteLine();

Console.WriteLine("Solution in limit (Start position - 6):");
Console.WriteLine("Number of iterations: " + errors2.Count);
Write(solution2);
Console.WriteLine();

var solution = new MarkovChainSolverAnalytical().Solve(matrix);
Console.WriteLine("Analytical solution:");
Write(solution);
Console.WriteLine();

var groupNames = Enumerable.Range(0, matrix.RowCount).Select(i => i.ToString()).ToArray();
var seriesNames = new[] { "Start 1", "Start 6", "Analytical" };
var valuesBySeries = new[] { solution1.ToArray(), solution2.ToArray(), solution.ToArray() };
plt.AddBarGroups(groupNames, seriesNames, valuesBySeries, null);
plt.XLabel("Condition");
plt.YLabel("Probability");

plt.SaveFig("..\\..\\..\\solution.png");
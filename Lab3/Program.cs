using System.Drawing;
using Lab3.MarkovChainSolvers;
using MathNet.Numerics.LinearAlgebra;
using ScottPlot;

var matrix = Matrix<double>.Build.DenseOfArray(new double[3, 3]
{
    { 0.25, 0.5, 0.25 },
    { 0.0, 0.5, 0.5 },
    { 0.33, 0.33, 0.34 }
});

var vector1 = Vector<double>.Build.DenseOfArray(new double[] { 0.0, 0.5, 0.5 });
var vector2 = Vector<double>.Build.DenseOfArray(new double[] { 0.25, 0.5, 0.25 });

var (solution1, errors1) = new MarkovChainSolverInLimit().Solve(vector1, matrix, 0.0000001, 100);
var (solution2, errors2) = new MarkovChainSolverInLimit().Solve(vector2, matrix, 0.0000001, 100);

var plt = new ScottPlot.Plot(400, 300);
var ones1 = Enumerable.Range(0, errors2.Count).Select(x => (double)x).ToArray();
var ones2 = Enumerable.Range(0, errors2.Count).Select(x => (double)x).ToArray();
plt.AddScatter(ones1, errors1.ToArray(), Color.Blue, label: "{ 0.0, 0.5, 0.5 }");
plt.AddScatter(ones2, errors2.ToArray(), Color.Red, label: "{ 0.25, 0.5, 0.25 }");
plt.Legend(location: Alignment.UpperRight);
plt.SaveFig("..\\..\\..\\plot.png");

Console.WriteLine("Solution in limit ({ 0.0, 0.5, 0.5 }):");
Console.WriteLine("Number of iterations: " + errors1.Count);
Console.WriteLine(solution1[0]);
Console.WriteLine(solution1[1]);
Console.WriteLine(solution1[2]);
Console.WriteLine();

Console.WriteLine("Solution in limit ({ 0.25, 0.5, 0.25 }):");
Console.WriteLine("Number of iterations: " + errors2.Count);
Console.WriteLine(solution2[0]);
Console.WriteLine(solution2[1]);
Console.WriteLine(solution2[2]);
Console.WriteLine();


var solution = new MarkovChainSolverAnalytical().Solve(matrix);
Console.WriteLine("Analytical solution:");
Console.WriteLine(solution[0]);
Console.WriteLine(solution[1]);
Console.WriteLine(solution[2]);
Console.WriteLine();
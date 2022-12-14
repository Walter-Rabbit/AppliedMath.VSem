using Lab3.EquationSystemSolvers.Tools;
using Lab3.MarkovChainSolvers;

var matrix = MatrixPool<double>.Get(3, 3);
matrix[0, 0] = 0.25;
matrix[0, 1] = 0.5;
matrix[0, 2] = 0.25;
matrix[1, 0] = 0.0;
matrix[1, 1] = 0.5;
matrix[1, 2] = 0.5;
matrix[2, 0] = 0.33;
matrix[2, 1] = 0.33;
matrix[2, 2] = 0.34;


var vector = VectorPool<double>.Get(3);
vector[0] = 0.0;
vector[1] = 0.5;
vector[2] = 0.5;


var solution = new MarkovChainSolverInLimit().Solve(vector, matrix, 0.0000001);

Console.WriteLine(solution[0]);
Console.WriteLine(solution[1]);
Console.WriteLine(solution[2]);
Console.WriteLine();

solution = new MarkovChainSolverAnalytical().Solve(matrix);
Console.WriteLine(solution[0]);
Console.WriteLine(solution[1]);
Console.WriteLine(solution[2]);
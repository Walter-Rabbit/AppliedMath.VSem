using Lab1;
using Lab1.Entities;

var eq = new Expression(new List<double>() { -1, -2, -3, 1 });

var s = new SystemOfLimitations(new List<ILimitation>()
{
    new Equation(new Expression(new List<double>() { 1, -3, -1, -2 }), -4),
    new Equation(new Expression(new List<double>() { 1, -1, 1, 0 }), 0),
});

var m = new SimplexMethod();
var r = m.Minimize(eq, s);

Console.WriteLine(r);
using Lab1;
using Lab1.Entities;
using Lab1.Entities.Enums;

var eq = new Expression(new List<double>() {-1, -2, -3, 1 });

var s = new SystemOfEquations(new List<Equation>()
{
    new Equation(new Expression(new List<double>() { 1, -3, -1, -2 }), -4),
    new Equation(new Expression(new List<double>() { 1, -1, 1, 0 }), 0),
});

var m = new SimplexMethod();
var r = m.Minimize(eq, s);

Console.WriteLine(r);
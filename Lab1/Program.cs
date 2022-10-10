using Lab1.Entities;
using Lab1.Entities.Enums;

void Write(Equation equation)
{
    Console.WriteLine("Left:");
    foreach (var coef in equation.LeftCoefficients)
    {
        Console.WriteLine(coef);
    }

    Console.WriteLine("Right:");
    foreach (var coef in equation.RightCoefficients)
    {
        Console.WriteLine(coef);
    }

    Console.WriteLine(equation.FreeElement);
}

var coefs = new Dictionary<int, double> { { 1, 2 }, { 2, 3 }, { 3, 5 }, { 4, 2 } };
var ineq = new Inequality(coefs, 2, Term.GreaterEqual);

var eq1 = new Equation(ineq, 5);
Write(eq1);

eq1.ExpressX(3);
Write(eq1);

eq1.ExpressX(2);
Write(eq1);
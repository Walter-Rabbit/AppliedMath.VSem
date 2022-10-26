using Lab1.Entities;
using Lab1.Entities.Enums;

void Write(Equation equation)
{
    Console.WriteLine("Left:");
    foreach (var coef in equation.LeftExpression.Coefficients)
    {
        if (coef != 0)
        {
            Console.WriteLine(coef);
        }
    }

    Console.WriteLine("Right:");
    foreach (var coef in equation.RightExpression.Coefficients)
    {
        if (coef != 0)
        {
            Console.WriteLine(coef);
        }
    }

    Console.WriteLine(equation.FreeElement);
}

var coefs = new List<double> { 2, 3, 5, 2 };
var ineq = new Inequality(new Expression(coefs), 2, Term.GreaterEqual);

var eq1 = new Equation(ineq, 5);
Write(eq1);

eq1.ExpressX(3);
Write(eq1);

eq1.ExpressX(2);
Write(eq1);
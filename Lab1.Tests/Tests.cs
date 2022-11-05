using System.Collections.Generic;
using Lab1.Entities;
using Lab1.Entities.Enums;
using NUnit.Framework;

namespace Lab1.Tests;

public class Tests
{
    private readonly SimplexMethod _simplexMethod = new();

    [Test]
    public void Test1_AnswerIsCorrect()
    {
        var eq = new Expression(new List<double> { -6, -1, -4, 5 });

        var s = new SystemOfLimitations(new List<ILimitation>
        {
            new Equation(new Expression(new List<double> { 3, 1, -1, 1 }), 4),
            new Equation(new Expression(new List<double> { 5, 1, 1, -1 }), 4)
        });

        var result = _simplexMethod.Minimize(eq, s);
        Assert.AreEqual(-4, result.FunctionValue, 0.00001);
    }

    [Test]
    public void Test2_AnswerIsCorrect()
    {
        var eq = new Expression(new List<double> { -1, -2, -3, 1 });

        var s = new SystemOfLimitations(new List<ILimitation>
        {
            new Equation(new Expression(new List<double> { 1, -3, -1, -2 }), -4),
            new Equation(new Expression(new List<double> { 1, -1, 1, 0 }), 0)
        });

        var result = _simplexMethod.Minimize(eq, s);
        Assert.AreEqual(-6, result.FunctionValue, 0.00001);
    }

    [Test]
    public void Test3_AnswerIsCorrect()
    {
        var eq = new Expression(new List<double> { -1, -2, -1, 3, -1 });

        var s = new SystemOfLimitations(new List<ILimitation>
        {
            new Equation(new Expression(new List<double> { 1, 1, 0, 2, 1 }), 5),
            new Equation(new Expression(new List<double> { 1, 1, 1, 3, 2 }), 9),
            new Equation(new Expression(new List<double> { 0, 1, 1, 2, 1 }), 6)
        });

        var result = _simplexMethod.Minimize(eq, s);
        Assert.AreEqual(-11, result.FunctionValue, 0.00001);
    }

    [Test]
    public void Test4_AnswerIsCorrect()
    {
        var eq = new Expression(new List<double> { -1, -1, -1, 1, -1 });

        var s = new SystemOfLimitations(new List<ILimitation>
        {
            new Equation(new Expression(new List<double> { 1, 1, 2, 0, 0 }), 4),
            new Equation(new Expression(new List<double> { 0, -2, -2, 1, -1 }), -6),
            new Equation(new Expression(new List<double> { 1, -1, 6, 1, 1 }), 12)
        });

        var result = _simplexMethod.Minimize(eq, s);
        Assert.AreEqual(-10, result.FunctionValue, 0.00001);
    }

    [Test]
    public void Test5_AnswerIsCorrect()
    {
        var eq = new Expression(new List<double> { -1, 4, -3, 10 });

        var s = new SystemOfLimitations(new List<ILimitation>
        {
            new Equation(new Expression(new List<double> { 1, 1, -1, 10 }), 0),
            new Equation(new Expression(new List<double> { 1, 14, 10, -10 }), 11)
        });

        var result = _simplexMethod.Minimize(eq, s);
        Assert.AreEqual(-4, result.FunctionValue, 0.00001);
    }

    [Test]
    public void Test6_Minimize_AnswerIsCorrect()
    {
        var eq = new Expression(new List<double> { -1, 5, 3, -1 });

        var s = new SystemOfLimitations(new List<ILimitation>
        {
            new Inequality(new Expression(new List<double> { 1, 3, 3, 1 }), 3, Term.LowerEqual),
            new Inequality(new Expression(new List<double> { 2, 0, 3, -1 }), 4, Term.LowerEqual)
        });

        var result = _simplexMethod.Minimize(eq, s);
        Assert.AreEqual(-3, result.FunctionValue, 0.00001);
    }

    [Test]
    public void Test6_Maximize_AnswerIsCorrect()
    {
        var eq = new Expression(new List<double> { -1, 5, 3, -1 });

        var s = new SystemOfLimitations(new List<ILimitation>
        {
            new Inequality(new Expression(new List<double> { 1, 3, 3, 1 }), 3, Term.LowerEqual),
            new Inequality(new Expression(new List<double> { 2, 0, 3, -1 }), 4, Term.LowerEqual)
        });

        var result = _simplexMethod.Maximize(eq, s);
        Assert.AreEqual(5, result.FunctionValue, 0.00001);
    }

    [Test]
    public void Test7_AnswerIsCorrect()
    {
        var eq = new Expression(new List<double> { -1, -1, 1, -1, 2 });

        var s = new SystemOfLimitations(new List<ILimitation>
        {
            new Equation(new Expression(new List<double> { 3, 1, 1, 1, -2 }), 10),
            new Equation(new Expression(new List<double> { 6, 1, 2, 3, -4 }), 20),
            new Equation(new Expression(new List<double> { 10, 1, 3, 6, -7 }), 30)
        });

        var result = _simplexMethod.Minimize(eq, s);
        Assert.AreEqual(10, result.FunctionValue, 0.00001);
    }
    
    [Test]
    public void TestExtra_Maximize_AnswerIsCorrect()
    {
        var eq = new Expression(new List<double> { -1, 3 });

        var s = new SystemOfLimitations(new List<ILimitation>
        {
            new Inequality(new Expression(new List<double> { 1, 2 }), 4, Term.LowerEqual),
            new Inequality(new Expression(new List<double> { 1, -1 }), 1, Term.GreaterEqual),
            new Inequality(new Expression(new List<double> { 1, 1 }), 8, Term.LowerEqual),
        });

        var result = _simplexMethod.Maximize(eq, s);
        Assert.AreEqual(1, result.FunctionValue, 0.00001);
    }
}
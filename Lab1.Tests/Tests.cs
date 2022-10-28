using System.Collections.Generic;
using Lab1.Entities;
using NUnit.Framework;

namespace Lab1.Tests;

public class Tests
{
    private readonly SimplexMethod _simplexMethod = new();

    [Test]
    public void Test1_AnswerIsCorrect()
    {
        var eq = new Expression(new List<double> { -6, -1, -4, 5 });

        var s = new SystemOfEquations(new List<Equation>
        {
            new(new Expression(new List<double> { 3, 1, -1, 1 }), 4),
            new(new Expression(new List<double> { 5, 1, 1, -1 }), 4)
        });

        var result = _simplexMethod.Minimize(eq, s);
        var realResult = new SimplexMethodResult(new double[] { 0, 4, 0, 0 }, -4);

        Assert.AreEqual(realResult, result);
    }

    [Test]
    public void Test2_AnswerIsCorrect()
    {
        var eq = new Expression(new List<double> { -1, -2, -3, 1 });

        var s = new SystemOfEquations(new List<Equation>
        {
            new(new Expression(new List<double> { 1, -3, -1, -2 }), -4),
            new(new Expression(new List<double> { 1, -1, 1, 0 }), 0)
        });

        var result = _simplexMethod.Minimize(eq, s);
        var realResult = new SimplexMethodResult(new double[] { 2, 2, 0, 0 }, -6);

        Assert.AreEqual(realResult, result);
    }

    [Test]
    public void Test3_AnswerIsCorrect()
    {
        var eq = new Expression(new List<double> { -1, -2, -1, 3, -1 });

        var s = new SystemOfEquations(new List<Equation>
        {
            new(new Expression(new List<double> { 1, 1, 0, 2, 1 }), 5),
            new(new Expression(new List<double> { 1, 1, 1, 3, 2 }), 9),
            new(new Expression(new List<double> { 0, 1, 1, 2, 1 }), 6)
        });

        var result = _simplexMethod.Minimize(eq, s);
        var realResult = new SimplexMethodResult(new double[] { 3, 2, 4, 0, 0 }, -11);

        Assert.AreEqual(realResult, result);
    }
    
    [Test]
    public void Test4_AnswerIsCorrect()
    {
        var eq = new Expression(new List<double> { -1, -1, -1, 1, -1 });

        var s = new SystemOfEquations(new List<Equation>
        {
            new(new Expression(new List<double> { 1, 1, 2, 0, 0 }), 4),
            new(new Expression(new List<double> { 0, -2, -2, 1, -1 }), -6),
            new(new Expression(new List<double> { 1, -1, 6, 1, 1 }), 12)
        });

        var result = _simplexMethod.Minimize(eq, s);
        var realResult = new SimplexMethodResult(new double[] { 4, 0, 0, 1, 7 }, -10);

        Assert.AreEqual(realResult, result);
    }
    
    [Test]
    public void Test5_AnswerIsCorrect()
    {
        var eq = new Expression(new List<double> { -1, 4, -3, 10 });

        var s = new SystemOfEquations(new List<Equation>
        {
            new(new Expression(new List<double> { 1, 1, -1, 10 }), 0),
            new(new Expression(new List<double> { 1, 14, 10, -10 }), 11),
        });

        var result = _simplexMethod.Minimize(eq, s);
        var realResult = new SimplexMethodResult(new double[] { 1, 0, 1, 0 }, -4);

        Assert.AreEqual(realResult, result);
    }
}
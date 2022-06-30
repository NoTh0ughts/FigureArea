using System;
using System.Collections.Generic;
using System.Globalization;
using FigureArea.Exceptions;
using FigureArea.Figures;
using FigureArea.Figures.FigureExtensions;
using NUnit.Framework;

namespace TestFigureArea;

[TestFixture]
public class TriangleTests
{
    private Triangle _triangle;
    
    [SetUp]
    public void Setup()
    {
        _triangle = new Triangle(5,6,7);
    }

    [Test]
    public void IncorrectCreationTriangle()
    {
        Assert.Catch<IncorrectTriangleException>(() =>
        {
            _triangle = new Triangle(293, 2, 1);
        });
    }

    [Test]
    public void CommonIndexerTest()
    {
        Assert.AreEqual(_triangle[2], 7d);
    }

    [Test]
    public void IncorrectIndexInIndexerTest()
    {
        Assert.Catch<ArgumentOutOfRangeException>(() =>
        {
            var s = _triangle[6].ToString(CultureInfo.InvariantCulture);
        });
    }

    [Test]
    public void NegativeSidesTest()
    {
        var expected = new double[] {1, 1, 1};
        _triangle = new Triangle(-1, -1, -1);
        
        Assert.AreEqual(_triangle.AsArray(), expected);
    }

    [Test]
    public void IsRightTriangleTest()
    {
        _triangle = new Triangle(3, 4, 5);
        
        Assert.True(_triangle.IsRightTriangle());
    }

    [Test] 
    public void IsCorrectTest()
    {
        var trueTest = _triangle.IsCorrect();
        _triangle.A = 293;
        var falseTest = _triangle.IsCorrect();
        
        Assert.True(trueTest && falseTest == false);
    }

    [Test]
    public void AreaTest()
    {
        var area = _triangle.Area();
        var expectedArea = 14.696938456699069;
        
        Assert.AreEqual(area, expectedArea);
    }

    [Test]
    public void PerimeterTest()
    {
        var perimeter = _triangle.Perimeter();
        var expectedPerimeter = 18;
        
        Assert.AreEqual(perimeter, expectedPerimeter);
    }

    [Test]
    public void SetFieldTest()
    {
        var expected = new Triangle(4, 6, 7);
        _triangle.A = 4;
        
        Assert.AreEqual(_triangle.A, expected.A);
    }

    [Test]
    public void AsArrayTest()
    {
        var expectedArray = new double[] { 5, 6, 7 };
        var array = _triangle.AsArray();

        Assert.AreEqual(array, expectedArray);
    }

    [Test]
    public void AsListTest()
    {
        var expectedList = new List<double> { 5, 6, 7 };
        var array = _triangle.AsList();
        
        Assert.AreEqual(array, expectedList);
    }
}
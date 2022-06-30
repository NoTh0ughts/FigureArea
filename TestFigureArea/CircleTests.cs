using System;
using FigureArea.Figures;
using NUnit.Framework;

namespace TestFigureArea;

[TestFixture]
public class CircleTests
{
    private Circle _circle;
    
    [SetUp]
    public void Setup()
    {
        _circle = new Circle(10);
    }

    [Test]
    public void CommonAreaTest()
    {
        var area = _circle.Area();
        var expectedArea = 314.1592653589793d;
        Assert.AreEqual(area, expectedArea);
    }

    [Test]
    public void NegativeRadius_AreaTest()
    {
        _circle.Radius = -10;
        
        var area = _circle.Area();
        var expectedArea =314.1592653589793d;
        
        Assert.AreEqual(area, expectedArea);
        _circle.Radius = 10;
    }

    [Test]
    public void CommonPerimeter_AreaTest()
    {
        var perimeter = _circle.Perimeter();
        var expectedPerimeter = 62.83185307179586d;
        
        Assert.AreEqual(perimeter, expectedPerimeter);
    }

    [Test]
    public void PositiveInfinityRadius_AreaTest()
    {
        _circle.Radius = Double.PositiveInfinity;
        var area = _circle.Area();
        
        Assert.True(double.IsInfinity(area));
        _circle.Radius = 10;
    }   
    
    
    [Test]
    public void NegativeInfinityRadius_AreaTest()
    {
        _circle.Radius = Double.NegativeInfinity;
        var area = _circle.Area();
        
        Assert.True(double.IsInfinity(area));
        _circle.Radius = 10;
    }

    [Test]
    public void NANRadius_AreaTest()
    {
        _circle.Radius = Double.NaN;
        var area = _circle.Area();
        
        Assert.True(double.IsNaN(area));
        _circle.Radius = 10;
    }
}
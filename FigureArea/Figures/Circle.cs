namespace FigureArea.Figures;

/// <summary>
/// Класс двумерной фигуры окружности
/// </summary>
public class Circle : BaseFigure
{
    /// <summary>
    /// Радуиус окружности
    /// </summary>
    public double Radius
    {
        get => _radius;
        set
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
            {
                _radius = 1;
            }
            _radius = Math.Abs(value);
        }
    }

    private double _radius;
    
    public Circle() => _radius = 1f;
    public Circle(double radius) => _radius = radius;
    
    public override double Area() => Math.Pow(Radius, 2) * Math.PI;
    public override double Perimeter() => Math.PI * 2 * Radius;
}
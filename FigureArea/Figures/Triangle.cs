using FigureArea.Constants;
using FigureArea.Exceptions;

namespace FigureArea.Figures;


/// <summary>
/// Представляет собой двумерную фигуру произвольного треугольника
/// Содержит 3 стороны, доступ к которым возможен по индексу или через явный экземпляр класса по соотв. полю.
/// </summary>
public class Triangle : BaseFigureWithSides
{
    public override double this[int index]
    {
        get
        {
            return index switch
            {
                0 => A,
                1 => B,
                2 => C,
                _ => throw new ArgumentOutOfRangeException("Введен неверный индекс")
            };
        }
    }

    public double A
    {
        get => _a;
        set => _a = Math.Abs(value);
    }

    public double B
    {
        get => _b;
        set => _b = Math.Abs(value);
    }

    public double C
    {
        get => _c;
        set => _c = Math.Abs(value);
    }

    private double _a;
    private double _b;
    private double _c;

    public Triangle()
    {
        SidesCount = 3;
        (A, B, C) = (1d, 1d, 1d);
    }

    public Triangle(double a, double b, double c)
    {
        SidesCount = 3;
        (A, B, C) = (a, b, c);
        
        if(IsCorrect() == false)
        {
            throw new IncorrectTriangleException(
                "Правила создания фигуры не выполнены, невозможно создать объект типа " + nameof(Triangle));
        }   
    }

    public override double Area()
    {
        if (IsCorrect() == false)
        {
            throw new IncorrectTriangleException("Невозможно вычислить площадь несуществующего треугольника");
        }
        
        double halfPerimeter = FigureMathHelper.HalfPerimeter(A, B, C);
        double p_Sides = halfPerimeter * (halfPerimeter - A) * (halfPerimeter - B) * (halfPerimeter - C);

        double area = Math.Sqrt(p_Sides);
        
        return area;
    }
    
    /// <summary>
    /// Проверяет, является ли заданная фигура прямоугольным треугольником
    ///
    /// Проверка осуществляется с помощью теоремы Пифагора:
    /// Каждая сторона проверяется, выполняет ли она теорему Пифагора
    /// Для этого суммируются квадраты двух сторон и сравниваются с квадратом "подбираемой" гипотенузы
    /// В случае, если разница меньше относительной погрешности tolerance, то данная фигура - прямоугольник
    ///
    /// <remarks>
    /// Ввел понятие погрешности, поскольку стороны могут быть не целочисленными,
    /// а сравнение double - типов без погрешности не сработает, в связи с особенностями работы плавающей точки 
    /// </remarks>
    /// </summary>
    /// <returns> Результат проверки </returns>
    public bool IsRightTriangle()
    {
        double tolerance = FigureMathHelper.Perimeter(A, B, C) * FigureConstants.TolerancePercent;
        bool isC_Hypo = Math.Abs((A * A) + (B * B) - (C * C)) < tolerance;
        bool isB_Hypo = Math.Abs((C * C) + (A * A) - (B * B)) < tolerance;
        bool isA_Hypo = Math.Abs((C * C) + (B * B) - (A * A)) < tolerance;
        
        return isA_Hypo || isB_Hypo || isC_Hypo;
    }
    
    public sealed override bool IsCorrect()
    {
        return (A + B > C) && (B + C > A) && (A + C > B);
    }
}
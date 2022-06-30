using FigureArea.Figures.FigureExtensions;

namespace FigureArea.Figures;

/// <summary>
/// Задает свойства и поведение для фигур, которые содержат стороны
/// </summary>
public abstract class BaseFigureWithSides : BaseFigure
{
    /// <summary>
    /// Количество сторон у фигуры
    /// </summary>
    public int SidesCount { get; protected set; }
    
    /// <summary>
    /// Получение стороны по ее индексу
    /// </summary>
    /// <param name="index"></param>
    public abstract double this[int index] { get; }

    public abstract override double Area();

    public override double Perimeter()
    {
        return FigureMathHelper.Perimeter(this.AsArray());
    }
}
namespace FigureArea.Figures;

/// <summary>
/// Задает поведение для всех двумерных фигур
/// </summary>
public abstract class BaseFigure
{
    /// <summary>
    /// Вычисление площади фигуры, которое реализовано в конкретных классах
    /// к примеру <see cref="Circle"/> , <see cref="Triangle"/>
    /// </summary>
    /// <returns> Площадь фигуры </returns>
    public abstract double Area();
    
    /// <summary>
    /// Вычисление периметра фигуры на основе суммы ее сторон или особой формулы (для фигур не имеющих плоских сторон)
    /// </summary>
    /// <returns> Периметр фигуры </returns>
    public abstract double Perimeter();

    
    /// <summary>
    /// Проверяет, создана ли фигура корректно, по умолчанию - true
    /// </summary>
    /// <returns> Результат проверки </returns>
    public virtual bool IsCorrect() => true;
}
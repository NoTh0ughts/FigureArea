namespace FigureArea;

public static class FigureMathHelper
{
    public static double Perimeter(params double[] sides)
    {
        double perimeter = sides.Sum();

        return perimeter;
    }

    public static double HalfPerimeter(params double[] sides)
    {
        double perimeter = Perimeter(sides);

        return perimeter / 2d;
    }
}
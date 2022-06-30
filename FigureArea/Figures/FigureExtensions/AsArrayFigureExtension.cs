namespace FigureArea.Figures.FigureExtensions;

public static class AsArrayFigureExtension
{
    public static double[] AsArray(this BaseFigureWithSides figure)
    {
        double[] array = new double[figure.SidesCount]; 
        for (int i = 0; i < figure.SidesCount; i++)
        {
            array[i] = figure[i];
        }

        return array;
    }
}
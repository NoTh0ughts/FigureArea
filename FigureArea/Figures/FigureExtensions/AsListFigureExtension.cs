namespace FigureArea.Figures.FigureExtensions;

public static class AsListFigureExtension
{
    public static List<double> AsList(this BaseFigureWithSides figure)
    {
        List<double> array = new List<double>(figure.SidesCount); 
        for (int i = 0; i < figure.SidesCount; i++)
        {
            array.Add(figure[i]);
        }

        return array;
    }
}
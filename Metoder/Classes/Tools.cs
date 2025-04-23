namespace Metoder.Classes;

public class Tools
{
    public static void MakeEmptyLines(int numberOfEmptyLines = 1)
    {
        for (int counter = 0; counter < numberOfEmptyLines; counter++)
        {
            Console.WriteLine("");
        }
    }
}
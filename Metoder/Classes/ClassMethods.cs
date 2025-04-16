namespace Metoder.Classes;

public class ClassMethods
{
    public static void FindFiles(string filePath)
    {
        string firstTextInDirectory = "Filer i direktoriet : "; 
        Console.WriteLine("");
        Console.WriteLine($"{firstTextInDirectory}{filePath}");
        for (int counter = 0; counter < firstTextInDirectory.Length; counter++)
        {
            Console.Write("-");
        }
        for (int counter = 0; counter < filePath.Length; counter++)
        {
            Console.Write("-");
        }
        Console.WriteLine("");
        FindNumberOfSubDirectories(filePath);
        Console.WriteLine("");
        
        try
        {
            var files = System.IO.Directory.GetFiles(filePath);
            foreach (var thisFile in files)
            {
                // Console.WriteLine($"fil : {thisFile} size : {GetFileSizeUsingFileInfo(thisFile).ToString()}");
                Console.WriteLine($"fil : {thisFile} size : {thisFile.GetFileSizeUsingFileInfo().ToString()}");
            }

            var directories = System.IO.Directory.GetDirectories(filePath);
            foreach (var directory in directories)
            {
                FindFiles(directory);
            }
        }
        catch (Exception error)
        {
            Console.WriteLine(error.ToString());
            throw;
        } 
    }

    public static int FindNumberOfSubDirectories(string filePath)
    {
        var subDirectories = System.IO.Directory.GetDirectories(filePath);
        Console.WriteLine($"Antal undermapper i mappen : {filePath} : {subDirectories.Length} ");

        return (subDirectories.Length);
    }
    
    public static long GetFileSizeUsingFileInfo(string filePath)
    {
        FileInfo fileInfo = new FileInfo(filePath);
        if (fileInfo.Exists)
        {
            return fileInfo.Length;
        }
        else
        {
            // Handle the case where the file doesn't exist
            return -1; // Or throw an exception
        }
    }
}
namespace Metoder.Classes;

public class ClassMethods
{
    private static List<MyFileInfo> myFileInfoList = new List<MyFileInfo>();
    private static List<MyDirectoryAndFilesInfo> myDirectoryAndFilesInfoList = new List<MyDirectoryAndFilesInfo>();

    private static void PrintDirectoryInfo(string filepath)
    {
        long totalFileSize = 0;
        long totalNumberOfFiles = 0;
        
        foreach (var directoryInfo in myDirectoryAndFilesInfoList)
        {
            Console.WriteLine($"Directory {directoryInfo.DiretoryString} indeholder {directoryInfo.NumberOfFilesInDirectory} filer"  +
                              $" med en samlet filstørrelse på : {directoryInfo.TotalSizeOfFilesInDirectory} bytes");
            totalFileSize += directoryInfo.TotalSizeOfFilesInDirectory;
            totalNumberOfFiles += directoryInfo.NumberOfFilesInDirectory;
        }
        Tools.MakeEmptyLines();
        Console.WriteLine($"Total antal filer i {filepath} og underdirektorier : {totalNumberOfFiles}");
        Console.WriteLine($"Total størrelse af filer i {filepath} og underdirektorier : {totalFileSize} bytes");
    }
    
    public static void FindFilesAndDirectoryInfo(string filePath)
    {
        myDirectoryAndFilesInfoList.Clear();
        FindFiles(filePath);

        Tools.MakeEmptyLines(2);
        Console.WriteLine("Usorteret");
        PrintDirectoryInfo(filePath);
        
        Tools.MakeEmptyLines(2);
        Console.WriteLine("Sorteret efter antal Filer");
        myDirectoryAndFilesInfoList.GenericSelectionSort(field => field.NumberOfFilesInDirectory);
        PrintDirectoryInfo(filePath);
        
        Tools.MakeEmptyLines(2);
        Console.WriteLine("Sorteret efter samlet Fil Størrelse");
        myDirectoryAndFilesInfoList.GenericSelectionSort(field => field.TotalSizeOfFilesInDirectory);
        PrintDirectoryInfo(filePath);
    }
    
    public static void FindFiles(string filePath)
    {
        MyFileInfo myFileInfoObject = new MyFileInfo();
        MyDirectoryAndFilesInfo myDirectoryAndFilesInfoObject = new MyDirectoryAndFilesInfo();
        long fileSize;
        long sizeOfFilesInDirectory;
        
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
        FindAndPrintNumberOfSubDirectories(filePath);
        Console.WriteLine("");
        
        try
        {
            myFileInfoList.Clear();
            var files = System.IO.Directory.GetFiles(filePath);
            foreach (var thisFile in files)
            {
                fileSize = thisFile.GetFileSizeUsingFileInfo();
                //Console.WriteLine($"fil : {thisFile} size : {thisFile.GetFileSizeUsingFileInfo().ToString()}");
                Console.WriteLine($"fil : {thisFile} size : {fileSize.ToString()}");

                myFileInfoObject = new MyFileInfo();
                myFileInfoObject.FileName = thisFile;
                myFileInfoObject.FileSize = fileSize;
                myFileInfoList.Add(myFileInfoObject);
            }
            
            Tools.MakeEmptyLines();
            Console.WriteLine($"Files in directory after sorting");
            Tools.MakeEmptyLines();
            myFileInfoList.SelectionSort();
            sizeOfFilesInDirectory = 0;
            
            foreach (var thisFileInfo in myFileInfoList)
            {
                Console.WriteLine($"fil : {thisFileInfo.FileName} size : {thisFileInfo.FileSize.ToString()}");
                sizeOfFilesInDirectory += thisFileInfo.FileSize;
            }
            Tools.MakeEmptyLines();
            Console.WriteLine($"Number of Files in Directory {filePath} : {myFileInfoList.Count}");

            myDirectoryAndFilesInfoObject = new MyDirectoryAndFilesInfo();
            myDirectoryAndFilesInfoObject.DiretoryString = filePath;
            myDirectoryAndFilesInfoObject.NumberOfFilesInDirectory = myFileInfoList.Count;
            myDirectoryAndFilesInfoObject.TotalSizeOfFilesInDirectory = sizeOfFilesInDirectory;
                
            myDirectoryAndFilesInfoList.Add(myDirectoryAndFilesInfoObject);

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

    public static int FindAndPrintNumberOfSubDirectories(string filePath)
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
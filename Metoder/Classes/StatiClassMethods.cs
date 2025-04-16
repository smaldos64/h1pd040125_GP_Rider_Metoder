namespace Metoder.Classes;

public static class StatiClassMethods
{
    public static long GetFileSizeUsingFileInfo(this string filePath)
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
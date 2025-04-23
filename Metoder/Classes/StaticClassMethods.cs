namespace Metoder.Classes;

public static class StaticClassMethods
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
    
    public static void SelectionSort(this List<MyFileInfo> myFileInfoList)
    {
        int n = myFileInfoList.Count;
        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                if (myFileInfoList[j].FileSize < myFileInfoList[minIndex].FileSize)
                {
                    minIndex = j;
                }
            }
            if (minIndex != i)
            {
                Swap(myFileInfoList, i, minIndex);
            }
        }
    }
    
    private static void Swap(List<MyFileInfo> myFileInfolist, int a, int b)
    {
        var temp = myFileInfolist[a];
        myFileInfolist[a] = myFileInfolist[b];
        myFileInfolist[b] = temp;
    }
    
    public static void GenericSelectionSort<T, TKey>(this List<T> list, Func<T, TKey> keySelector) where TKey : IComparable<TKey>
    {
        int n = list.Count;
        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                if (keySelector(list[j]).CompareTo(keySelector(list[minIndex])) < 0)
                {
                    minIndex = j;
                }
            }
            if (minIndex != i)
            {
                (list[i], list[minIndex]) = (list[minIndex], list[i]); // Tuple swap i C# 7+
            }
        }
    }
}
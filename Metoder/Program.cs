using Metoder.Classes;

namespace Metoder;

public interface IPrintableInteger
{
    int IntegerValue { get; }
}

class IntTestClass : IPrintableInteger
{
    public int TestVariable { get; set; }

    //public int IntegerValue => TestVariable;
    
    public int IntegerValue
    {
        get
        {
            return TestVariable;
        }
    }
}

class Program
{
    static int[] intArrayChange = new int[10];
    static List<IntTestClass> intTestCallsListChange = new List<IntTestClass>();
    private static void SwapArrayVariables(int[] arr, int a, int b)
    {
        int temp = arr[a];
        arr[a] = arr[b];
        arr[b] = temp;
    }
    
    private static void SwapArrayVariablesRef(ref int[] arr, int a, int b)
    {
        int temp = arr[a];
        arr[a] = arr[b];
        arr[b] = temp;
    }
    
    private static void SwapArrayVariablesRefChangeAddress(ref int[] arr, int a, int b)
    {
        arr = intArrayChange;
        int temp = arr[a];
        arr[a] = arr[b];
        arr[b] = temp;
    }
    
    private static void SwapArrayVariablesChangeAddress(int[] arr, int a, int b)
    {
        arr = intArrayChange;
        int temp = arr[a];
        arr[a] = arr[b];
        arr[b] = temp;
    }
    
    private static void SwapObjectVariables(List<IntTestClass> intTestClassList, int a, int b)
    {
        var temp = intTestClassList[a].TestVariable;
        intTestClassList[a].TestVariable = intTestClassList[b].TestVariable;
        intTestClassList[b].TestVariable = temp;
    }
    
    private static void SwapObjectVariablesRef(ref List<IntTestClass> intTestClassList, int a, int b)
    {
        var temp = intTestClassList[a].TestVariable;
        intTestClassList[a].TestVariable = intTestClassList[b].TestVariable;
        intTestClassList[b].TestVariable = temp;
    }
    
    private static void SwapObjectVariablesRefChangeAddress(ref List<IntTestClass> intTestClassList, int a, int b)
    {
        intTestClassList = intTestCallsListChange;
        var temp = intTestClassList[a].TestVariable;
        intTestClassList[a].TestVariable = intTestClassList[b].TestVariable;
        intTestClassList[b].TestVariable = temp;
    }
    
    private static void SwapObjectVariablesChangeAddress(List<IntTestClass> intTestClassList, int a, int b)
    {
        intTestClassList = intTestCallsListChange;
        var temp = intTestClassList[a].TestVariable;
        intTestClassList[a].TestVariable = intTestClassList[b].TestVariable;
        intTestClassList[b].TestVariable = temp;
    }
    
    public static void PrintArray(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n; ++i)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine();
    }
    
    public static void PrintList(List<IntTestClass> intTestClassList)
    {
        int n = intTestClassList.Count;
        for (int i = 0; i < n; ++i)
        {
            Console.Write(intTestClassList[i].TestVariable + " ");
        }
        Console.WriteLine();
    }
    
    public static void PrintGenericCollection<T>(IEnumerable<T> samling)
    {
        Console.WriteLine($"Udskriver samling af type: {typeof(T)}");
        foreach (T element in samling)
        {
            if (element is int intValue)
            {
                Console.Write($"{intValue} ");
            }
            else if (element is IPrintableInteger printable)
            {
                Console.Write($"{printable.IntegerValue} ");
            }
            else
            {
                Console.WriteLine($"Advarsel: Element af type {element?.GetType()} kan ikke udskrives.");
            }
        }
        Console.WriteLine();
    }
    
    static void Main(string[] args)
    {
        // int[] intArray = new int[10];
        // List<IntTestClass> intTestCallsList = new List<IntTestClass>();
        // IntTestClass intTestClassObject = new IntTestClass();
        //
        // for (int counter = 0; counter < intArray.Length; counter++)
        // {
        //     intArray[counter] = counter + 1;
        //     intTestClassObject = new IntTestClass();
        //     intTestClassObject.TestVariable = counter + 1;
        //     intTestCallsList.Add(intTestClassObject);
        //     
        //     intTestClassObject = new IntTestClass();
        //     intTestClassObject.TestVariable = (counter + 1) * 4;
        //     intTestCallsListChange.Add(intTestClassObject);
        //
        //     intArrayChange[counter] = (counter + 1) * 4;
        // }
        // Console.WriteLine("Array efter initalisering :");
        // //PrintArray(intArray);
        // PrintGenericCollection(intArray);
        //
        // SwapArrayVariables(intArray, 0, 1);
        // Console.WriteLine("Array efter ombytning uden brug af ref :");
        // //PrintArray(intArray);
        // PrintGenericCollection<int>(intArray);
        //
        // SwapArrayVariablesRef(ref intArray, 2, 3);
        // Console.WriteLine("Array efter ombytning ved brug af ref :");
        // //PrintArray(intArray);
        // PrintGenericCollection<int>(intArray);
        //
        // SwapArrayVariablesChangeAddress(intArray, 4, 5);
        // Console.WriteLine("Array efter adresse allokering til nyt array uden brug af ref :");
        // //PrintArray(intArray);
        // PrintGenericCollection<int>(intArray);
        //
        // SwapArrayVariablesRefChangeAddress(ref intArray, 4, 5);
        // Console.WriteLine("Array efter adresse allokering til nyt array ved brug af ref :");
        // //PrintArray(intArray);
        // PrintGenericCollection<int>(intArray);
        //
        // Console.WriteLine("Liste efter initalisering :");
        // //PrintList(intTestCallsList);
        // PrintGenericCollection(intTestCallsList);
        //
        // SwapObjectVariables(intTestCallsList, 0, 1);
        // Console.WriteLine("Liste efter ombytning uden brug af ref :");
        // //PrintList(intTestCallsList);
        // PrintGenericCollection(intTestCallsList);
        //
        // SwapObjectVariablesRef(ref intTestCallsList, 2, 3);
        // Console.WriteLine("Liste efter ombytning ved brug af ref :");
        // //PrintList(intTestCallsList);
        // PrintGenericCollection<IntTestClass>(intTestCallsList);
        //
        // SwapObjectVariablesChangeAddress(intTestCallsList, 4, 5);
        // Console.WriteLine("Liste efter adresse allokering til ny liste uden brug af ref :");
        // //PrintList(intTestCallsList);
        // PrintGenericCollection<IntTestClass>(intTestCallsList);
        //
        // SwapObjectVariablesRefChangeAddress(ref intTestCallsList, 4, 5);
        // Console.WriteLine("Liste efter adresse allokering til ny liste ved brug af ref :");
        // //PrintList(intTestCallsList);
        // PrintGenericCollection<IntTestClass>(intTestCallsList);
        
        ClassMethods.FindFiles("c:\\Lars\\Mappe_Test");
        Console.WriteLine("");
        Console.WriteLine("");
        ClassMethods.FindAndPrintNumberOfSubDirectories("c:\\Lars\\Mappe_Test");
        
        ClassMethods.FindFilesAndDirectoryInfo("c:\\Lars\\Mappe_Test");
    }
}
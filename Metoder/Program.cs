using Metoder.Classes;

namespace Metoder;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        //ClassMethods.FindFiler("c:\\Lars");
        //ClassMethods.FindFiler("c:\\Lars\\Embedded");
        //ClassMethods.FindFiler("c:\\Lars\\Embedded_Udvikling");
        ClassMethods.FindFiles("c:\\Lars\\Mappe_Test");
        Console.WriteLine("");
        Console.WriteLine("");
        ClassMethods.FindNumberOfSubDirectories("c:\\Lars\\Mappe_Test");
    }
}
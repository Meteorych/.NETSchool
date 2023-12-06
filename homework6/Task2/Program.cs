using System.Diagnostics;

namespace Task2;

internal class Program
{
    static void Main(string[] args)
    { 
        var sw = Stopwatch.StartNew();
        sw.Start();
        var result = GcdAsync.Gcd(1234567890, 63018038201).Result;
        Console.WriteLine(sw.ElapsedMilliseconds);
        sw.Stop();
        Console.WriteLine(result);
        Console.ReadLine();
    }

        
}
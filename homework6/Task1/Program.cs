namespace Task1;

internal class Program
{
    static void Main()
    {
        var testCache = new Cache(10);
        testCache.Set("1", "first");
        testCache.Set("2", "second");
        testCache.Set("3", "third");
        Console.WriteLine(testCache.Get("3"));
        var removed = testCache.Remove("key3");
        Console.WriteLine(removed);
        removed = testCache.Remove("3");
        Console.WriteLine(removed);
        Thread.Sleep(15000);
        Console.WriteLine(testCache.Get("2"));
    }
}
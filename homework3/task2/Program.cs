
internal class Program
{
    static void Main()
    {
        var queue = new Queue<int>(4);
        Console.WriteLine(queue.IsEmpty);
        queue.Enqueue(1);
        queue.Enqueue(3);
        queue.Enqueue(5);
        queue.Enqueue(7);
        Console.WriteLine(queue.IsEmpty);
        var tail = queue.Tail();
        Console.WriteLine(tail.IsEmpty);
        while (!tail.IsEmpty)
        {
            Console.WriteLine(tail.Dequeue());
        }
        
    }
}

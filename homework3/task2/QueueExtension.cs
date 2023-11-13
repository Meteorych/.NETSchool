public static class QueueExtension
{
    public static IQueue<T> Tail<T>(this IQueue<T> queue) where T : struct
    {
        if (queue.IsEmpty) return new Queue<T>(0);
        queue.Dequeue();
        //Мы наверное не проходили, но реализовал через коллекцию List<T>, потому что не придумал честно говоря, как сделать по-другому,
        //не добавляя новых методов в интерфейс.
        var tempList = new List<T>();
        var size = 0;
        while (!queue.IsEmpty)
        {
            tempList.Add(queue.Dequeue());
            size++;
        }
        IQueue<T> tail = new Queue<T>(size);
        foreach (var item in tempList)
        {
            tail.Enqueue(item);
        }
        return tail;
    }
}


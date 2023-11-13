public class Queue<T> : IQueue<T> where T : struct
{
    private readonly T[] _array;
    private int _head;
    private int _tail;
    private int _size;
    public bool IsEmpty => _size == 0;
    public bool IsFull => _size == _array.Length;
    public Queue(int capacity)
    {
        _array = new T[capacity];
        _size = 0;
        _head = 0;
        _tail = 0;
    }

    public T Dequeue()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("Queue is empty!");
        }
        var item = _array[_head];
        _head = (_head + 1) % _array.Length;
        _size--;
        return item;
    }

    public void Enqueue(T item)
    {
        if (IsFull)
        {
            throw new InvalidOperationException("Queue is full!");
        }
        _array[_tail] = item;
        _tail = (_tail + 1) % _array.Length;
        _size ++;
    }
}


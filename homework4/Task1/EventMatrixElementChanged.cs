namespace Task1;

public class EventMatrixElementChanged<T> : EventArgs
{
    public (int, int) Index { get; }
    public T? OldValue { get; }
    public T NewValue { get; }

    public EventMatrixElementChanged((int, int) index, T? oldValue, T newValue)
    {
        Index = index;
        OldValue = oldValue;
        NewValue = newValue;
    }

}
namespace Task1;
public class DiagonalMatrix<T>
{

    private readonly T?[] _data;

    public event EventHandler<EventMatrixElementChanged<T>>? ElementChanged;

    public int Size => _data.Length;

    public DiagonalMatrix(int dimension)
    {
        if (dimension < 0) throw new ArgumentOutOfRangeException(nameof(dimension));
        _data = new T[dimension];
    }

    public T this[int row, int column]
    {
        get
        {
            CheckIndices(row, column);
            return (row == column ? _data[row] : default)!;
        }
        set
        {
            CheckIndices(row, column);
            var oldValue = _data[row];
            if (row != column || Equals(oldValue, value)) return;
            _data[row] = value;
            OnElementChanged(new EventMatrixElementChanged<T>((row, column), oldValue, value));
        }
    }
    private void OnElementChanged(EventMatrixElementChanged<T> eventArgs)
    {
        ElementChanged?.Invoke(this, eventArgs);
    }

    private void CheckIndices(int i, int j)
    {
        Check(i, nameof(i));
        Check(j, nameof(j));
        return;

        void Check(int index, string indexName)
        {
            if (index < 0 && index > Size)
            {
                throw new ArgumentOutOfRangeException(indexName);
            }
        }
    }
}
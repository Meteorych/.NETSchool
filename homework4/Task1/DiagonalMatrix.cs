namespace Task1;
public class DiagonalMatrix<T>
{
    public int Size { get; }
    private readonly T[] _data;
    public event EventHandler<EventMatrixElementChanged<T>>? ElementChanged;
    public DiagonalMatrix(int dimension)
    {
        if (dimension < 0) throw new ArgumentOutOfRangeException(nameof(dimension));
        Size = dimension;
        _data = new T[Size];
        for (var i = 0; i < Size; i++)
        {
            _data[i] = default;
        }
    }
    public T this[int row, int column]
    {
        get
        {
            if (row >= 0 && row <= Size && column >= 0 && column <= Size)
            {
                return (row == column ? _data[row] : default)!;
            }

            throw new IndexOutOfRangeException("Wrong indexes!");
        }
        set
        {
            if (row >= 0 && row <= Size && column >= 0 && column <= Size)
            {
                if (row != column) return;
                var oldValue = _data[row];
                if (Equals(oldValue, value)) return;
                _data[row] = value;
                OnElementChanged(new EventMatrixElementChanged<T>((row, column), oldValue, value));

            }
            else
            {
                throw new IndexOutOfRangeException("You can't change this element in diagonal matrix!");
            }
        }
    }
    private void OnElementChanged(EventMatrixElementChanged<T> eventArgs)
    {
        ElementChanged?.Invoke(this, eventArgs);
    }
}
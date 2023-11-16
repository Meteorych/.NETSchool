using System.Diagnostics.Contracts;

namespace Task1;

public class MatrixTracker<T>
{
    private readonly DiagonalMatrix<T?> _matrix;
    private EventMatrixElementChanged<T?>[] _stack;

    public MatrixTracker (DiagonalMatrix<T?> diagonalMatrix)
    {
        _matrix = diagonalMatrix ?? throw new ArgumentNullException(nameof(diagonalMatrix));
        _stack = Array.Empty<EventMatrixElementChanged<T?>>();
        _matrix.ElementChanged += Track;

    }

    public void Undo()
    {
        if (_stack.Length == 0)
        {
            return;
        }
        _matrix.ElementChanged -= Track;
        var last = _stack[^1];
        _matrix[last.Index.Item1, last.Index.Item2] = last.OldValue;
        Array.Resize(ref _stack, _stack.Length - 1);
        _matrix.ElementChanged += Track;
    }

    private void Track(object? sender, EventMatrixElementChanged<T?> args)
    {
        Array.Resize(ref _stack, _stack.Length);
        _stack[^1] = args;
    }
}
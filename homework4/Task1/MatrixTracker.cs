using System.Diagnostics.Contracts;

namespace Task1;

public class MatrixTracker<T>
{
    private readonly DiagonalMatrix<T> _matrix;
    private T _oldValue = default;
    private (int, int) _index;
    public MatrixTracker (DiagonalMatrix<T> diagonalMatrix)
    {
        _matrix = diagonalMatrix;
        diagonalMatrix.ElementChanged += delegate(object sender, EventMatrixElementChanged<T> args)
        {
            _oldValue = args.OldValue;
            _index = args.Index;
        };
    }

    public void Undo()
    {
        _matrix[_index.Item1, _index.Item2] = _oldValue;
    }

}
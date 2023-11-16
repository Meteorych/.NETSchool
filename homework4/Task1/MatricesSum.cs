namespace Task1;

public static class MatricesSum
{
    public static void Sum<T>(this DiagonalMatrix<T?> matrix1, DiagonalMatrix<T> matrix2, Func<T?, T?, T?> matricesElementsSum) 
    {
        for (var i = 0; i <  Math.Min(matrix1.Size, matrix2.Size); i++)
        {
            matrix1[i, i] = matricesElementsSum(matrix1[i, i], matrix2[i, i]);
        }
    }
}
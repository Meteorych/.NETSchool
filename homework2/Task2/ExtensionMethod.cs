namespace Task2
{
    public static class ExtensionMethod
    {
        public static DiagonalMatrix SumOfMatrices(this DiagonalMatrix matrix1, DiagonalMatrix matrix2)
        {
            if (matrix1.Size > matrix2.Size)
            {
                for (var i = matrix2.Size; i < matrix1.Size; i++)
                {
                    matrix2[i, i] = 0;
                }
            }
            else if (matrix2.Size > matrix1.Size) 
            {
                for (var i = matrix1.Size; i < matrix2.Size; i++)
                {
                    matrix1[i, i] = 0;
                }
            }
            var resultElements = new int[matrix1.Size];
            for (var i = 0; i < matrix1.Size; i++)
            {
                resultElements[i] = matrix1[i, i] + matrix2[i, i];
            }
            return new DiagonalMatrix(resultElements);
        }
    }
}

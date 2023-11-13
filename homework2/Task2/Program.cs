namespace Task2
{
    public class Program
    {
        static void Main()
        {
            var matrix1 = new DiagonalMatrix();
            Console.WriteLine(matrix1.Size);
            var matrix2 = new DiagonalMatrix(1, 2, 3, 4, 5);
            var matrix3 = new DiagonalMatrix(1, 2, 3, 4, 5);
            Console.WriteLine(matrix1.Equals(matrix2));
            Console.WriteLine(matrix2.Equals(matrix3));
            Console.WriteLine(matrix3[1, 1] + " " + matrix3[1, 2]);
            Console.WriteLine(matrix3.Track());
            Console.WriteLine($"Sum of matrices:\n{matrix3.SumOfMatrices(matrix2)}");
        }
    }
}
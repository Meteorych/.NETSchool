using System.Security.Cryptography.X509Certificates;

namespace Task1;
internal class Program
{
    static void Main()
    {
        var matrix1 = new DiagonalMatrix<int>(5);
        var matrix2 = new DiagonalMatrix<int>(3);
        matrix1.ElementChanged += ((sender, args) => Console.WriteLine($"Index: {args.Index}, Old value: {args.OldValue}, New value:" +
                                                                       $"{args.NewValue}"));
        var matrix1Tracker = new MatrixTracker<int>(matrix1);
        matrix1[0, 1] = 12;
        matrix1[1, 1] = 34;
        matrix1[2, 2] = 51;
        matrix1Tracker.Undo();
        matrix2[2, 2] = 55;
        int DoOperation(int n1, int n2) => n1 + n2;
        matrix1.Sum(matrix2, DoOperation);
    }

}

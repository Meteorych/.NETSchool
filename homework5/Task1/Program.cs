namespace Task1
{
    internal class Program
    {
        static void Main()
        {
            var testMatrix = new SparseMatrix(50, 50)
            {
                [0, 0] = 55,
                [13, 0] = 55,
                [0, 1] = 2003,
                [5, 1] = 416,
                [49, 49] = 789
            };
            Console.WriteLine(testMatrix[10, 49]);
            Console.WriteLine(testMatrix[25, 31]);
            Console.WriteLine(testMatrix);
            //foreach (var VARIABLE in testMatrix)
            //{
            //    Console.Write(VARIABLE.ToString());
            //}
            foreach (var nonZeroElement in testMatrix.GetNonZeroElements())
            {
                Console.WriteLine(nonZeroElement);
            }

            Console.WriteLine(testMatrix.GetCount(55));
            Console.WriteLine(testMatrix.GetCount(0));
        }
    }
}
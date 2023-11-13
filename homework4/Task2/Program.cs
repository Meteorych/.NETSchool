namespace Task2
{
    internal class Program
    {
        static void Main()
        {
            var number2 = new RationalNumber(25, 5);
            var number3 = new RationalNumber(6, 16);
            var comparing = number2.CompareTo(number3);
            var equal = number2.Equals(new RationalNumber(1,5));
            var doubleNum = (double)number3;
            var doubleNum2 = (double)number2;
            var intRationalNum = (RationalNumber)15;
            var number4 = number2 + number3;
            var number5 = number2 - number4;
            var number6 = number2/number4;
            var number7 = number2*number4;
            Console.WriteLine(number7);
        }
    }
}
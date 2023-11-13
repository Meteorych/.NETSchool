using System.Diagnostics;

namespace Project1
{
    internal class Program
    {
        static void Main()
        {
            const string twelveDigits = "0123456789AB";
            Console.WriteLine("Enter number a");
            var a = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter number b");
            var b = int.Parse(Console.ReadLine());
            if (b <= a)
            {
                var temp = b;
                b = a;
                a = temp;
            }
            for (var i = a; i <= b; i++)
            {
                var temp = i;
                var twelveRepresentation = "";
                while (temp > 0)
                {
                    var surplus = temp % 12;
                    twelveRepresentation = twelveDigits[surplus] + twelveRepresentation;
                    temp /= 12;
                }

                var countA = 0;
                foreach (var digit in twelveRepresentation)
                {
                    if (digit == 'A')
                    {
                        countA++;
                    }
                }
                
                if (countA == 2)
                {
                    Console.WriteLine($"{i}");
                } 
            }
        }

    }
}
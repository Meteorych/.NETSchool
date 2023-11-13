using System.Runtime.InteropServices;

namespace Project3
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter the size of array: ");
            var size = int.Parse(Console.ReadLine());
            var array = new int[size];
            for (var i = 0; i < size; i++)
            {
                Console.WriteLine($"Enter element number {i}");
                array[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Beginning array:");
            foreach (var number in array)
            {
                Console.Write($"{number}");
            }
            var resultArray = new int[size];
            var resIndex = 0;
            for (var index = 0; index < array.Length - 1; index++)
            {
                var isUnique = true;
                for (var j = index + 1; j < size; j++)
                {
                    if (array[index] != array[j]) continue;
                    isUnique = false;
                    break;
                }
                if (!isUnique) continue;
                resultArray[resIndex] = array[index];
                resIndex++;
            }

            resultArray = resultArray[..resIndex];
            Console.WriteLine("\nResult array:");
            foreach (var number in resultArray)
            {
                Console.Write($"{number}");
            }
            
        }
    }
}
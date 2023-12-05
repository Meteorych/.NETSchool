using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class FactorizationAsync
    {
        public static Task<List<BigInteger>> Factorization(BigInteger n)
        {
            var tcs = new TaskCompletionSource<List<BigInteger>>();
            if (n <= 2) throw new ArgumentException("Wrong value of digit!");
            var divider = new BigInteger(2);
            var result = new List<BigInteger>();
            while (n > 1)
            {
                if ((n % divider) == 0)
                {
                    Console.WriteLine(divider);
                    result.Add(divider);
                    n /= divider;
                }
                else
                {
                    divider++;
                }
            }
            return result;
        }
    }
}

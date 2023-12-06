using System.Numerics;

namespace Task2;

internal class FactorizationSync
{
    public static List<BigInteger> Factorization(BigInteger n)
    {
        if (n <= 2) throw new ArgumentException("Wrong value of digit!");
        var result = new List<BigInteger>();
        for (BigInteger i = 2; i <= n; i++)
        {
            while (n % i == 0)
            {
                result.Add(i);
                n /= i;
            }
        }
        return result;
    }
}
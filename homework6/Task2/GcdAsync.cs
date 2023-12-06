using System.Numerics;

namespace Task2;

public class GcdAsync
{
    public static Task<BigInteger> Gcd(BigInteger number1, BigInteger number2)
    {
        var tcs = new TaskCompletionSource<BigInteger>();
        try
        {
            var factorsATask = FactorizationAsync.Factorization(number1);
            var factorsBTask = FactorizationAsync.Factorization(number2);
                
            Task.WhenAll(factorsATask, factorsBTask);
                

            var factorsA = factorsATask.Result;
            var factorsB = factorsBTask.Result;

            var commonFactors = GetCommonFactors(factorsA, factorsB);

            BigInteger gcd = 1;
            foreach (var factor in commonFactors)
            {
                gcd *= factor;
            }

            tcs.SetResult(gcd);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            tcs.SetException(e);
        }

        return tcs.Task;
    }

    static IEnumerable<BigInteger> GetCommonFactors(List<BigInteger> list1, List<BigInteger> list2)
    {
        var set = new HashSet<BigInteger>(list1);

        foreach (var num in list2)
        {
            if (!set.Contains(num)) continue;
            yield return num;
            set.Remove(num);
        }
    }
}
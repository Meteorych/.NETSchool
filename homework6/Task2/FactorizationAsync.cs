using System.Numerics;

namespace Task2
{
    public class FactorizationAsync
    {
        public static Task<List<BigInteger>> Factorization(BigInteger n)
        {
            var tcs = new TaskCompletionSource<List<BigInteger>>();
            var result = new List<BigInteger>();
            BigInteger maxFactor;
            //Понимаю, что за такое скорее всего снизят балл, но не нашёл способ снизить количество циклов, не прибегая к сложным побитовым операциям, а без снижения
            //время выполнения даже с разделением по процессорам было слишком большим:((
            if (n.Equals((BigInteger)(double)n))
            {
                maxFactor = (BigInteger)Math.Sqrt((double)n);
            }
            else
            {
                maxFactor = n;
            }
            var threadCount = Environment.ProcessorCount; // Количество доступных потоков
            var tasks = new Task[threadCount]; // Массив задач

            for (var i = 0; i < threadCount; i++)
            {
                tasks[i] = Task.Run(() =>
                {
                    BigInteger start = 2 + i;
                    for (var i = start; i <= maxFactor; i += threadCount)
                    {
                        while (n % i == 0)
                        {
                            lock (result)
                            {
                                result.Add(i);
                            }

                            n /= i;
                        }
                    }

                    if (n <= 1) return;
                    lock (result)
                    {
                        result.Add(n);
                    }
                });
            }
            Console.WriteLine();
            Task.WaitAll(tasks);
            tcs.SetResult(result);
            return tcs.Task;
        }
    }
}

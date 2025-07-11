using HandEvaluator.Models;
using System.Diagnostics;

namespace HandEvaluatorBenchmarkRunner;

public static class BenchmarkRunner
{
    private const int iterations = 10_000_000;
    private static readonly int[] indexes = [.. Enumerable.Range(0, 52)];

    public static void BenchmarkMethod(string methodName, Delegate methodDelegate, int numberOfCards)
    {
        var random = new Random(0);
        var stopwatch = new Stopwatch();

        for (int i = 0; i < iterations; i++)
        {
            var randomIndexes = indexes.OrderBy(_ => random.Next()).Take(numberOfCards).ToArray();
            ulong handValue = 0;

            foreach (var index in randomIndexes)
            {
                handValue |= 1UL << index;
            }

            stopwatch.Start();

            switch (methodDelegate)
            {
                case Func<ulong, uint> evaluate:
                    evaluate(handValue);
                    break;
                case Func<ulong, HandTypes> evaluateType:
                    evaluateType(handValue);
                    break;
                default:
                    throw new NotSupportedException("Unsupported delegate type");
            }

            stopwatch.Stop();
        }

        Console.WriteLine($"{numberOfCards}-Card {methodName}()");
        double handsPerSecond = iterations / stopwatch.Elapsed.TotalSeconds;
        Console.WriteLine($"{handsPerSecond:N0} hands per second");
    }
}

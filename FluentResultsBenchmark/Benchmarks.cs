namespace FluentResultsBenchmark;

using BenchmarkDotNet.Attributes;
using FluentResults;

public class Benchmarks
{
    [Benchmark]
    public void TestWith_FluentResults()
    {
        var result = GetRandomEven();

        if (result.IsFailed)
        {
            Console.WriteLine("Failed");
        }

        Console.WriteLine($"Random even: {result.Value}");
    }

    private static Result<long> GetRandomEven()
    {
        var random = Random.Shared.NextInt64();

        return random % 2 == 0
            ? random
            : Result.Fail("Not even");
    }
}

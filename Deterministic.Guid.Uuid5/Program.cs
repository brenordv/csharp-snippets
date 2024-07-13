using System.Diagnostics;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Deterministic.Guid.Uuid5;

Console.WriteLine("Deterministic Guid (UUID v5)");

#if DEBUG
Console.WriteLine("Initiating manual tests...");

const int iterationsForTimeMeasurement = 1_000_000;
const int iterationsForCollisionTest = 100_000_000;

var stopwatch = new Stopwatch();
stopwatch.Start();

Console.WriteLine($"Measuring time to generate {iterationsForTimeMeasurement} UUIDs...");
for (var i = 0; i < iterationsForTimeMeasurement; i++)
{
    Uuid5.NewGuid("example", i);
}
stopwatch.Stop();
Console.WriteLine($"Done! Elapsed time: {stopwatch.Elapsed}");

Console.WriteLine("Testing for collisions...");

stopwatch.Restart();

var collisionTest = new Guid[iterationsForCollisionTest];
Parallel.ForEach(Enumerable.Range(0, iterationsForCollisionTest), i =>
{
    collisionTest[i] = Uuid5.NewGuid("parallel ops", i);
});
var distinctCount = collisionTest.Distinct().Count();
stopwatch.Stop();
Console.WriteLine($"Done! Found {collisionTest.Length - distinctCount} collisions. Elapsed Time: {stopwatch.Elapsed}");

#else
Console.WriteLine("Running benchmarks...");
BenchmarkRunner.Run<GuidBenchmark>();
#endif

[MemoryDiagnoser(false), MaxColumn, MeanColumn, MedianColumn, RankColumn]
public class GuidBenchmark
{
    [Params(1_000_000)]
    public int IterationCount;
    
    [Benchmark]
    public void UuidV4()
    {
        for (var i = 0; i < IterationCount; i++)
        {
            Guid.NewGuid();
        }
    }
    
    [Benchmark]
    public void UuidV5()
    {
        for (var i = 0; i < IterationCount; i++)
        {
            Uuid5.NewGuid(i, 42);
        }
    }
}

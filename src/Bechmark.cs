using System;
using System.Diagnostics;

public static class Benchmark
{
    /// <summary>
    /// Measures the execution time of a single action.
    /// </summary>
    /// <param name="action">The action to benchmark.</param>
    /// <param name="iterations">Number of times to run the action (default: 1).</param>
    /// <returns>The elapsed time in milliseconds.</returns>
    public static double Measure(int iterations, Action action)
    {
        if (action == null)
            throw new ArgumentNullException(nameof(action));

        if (iterations < 1)
            throw new ArgumentOutOfRangeException(nameof(iterations), "Iterations must be at least 1.");

        // warmup
        action();

        var stopwatch = Stopwatch.StartNew();
        for (int i = 0; i < iterations; i++)
            action();
        stopwatch.Stop();

        return stopwatch.Elapsed.TotalMilliseconds / iterations;
    }

    /// <summary>
    /// Compares the execution time of two actions.
    /// </summary>
    /// <param name="action1">The first action to benchmark.</param>
    /// <param name="action2">The second action to benchmark.</param>
    /// <param name="iterations">Number of times to run each action (default: 1).</param>
    public static void Compare(Action action1, Action action2, int iterations = 1)
    {
        if (action1 == null || action2 == null)
            throw new ArgumentNullException("Actions cannot be null.");

        Console.WriteLine("Benchmarking...");

        var time1 = Measure(iterations, action1);
        var time2 = Measure(iterations, action2);

        Console.WriteLine($"Action 1: {time1:F3} ms (average)");
        Console.WriteLine($"Action 2: {time2:F3} ms (average)");

        if (Math.Abs(time1 - time2) < 0.01)
            Console.WriteLine("Both actions have similar performance.");
        else
            Console.WriteLine(time1 < time2 ? "Action 1 is faster." : "Action 2 is faster.");
    }
}
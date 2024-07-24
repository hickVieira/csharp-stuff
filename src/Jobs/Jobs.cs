
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Jobs;

public static class test
{
    public static void run()
    {
        const int arraySize = 1024 * 1024 * 4;
        var arr = new int[arraySize];

        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < arraySize; ++i)
                arr[i] = i;
            timer.Stop();

            Console.WriteLine($"for - {timer.Elapsed.TotalMilliseconds}ms");
        }

        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < arraySize; i += 2)
            {
                arr[i + 0] = i + 0;
                arr[i + 1] = i + 1;
            }
            timer.Stop();

            Console.WriteLine($"for2 - {timer.Elapsed.TotalMilliseconds}ms");
        }

        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < arraySize; i += 4)
            {
                arr[i + 0] = i + 0;
                arr[i + 1] = i + 1;
                arr[i + 2] = i + 2;
                arr[i + 3] = i + 3;
            }
            timer.Stop();

            Console.WriteLine($"for4 - {timer.Elapsed.TotalMilliseconds}ms");
        }

        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < arraySize; i += 8)
            {
                arr[i + 0] = i + 0;
                arr[i + 1] = i + 1;
                arr[i + 2] = i + 2;
                arr[i + 3] = i + 3;
                arr[i + 4] = i + 4;
                arr[i + 5] = i + 5;
                arr[i + 6] = i + 6;
                arr[i + 7] = i + 7;
            }
            timer.Stop();

            Console.WriteLine($"for8 - {timer.Elapsed.TotalMilliseconds}ms");
        }

        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i < arraySize; i += 16)
            {
                arr[i + 0] = i + 0;
                arr[i + 1] = i + 1;
                arr[i + 2] = i + 2;
                arr[i + 3] = i + 3;
                arr[i + 4] = i + 4;
                arr[i + 5] = i + 5;
                arr[i + 6] = i + 6;
                arr[i + 7] = i + 7;
                arr[i + 8] = i + 8;
                arr[i + 9] = i + 9;
                arr[i + 10] = i + 10;
                arr[i + 11] = i + 11;
                arr[i + 12] = i + 12;
                arr[i + 13] = i + 13;
                arr[i + 14] = i + 14;
                arr[i + 15] = i + 15;
            }
            timer.Stop();

            Console.WriteLine($"for16 - {timer.Elapsed.TotalMilliseconds}ms");
        }

        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            foreach (var i in arr)
                arr[i] = i;
            timer.Stop();

            Console.WriteLine($"foreach - {timer.Elapsed.TotalMilliseconds}ms");
        }

        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            Parallel.For(0, arraySize, i => arr[i] = i);
            timer.Stop();

            Console.WriteLine($"Parallel.For - {timer.Elapsed.TotalMilliseconds}ms");
        }

        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            Parallel.ForEach(Enumerable.Range(0, arraySize), i => arr[i] = i);
            timer.Stop();

            Console.WriteLine($"Parallel.ForEach - {timer.Elapsed.TotalMilliseconds}ms");
        }

        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            Parallel.ForAsync(0, arraySize, async (i, _) => await Task.Run(() => arr[i] = i)).Wait();
            timer.Stop();

            Console.WriteLine($"Parallel.ForAsync - {timer.Elapsed.TotalMilliseconds}ms");
        }

        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            Parallel.ForEachAsync(Enumerable.Range(0, arraySize), async (i, _) => await Task.Run(() => arr[i] = i)).Wait();
            timer.Stop();

            Console.WriteLine($"Parallel.ForEachAsync - {timer.Elapsed.TotalMilliseconds}ms");
        }
    }
}
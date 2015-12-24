using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Compose.Benchmarks
{
    internal class Utilities
    {
        public static Resultset Measure(string name, int repititions, Action action)
        {
            // NOTE(Dan): Run to warmup as the first run is always much slower due to not being JIT'd etc.
            action();

            var results = new double[repititions];

            var stopwatch = Stopwatch.StartNew();

            for (var i = 0; i < repititions; i++)
            {
                var perActionStopwatch = Stopwatch.StartNew();

                action();

                results[i] = perActionStopwatch.Elapsed.TotalMilliseconds;
            }

            stopwatch.Stop();

            return new Resultset(name, results.Min(), results.Max(), results.Average(), stopwatch.Elapsed.TotalMilliseconds);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Compose.Benchmarks
{
    internal class Resultset
    {
        public string Name { get; }
        public double Min { get; }
        public double Max { get; }
        public double Average { get; }
        public double Total { get; }

        public Resultset(string name, double min, double max, double average, double total)
        {
            Name = name;
            Min = min;
            Max = max;
            Average = average;
            Total = total;
        }
    }
}

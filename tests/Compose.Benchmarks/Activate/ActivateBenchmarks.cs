using System;
using System.Diagnostics;
using System.Reflection;
using TestAttributes;
using Xunit;

namespace Compose.Benchmarks.ActivateBenchmarks
{
    public class ActivateBenchmarks
    {
        [Unit]
        public void WithParameterlessConstructor()
        {
            var results = Utilities.Measure("Activate - No Params", 10000, () =>
            {
                Activate.Type(typeof(TestClass).GetTypeInfo());
            });

            Trace.WriteLine($"{results.Name} | Min: {results.Min} | Max: {results.Max} | Avg: {results.Average}");
        }

        [Unit]
        public void WithSingleParameterConstructor()
        {
            var results = Utilities.Measure("Activate - Single Params", 10000, () =>
            {
                Activate.Type(typeof(TestClass).GetTypeInfo(), string.Empty);
            });

            Trace.WriteLine($"{results.Name} | Min: {results.Min} | Max: {results.Max} | Avg: {results.Average}");
        }

        [Unit]
        public void WithMultipleParameterConstructor()
        {
            var results = Utilities.Measure("Activate - Multiple Params", 10000, () =>
            {
                Activate.Type(typeof(TestClass).GetTypeInfo(), string.Empty, 1, 10M);
            });

            Trace.WriteLine($"{results.Name} | Min: {results.Min} | Max: {results.Max} | Avg: {results.Average}");
        }
    }

    public class NewBaselineBenchmarks
    {
        [Unit]
        public void WithParameterlessConstructor()
        {
            var results = Utilities.Measure("new - No Params", 10000, () =>
            {
                new TestClass();
            });

            Trace.WriteLine($"{results.Name} | Min: {results.Min} | Max: {results.Max} | Avg: {results.Average}");
        }

        [Unit]
        public void WithSingleParameterConstructor()
        {
            var results = Utilities.Measure("new - Single Params", 10000, () =>
            {
                new TestClass(string.Empty);
            });

            Trace.WriteLine($"{results.Name} | Min: {results.Min} | Max: {results.Max} | Avg: {results.Average}");
        }

        [Unit]
        public void WithMultipleParameterConstructor()
        {
            var results = Utilities.Measure("new - Multiple Params", 10000, () =>
            {
                new TestClass(string.Empty, 1, 10M);
            });

            Trace.WriteLine($"{results.Name} | Min: {results.Min} | Max: {results.Max} | Avg: {results.Average}");
        }
    }

    public class ActivatorBenchmarks
    {
        [Unit]
        public void WithParameterlessConstructor()
        {
            var results = Utilities.Measure("Activator - No Params", 10000, () =>
            {
                Activator.CreateInstance<TestClass>();
            });

            Trace.WriteLine($"{results.Name} | Min: {results.Min} | Max: {results.Max} | Avg: {results.Average}");
        }

        [Unit]
        public void WithSingleParameterConstructor()
        {
            var results = Utilities.Measure("Activator - Single Params", 10000, () =>
            {
                Activator.CreateInstance(typeof(TestClass), string.Empty);
            });

            Trace.WriteLine($"{results.Name} | Min: {results.Min} | Max: {results.Max} | Avg: {results.Average}");
        }

        [Unit]
        public void WithMultipleParameterConstructor()
        {
            var results = Utilities.Measure("Activator - Multiple Params", 10000, () =>
            {
                Activator.CreateInstance(typeof(TestClass), string.Empty, 1, 10M);
            });

            Trace.WriteLine($"{results.Name} | Min: {results.Min} | Max: {results.Max} | Avg: {results.Average}");
        }
    }

    internal class TestClass
    {
        public TestClass() { }
        public TestClass(string value) { }
        public TestClass(string value, int count, decimal blah) { }

    }
}

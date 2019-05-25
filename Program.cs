using System;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using testStupidXmlParsing;

namespace runner
{
    using System;
    using System.Security.Cryptography;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Running;

    namespace MyBenchmarks
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                var summary = BenchmarkRunner.Run<Benchmark>();
            }
        }
    }

}

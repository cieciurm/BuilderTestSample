using System;

namespace BuilderTestSample.Tests.TestBuilders
{
    public class RandomValue
    {
        public static string String => Guid.NewGuid().ToString();
        public static int Int32 => new Random().Next();
        public static int Int32WithMinValue(int minVal) => new Random().Next(minVal, Int32.MaxValue);
        public static decimal Decimal => Convert.ToDecimal(new Random().Next());
    }
}

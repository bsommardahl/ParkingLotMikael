using System;
using System.Collections.Generic;
using System.Linq;

namespace TestProject1
{
    public static class ContractTestExtension
    {

        public static void ValueShouldBe<T>(this IEnumerable<T> results, T expectedValue)
        {
            var message = string.Empty;

            var allMatches = results.All(x => x.Equals(expectedValue));
            if (allMatches) return;
            message = results.Aggregate(message, (current, result) => current + $"Expected: {expectedValue}, but was {result}" + Environment.NewLine);
            throw new Exception("Contract test failed because not all values was the same" + Environment.NewLine + message);
        }
    }
}
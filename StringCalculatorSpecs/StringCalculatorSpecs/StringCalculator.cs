using System;
using System.Linq;

namespace StringCalculatorSpecs {
    public abstract class StringCalculator {
        public static int Add(string numbers) {
            var separator = ",";
            if (numbers == string.Empty) return 0;
            if (HasOnlyOneNumber(numbers)) return int.Parse(numbers);
            if (HasSpecificSeparator(numbers)) {
                separator = numbers.Substring(2, 1);
                var endDelimiter = numbers.IndexOf("\n", StringComparison.Ordinal);
                if (separator == "[") {
                    var pos = numbers.IndexOf("]", 2, StringComparison.Ordinal);
                    separator = numbers.Substring(3, pos - 3);
                }
                numbers = numbers.Substring(endDelimiter + 1);
            }
            if (numbers.Contains("\n")) separator = "\n";
            var intNumbers = numbers.Replace(separator, ",")
                                                .Split(",")
                                                .Select(int.Parse)
                                                .Where(x => x <= 1000);
            var negativeNumbers = intNumbers.Where(i => i < 0).Select(x => Convert.ToString(x)); ;
            if (negativeNumbers.Any()) throw new Exception($"Negatives not allowed ({string.Join(",", negativeNumbers) })");
            return intNumbers.Sum();
        }

        private static bool HasSpecificSeparator(string numbers) {
            return numbers.Contains("//");
        }

        private static bool HasOnlyOneNumber(string numbers) {
            return !numbers.Contains(",") && !numbers.Contains("\n");
        }
    }
}
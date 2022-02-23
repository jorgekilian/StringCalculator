using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorSpecs {
    public abstract class StringCalculator {
        public static int Add(string numbers) {
            var separator = new List<string>();
            if (numbers == string.Empty) return 0;
            if (HasOnlyOneNumber(numbers)) return int.Parse(numbers);
            if (HasSpecificSeparator(numbers)) {
                var endDelimiter = numbers.IndexOf("\n", StringComparison.Ordinal);
                var separatorString = numbers.Substring(2, endDelimiter - 2);
                var beginDelimiter = separatorString.IndexOf("[", StringComparison.Ordinal);
                if (beginDelimiter > -1) {
                    while (separatorString.IndexOf("]", StringComparison.Ordinal) > -1) {
                        separator.Add(separatorString.Substring(1, separatorString.IndexOf("]", StringComparison.Ordinal) - 1));
                        separatorString = separatorString.Substring(separatorString.IndexOf("]", StringComparison.Ordinal) + 1);
                    }
                }
                else {
                    separator.Add(numbers.Substring(2, 1));
                }
                numbers = numbers.Substring(endDelimiter + 1);
            }
            if (numbers.Contains("\n")) separator.Add("\n");

            if (separator.Count > 0) {
                foreach (var sep in separator) {
                    numbers = numbers.Replace(sep, ",");
                }
            }
            var intNumbers = numbers.Split(",")
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
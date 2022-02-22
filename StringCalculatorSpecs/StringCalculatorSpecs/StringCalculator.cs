using System;
using System.Linq;

namespace StringCalculatorSpecs {
    public abstract class StringCalculator {
        public static int Add(string numbers) {
            var separator = ",";
            if (numbers == string.Empty) return 0;
            if (!numbers.Contains(",") && !numbers.Contains("\n")) return int.Parse(numbers);
            if (numbers.Contains("//")) {
                separator = numbers.Substring(2, 1);
                numbers = numbers.Substring(4);
            }
            if (numbers.Contains("\n")) separator = "\n";
            numbers = numbers.Replace(separator, ",");
            var intNumbers = numbers.Split(",").Select(int.Parse);
            if (intNumbers.Any(i => i < 0)) throw new Exception("Negatives not allowed");
            return intNumbers.Sum();
        }
    }
}
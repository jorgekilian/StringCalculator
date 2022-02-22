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
            var intNumbers = numbers.Split(",").Select(int.Parse).Where(x => x <= 1000);
            var negativeNumbers = intNumbers.Where(i => i < 0).Select(x => Convert.ToString(x)); ;
            if (negativeNumbers.Any()) throw new Exception($"Negatives not allowed ({string.Join(",", negativeNumbers) })");
            return intNumbers.Sum();
        }
    }
}
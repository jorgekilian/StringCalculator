using System.Linq;

namespace StringCalculatorSpecs {
    public abstract class StringCalculator {
        public static int Add(string numbers) {
            if (numbers == string.Empty) return 0;
            if (!numbers.Contains(",") && !numbers.Contains("\n")) return int.Parse(numbers);
            if (numbers.Contains("//")) {
                var separator = numbers.Substring(2, 1);
                numbers = numbers.Substring(4);
                numbers = numbers.Replace(separator, ",");
            }
            if (numbers.Contains("\n")) numbers = numbers.Replace("\n", ",");
            return numbers.Split(",").Sum(int.Parse);
        }
    }
}
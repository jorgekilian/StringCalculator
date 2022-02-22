using System.Linq;

namespace StringCalculatorSpecs {
    public abstract class StringCalculator {
        public static int Add(string numbers) {
            var separator = ",";
            if (numbers == string.Empty) return 0;
            if (!numbers.Contains(",") && !numbers.Contains("\n")) return int.Parse(numbers);
            if (numbers.Contains("//")) {
                separator = ";";
                numbers = numbers.Substring(4);
            }
            if (numbers.Contains("\n")) separator = "\n";
            numbers = numbers.Replace(separator, ",");
            return numbers.Split(",").Sum(int.Parse);
        }
    }
}
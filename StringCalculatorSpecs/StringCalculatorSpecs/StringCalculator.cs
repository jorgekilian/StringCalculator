using System.Linq;
using System.Threading.Channels;
using Microsoft.VisualBasic;

namespace StringCalculatorSpecs {
    public abstract class StringCalculator {
        public static int Add(string numbers) {
            if (numbers == string.Empty) return 0;
            if (!numbers.Contains(",")) return int.Parse(numbers);
            if (numbers.Contains("\n")) numbers = numbers.Replace("\n", ",");
            return numbers.Split(",").Sum(int.Parse);
        }
    }
}
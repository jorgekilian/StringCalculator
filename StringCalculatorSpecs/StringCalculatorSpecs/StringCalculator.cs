namespace StringCalculatorSpecs {
    public abstract class StringCalculator {
        public static int Add(string numbers) {
            if (numbers == string.Empty) return 0;
            return int.Parse(numbers);
        }
    }
}
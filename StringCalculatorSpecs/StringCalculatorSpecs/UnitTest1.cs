using NUnit.Framework;

namespace StringCalculatorSpecs {
    public class Tests {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void return_zero_when_string_is_empty() {
            int result;

            result = StringCalculator.Add("");

            Assert.AreEqual(result, 0);
        }
    }
}
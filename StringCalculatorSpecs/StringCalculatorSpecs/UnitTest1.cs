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

        [Test]
        public void return_1_when_string_is_1() {
            int result;

            result = StringCalculator.Add("1");

            Assert.AreEqual(result, 1);
        }
    }
}
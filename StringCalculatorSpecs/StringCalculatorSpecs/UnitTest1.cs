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

            Assert.AreEqual(0, result);
        }

        [Test]
        public void return_1_when_string_is_1() {
            int result;

            result = StringCalculator.Add("1");

            Assert.AreEqual(1, result);
        }

        [Test]
        public void return_2_when_string_is_2() {
            int result;

            result = StringCalculator.Add("2");

            Assert.AreEqual( 2, result);
        }

        [Test]
        public void return_3_when_string_is_3() {
            int result;

            result = StringCalculator.Add("3");

            Assert.AreEqual(3, result);
        }
    }
}
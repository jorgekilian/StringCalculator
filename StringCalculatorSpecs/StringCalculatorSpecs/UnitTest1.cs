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

        [TestCase("1",1)]
        [TestCase("2", 2)]
        [TestCase("3", 3)]
        [TestCase("4", 4)]
        public void return_int_when_string_is_one_number(string number, int result) {
            var expected = StringCalculator.Add(number);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void return_sum_when_string_is_two_numbers() {
            var result = StringCalculator.Add("1,2");

            Assert.AreEqual(3, result);
        }

        [Test]
        public void return_sum_when_string_is_two_any_numbers() {
            var result = StringCalculator.Add("2,2");

            Assert.AreEqual(4, result);
        }

        [Test]
        public void return_sum_when_string_is_three_any_numbers() {
            var result = StringCalculator.Add("2,2,1");

            Assert.AreEqual(5, result);
        }

        [Test]
        public void return_sum_when_string_is_four_any_numbers() {
            var result = StringCalculator.Add("2,2,1,2");

            Assert.AreEqual(7, result);
        }
    }
}
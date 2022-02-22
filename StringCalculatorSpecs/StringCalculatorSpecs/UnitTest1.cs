using System;
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

        [Test]
        public void return_sum_when_string_is_four_any_numbers_separated_by_carriage_return() {
            var result = StringCalculator.Add("2\n2,1,2");

            Assert.AreEqual(7, result);
        }

        [Test]
        public void return_sum_when_string_is_four_any_numbers_separated_only_by_carriage_return() {
            var result = StringCalculator.Add("2\n2");

            Assert.AreEqual(4, result);
        }

        [Test]
        public void return_sum_when_string_is_separated_by_a_semicolon_separator_defined_at_the_begining() {
            var result = StringCalculator.Add("//;\n1;2");

            Assert.AreEqual(3, result);
        }

        [Test]
        public void return_sum_when_string_is_separated_by_a_specific_separator_defined_at_the_begining() {
            var result = StringCalculator.Add("//*\n2*2");

            Assert.AreEqual(4, result);
        }

        [Test]
        public void throw_exception_when_number_is_negative() {
            Assert.Throws<Exception>(() => StringCalculator.Add("1,-2"));
        }

        [Test]
        public void throw_exception_witha_specific_message_when_number_is_negative() {
            var ex = Assert.Throws<Exception>(() => StringCalculator.Add("1,-2"));

            Assert.That(ex.Message, Is.EqualTo("Negatives not allowed (-2)"));
        }

        [Test]
        public void throw_exception_witha_specific_message_when_numbers_are_negative() {
            var ex = Assert.Throws<Exception>(() => StringCalculator.Add("1,-2,3,-4"));

            Assert.That(ex.Message, Is.EqualTo("Negatives not allowed (-2,-4)"));
        }

        [Test]
        public void avoid_number_greater_than_1000() {
            var result = StringCalculator.Add("2,1001");

            Assert.AreEqual(2, result);
        }

        [Test]
        public void return_sum_when_string_is_separated_by_a_specific_separator_defined_with_any_length() {
            var result = StringCalculator.Add("//[***]\n1***2***3");

            Assert.AreEqual(6, result);
        }

        [Test]
        public void return_sum_when_string_is_separated_by_a_multiple_separators() {
            var result = StringCalculator.Add("//[*][%]\n1*2%3");

            Assert.AreEqual(6, result);
        }
    }
}
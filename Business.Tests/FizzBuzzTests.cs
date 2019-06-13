//this page is all my work.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Business.Tests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [Test]
        [Category("FizzBuzz")]
        public void Ask_Input15_ReturnsFizzBuzz()
        {
            string result = FizzBuzz.Ask(15);
            Assert.That(result, Is.EqualTo("FizzBuzz"));

        }

        [Test]
        [Category("FizzBuzz")]
        public void Ask_Input5_ReturnsBuzz()
        {
            string result = FizzBuzz.Ask(5);
            Assert.That(result, Is.EqualTo("Buzz"));

        }

        [Test]
        [Category("FizzBuzz")]
        public void Ask_Input3_ReturnsFizz()
        {
            string result = FizzBuzz.Ask(3);
            Assert.That(result, Is.EqualTo("Fizz"));

        }

        [Test]
        [Category("FizzBuzz")]
        public void Ask_Input7_ReturnsNopeMessage()
        {
            string result = FizzBuzz.Ask(7);
            Assert.That(result, Is.EqualTo("Neither Fizz nor Buzz nor Both."));

        }

        public class FBInputNumber : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] { 15, "FizzBuzz" };
                yield return new object[] { 5, "Buzz" };
                yield return new object[] { 3, "Fizz" };
                yield return new object[] { 7, "Neither Fizz nor Buzz nor Both." };
            }
        }

        [TestCaseSource(typeof(FBInputNumber))]
        [Category("FizzBuzz")]
        public void Ask_InputNumber_ReturnsExpectedMessage(int number, string message)
        {
            string result = FizzBuzz.Ask(number);
            Assert.That(result, Is.EqualTo(message));

        }

        //prof's line:
        //Assert.AreEqual(message, Fizzbuzz.Ask(number));
        //he did it with the [TestCase(3, "Fizz")] way.
        //and he tested more numbers like 6, 30.
    }
}

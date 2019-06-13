using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Business.Tests
{
    [TestFixture]
    [Category("Roman")] //hmm, seems to have no effect here. wrong words/syntax?
    public class RomanNumeralTests
    {
        [TestCase("I", 1)]
        [TestCase("V", 5)]
        [TestCase("VI", 6)]
        [TestCase("VC", 95)] //here's the test that shows the code isn't written as intended.
            //I expected 95 and got 105 (because I forgot to add a subtract feature)
            //that's the professor's point.
            //it passes after you add the substraction code in the method under test
        [TestCase("MMII", 2002)]
        [Category("Roman")]
        public void ParseNumeral_Returns_ExpectedResult(string roman, int expected)
        {
            Assert.AreEqual(expected, RomanNumeral.ParseNumeral(roman));
        }
    }
}

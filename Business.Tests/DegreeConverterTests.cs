using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Tests
{
    [TestFixture]
    class DegreeConverterTests
    {
        [Test]
        public void ToFahrenheit_ZeroCelcius_Equals32()
        {
            double result = DegreeConverter.ToFahrenheit(0);
            Assert.That(result, Is.EqualTo(32));
        }

        [Test]
        public void ToCelcius_32Fahrenheit_Equals0()
        {
            double result = DegreeConverter.ToCelcius(32);
            Assert.That(result, Is.EqualTo(0));
        }
    }
}

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Tests
{
    [TestFixture]
    public class SerialPortParserTests
    {
        //ParsePort = name of method under test
        //CCOM1 = what you're doing
        //Returns1 = what you expect
        [Test]
        public void ParsePort_CCOM1_Returns1()
        {
            int result = SerialPortParser.ParsePort("COM1");
            Assert.That(result, Is.EqualTo(1));
            //Assert is the class from NUnit
            //Lots of methods like That, Is, Throws, etc.
            //result is the actual result
            //second part is what we expect
        }

        //that test checked whether the element at the [3]
        //spot in the char array (COM1) is equal to 1.

        [Test]
        public void ParsePort_InvalidFormat_ThrowsInvalidFormatException()
        {
            TestDelegate action = () => SerialPortParser.ParsePort("1");
            Assert.Throws<FormatException>(action);
        }
    }
}

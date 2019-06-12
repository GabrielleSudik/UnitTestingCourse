//setup and teardown help reduce duplicate code
//even duplicate tests.
//how? basically by creating universal variables used in multiple tests.
//pitfall: if earlier tests alter the object, later tests might fail.
//[setup] attribute tells the tests to run "Setup()" before each test.

using System.Collections;
using System.Text.RegularExpressions;
using NUnit.Compatibility;
using NUnit.Framework;

namespace Business.Tests.SetupAndTeardown
{
    [TestFixture]
    [Category("Slow")]
    class CharacterTests
    {
        //declare the variable:
        private Character _character;

        //[SetUp] is what tells the code to run Setup() before each test
        //ie, _character is instantiated each time.
        [SetUp]
        public void Setup()
        {
            //instantiate it:
            _character = new Character(Type.Elf);
        }

        //[TearDown] tells the code to run the method after each test.
        //here, Dispose() disposes of the object after each test.
        //it'll prevent memory leaks and stuff
        [TearDown]
        public void Teardown()
        {
            _character.Dispose();
            _character = null;
        }

        [Test]
        [Ignore("reason")]
        public void IsDead_KillCharacter_ReturnsTrue()
        {        
            _character.Damage(500);
            Assert.That(_character.IsDead, Is.True);
        }

        [Test]
        [Category("Slow")]
        public void IsDead_DefaultCharacter_ReturnsFalse()
        {            
            Assert.IsFalse(_character.IsDead);
        }

        [TestCase(100, 45)]
        [TestCase(80, 65)]
        [TestCaseSource(typeof(DamageSource))]
        [Category("Slow")]
        public void Health_Damage_ReturnsCorrectValue(int damage, int expectedHealth)
        {
            _character.Damage(damage);
            Assert.That(_character.Health, Is.EqualTo(expectedHealth));
        }

        public class DamageSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new int[] {100, 45};
                yield return new int[] {80, 65};
            }
        }

        
        [Test]
        public void Health_Damage100OnElf_Returns45()
        {            
            _character.Damage(100);
            Assert.That(_character.Health, Is.EqualTo(45));
        }

        [Test]
        public void Health_Damage80OnElf_Returns65()
        {
            _character.Damage(80);
            Assert.That(_character.Health, Is.EqualTo(65));
        }
        
    } 
}

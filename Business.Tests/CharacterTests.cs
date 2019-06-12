//Prof supplied all the tests here. Notes are yours.
//the commented-out Asserts are just other ways of testing the same thing.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Business.Tests
{
    [TestFixture]
    public class CharacterTests
    {
        #region String Tests

        [Test]
        public void ShouldSetName() 
        {
            //create the variable we want to test in the code:
            const string expected = "John";
            //pass it into the Class/Method being tested:
            Character c = new Character(Type.Elf, expected);

            //these checks are examples. real world wouldn't always be so picky.
            Assert.That(c.Name, Is.EqualTo(expected));
            Assert.That(c.Name, Is.Not.Empty);
            Assert.That(c.Name, Contains.Substring("ohn"));
        }

        [Test]
        public void ShouldSetNameCaseInsensitive()
        {
            const string expectedUpperCase = "JOHN";
            const string expectedLowerCase = "john";
            Character c = new Character(Type.Elf, expectedUpperCase);

            //You can refine constraints -- like IgnoreCase here
            Assert.That(c.Name, Is.EqualTo(expectedLowerCase).IgnoreCase);
        }

        #endregion

        #region Numerical Tests

        [Test]
        public void DefaultHealthIs100()
        {
            Character c = new Character(Type.Elf);

            const int expectedHealth = 100;
            Assert.That(c.Health, Is.EqualTo(expectedHealth));
            //Assert.That(c.Health, Is.Positive);
            //Assert.That(c.Health, Is.Negative);
        }

        [Test]
        public void Elf_SpeedIsCorrect()
        {
            Character c = new Character(Type.Elf);

            //testing the same API with a double instead of an int.
            //ie, testing the same code with different kinds of variables is doable.
            const double expectedHealth = 1.7;
            Assert.That(c.Speed, Is.EqualTo(expectedHealth));
        }

        [Test]
        public void Ork_SpeedIsCorrect()
        {
            Character c = new Character(Type.Ork);

            const double expectedHealth = 1.4;
            Assert.That(c.Speed, Is.EqualTo(expectedHealth));
        }

        [Test]
        //[Ignore("")]
        public void Ork_SpeedIsCorrectWithTolerance()
        {
            Character c = new Character(Type.Ork);

            //compare this test to the one just above it.
            //at first, they seem the same cuz 1.4 = .3+1.1, right?
            //but this will fail. why? something about doubles and how they round.
            //1.4 != .3+1.1 apparently. "look for a good C# course" lol.
            const double expectedHealth = 0.3 + 1.1;
            //Assert.That(c.Speed, Is.EqualTo(expectedHealth));

            //you can adjust this by finessing the constraints:
            //"set a tolerance". interesting.
            Assert.That(c.Speed, Is.EqualTo(expectedHealth).Within(0.5));            
            Assert.That(c.Speed, Is.EqualTo(expectedHealth).Within(1).Percent);

            //ranges of DateTimes
            //var dt = new DateTime(2000, 1, 1);
            //Assert.That(dt, Is.EqualTo(new DateTime(2001, 1, 1)).Within(TimeSpan.FromDays(366)));
            //Assert.That(dt, Is.EqualTo(new DateTime(2001, 1, 1)).Within(366).Days;
        }

        #endregion

        #region Nulls and Booleans

        [Test]
        public void DefaultNameIsNull()
        {
            Character c = new Character(Type.Elf);
            Assert.That(c.Name, Is.Null);
        }

        [Test]
        public void IsDead_KillCharacter_ReturnsTrue()
        {
            //create the character:
            Character c = new Character(Type.Elf);
            //run the Damage method on it.
            c.Damage(500);
            //check if dead:
            Assert.That(c.IsDead, Is.True);
            //Assert.That(c.IsDead, Is.False);

            //instead of "That" IsTrue and IsFalse are two simple ways to check bools:
            //Assert.IsTrue(c.IsDead);
            //Assert.IsFalse(c.IsDead);
        }

        #endregion

        #region Collections
        [Test]
        public void CollectionTests()
        {
            var c = new Character(Type.Elf);
            c.Weaponry.Add("Knife");
            c.Weaponry.Add("Pistol");

            Assert.That(c.Weaponry, Is.All.Not.Empty);
            Assert.That(c.Weaponry, Contains.Item("Knife"));
            Assert.That(c.Weaponry, Has.Exactly(2).Length);
            Assert.That(c.Weaponry, Has.Exactly(1).EndsWith("tol"));
            Assert.That(c.Weaponry, Is.Unique);
            Assert.That(c.Weaponry, Is.Ordered);

            var c2 = new Character(Type.Elf);
            c2.Weaponry.Add("Knife");
            c2.Weaponry.Add("Pistol");

            Assert.That(c.Weaponry, Is.EquivalentTo(c2.Weaponry));
        }
        #endregion

        #region Reference Equality

        [Test]
        public void SameCharacters_AreEqualByReference()
        {
            Character c1 = new Character(Type.Elf);
            Character c2 = c1;

            Assert.That(c1, Is.SameAs(c2));
        }

        #endregion

        #region Types

        [Test]
        public void TestObjectOfCharacterType()
        {
            object c = new Character(Type.Elf);

            Assert.That(c, Is.TypeOf<Character>());
            //note this test doesn't follow AAA
            //arrange and assert are the only two parts.
            //this is rare.
        }

        #endregion

        #region Ranges

        [Test]
        public void DefaultCharacterArmorShouldBeGreaterThan30AndLessThan100()
        {
            Character c = new Character(Type.Elf);

            Assert.That(c.Armor, Is.GreaterThan(30).And.LessThan(100));
            //Assert.That(c.Armor, Is.InRange(30, 100)); //InRange includes the two boundaries.
        }

        #endregion

        #region Exceptions

        [Test]
        public void Damage_1000_ThrowsArgumentOutOfRange()
        {
            var c = new Character(Type.Elf);

            Assert.Throws<ArgumentOutOfRangeException>(() => c.Damage(1001));
            //Assert.That(() => c.Damage(1001), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Damage_1000_ThrowsArgumentOutOfRange_BadWay()
        {
            var c = new Character(Type.Elf);

            Assert.Throws<ArgumentOutOfRangeException>(() => c.Damage(1001));
            //Assert.That(() => c.Damage(1001), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        #endregion

        [Test]
        public void IsDead_KillCharacter_ReturnsTrueAgain()
        {
            //arrange:
            Character c = new Character(Type.Elf);
            //act:
            c.Damage(500);
            //assert:
            Assert.That(c.IsDead, Is.True);
        }
    }
}

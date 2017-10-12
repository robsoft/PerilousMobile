using System;
using PerilousMobile;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace PerilousMobile.Tests
{


    [TestFixture]
    public class TestWrapperClass : AssertionHelper
    {
        private Game game;

        [SetUp]
        protected void Setup()
        {
            game = new Game();
        }

        [Test]
        public void IsNull()
        {
            object nada = null;
            Assert.IsNull(nada);

            Assert.That(nada, Is.Null);

            Expect(nada, Null);
        }

        [Test]
        public void CheckGameHealthPointsOver10()
        {
            Assert.That(game.healthPoints, Is.GreaterThan(10));
            Assert.That(game.healthPoints, Is.LessThan(10));
        }
    }
}

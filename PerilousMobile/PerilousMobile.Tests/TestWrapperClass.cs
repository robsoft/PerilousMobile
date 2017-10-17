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
            // setup a game class prior to testing
            game = new Game();
        }


        [Test]
        public void IsNull()    // silly test that NUnit & Xamarin Runner stuff is all in place
        {
            object nada = null;
            Assert.IsNull(nada);

            Assert.That(nada, Is.Null);

            Expect(nada, Null);
        }


        [Test]
        // after an initial reset, the value of healthPoints should always exceed 10
        public void CheckGameHealthPointsOver10AtStartOfGame()
        {
            game.Reset();
            Assert.That(game.healthPoints, Is.GreaterThan(10));
        }

        [Test]
        // after an initial reset, the princess found flag should be false
        public void CheckNotFoundPrincessAtStartOfGame()
        {
            game.Reset();
            Assert.False(game.foundPrincess);
        }

    }
}

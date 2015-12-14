using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bowling.Tests
{
    [TestClass]
    public class BowlingTests
    {
        private BowlingGame _game;

        [TestInitialize]
        public void Initialize()
        {
            _game = new BowlingGame();
        }

        [TestMethod]
        public void Rolling_All_GutterBalls_Scores_0()
        {                    
            Roll(times: 20 , pins: 0);
            Assert.AreEqual(0, _game.Score);
        }

        [TestMethod]
        public void Rolling_All_1s_Scores_20()
        {
            Roll(times: 20, pins: 1);
            Assert.AreEqual(20, _game.Score);
        }

        [TestMethod]
        public void Rolling_A_Spare_Scores_Correctly()
        {
            _game.Roll(5);
            _game.Roll(5);
            Roll(18, 1);

            Assert.AreEqual(29, _game.Score);
        }

        [TestMethod]
        public void Rolling_A_Strike_Scores_Correctly()
        {
            _game.Roll(10);
            _game.Roll(5);

            Roll(17, 0);
            Assert.AreEqual(20, _game.Score);
        }        

        [TestMethod]
        public void Rolling_All_Strikes_Scores_300()
        {
            Roll(12, 10);
            Assert.AreEqual(300, _game.Score);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Rolling_11_Throws()
        {
            _game.Roll(11);
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Rolling_Negative_Throws()
        {
            _game.Roll(-1);
            Assert.Fail();
        }

        private void Roll(int times, int pins)
        {
            for(var i = 0; i < times; i++)
            {
                _game.Roll(pins);
            }
        }
    }
}
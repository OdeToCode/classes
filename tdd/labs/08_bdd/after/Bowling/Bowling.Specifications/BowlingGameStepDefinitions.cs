using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Bowling.Specifications
{
    [Binding]
    public class StepDefinitions
    {
        private BowlingGame _game = new BowlingGame();
        private int _score;

        [Given(@"I have rolled all gutter balls")]
        public void GivenIHaveRolledAllGutterBalls()
        {
            RollMany(20, 0);
        }

        [When(@"I ask for the score")]
        public void WhenIAskForTheScore()
        {
            _score = _game.Score;
        }

        [Given(@"I have rolled (.*) time(?:.*) and knocked down (.*) pin(?:.*) each")]
        public void GivenIHaveRolledXTimesAndKnockedDownYPinEach(int rolls, int pins)
        {
            RollMany(rolls, pins);
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            Assert.AreEqual(result, _game.Score);
        }


        void RollMany(int times, int pins)
        {
            for (int i = 0; i < times; i++)
            {
                _game.Roll(pins);
            }
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bowling.Specifications
{
    [TestClass]
    public class GutterBallTest : SpecificationContext
    {
        private BowlingGame _game = new BowlingGame();
        private int _score;

        public override void Given()
        {
            for(int i = 0; i < 20; i++)
            {
                _game.Roll(0);
            }
        }
        public override void When()
        {
            _score = _game.Score;
        }

        [TestMethod]
        public void then_the_score_should_be_0()
        {
            Assert.AreEqual(0, _score);
        }
    }


    public abstract class SpecificationContext
    {
        [TestInitialize]
        public void Init()
        {
            this.Given();
            this.When();
        }

        public virtual void Given() { }
        public virtual void When() { }
    }

}
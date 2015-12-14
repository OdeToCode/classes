using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
    public class BowlingGame
    {
        public void Roll(int pinsKnockedDown)
        {
            _pins.Add(pinsKnockedDown);
        }

        public int Score
        {
            get 
            { 
                var score = 0;
                var pinIndex = 0;

                for (var frame = 0; frame < 10; frame++ )
                {
                    if(_pins[pinIndex] == 10)
                    {
                        score += 10 + _pins[pinIndex + 1] + _pins[pinIndex + 2];
                        pinIndex += 1;
                    }
                    else if(_pins[pinIndex] + _pins[pinIndex+1] == 10)
                    {
                        score += 10 + _pins[pinIndex + 2];
                        pinIndex += 2;
                    }
                    else
                    {
                        score += _pins[pinIndex] + _pins[pinIndex + 1];
                        pinIndex += 2;
                    }
                }

                return score;
            }
        }

        private List<int> _pins = new List<int>();
    }
}
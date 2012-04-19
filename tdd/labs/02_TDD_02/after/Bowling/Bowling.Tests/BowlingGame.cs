using System;
using System.Collections.Generic;

namespace Bowling.Tests
{
    public class BowlingGame
    {
        private List<int> rolls = new List<int>();

        public void Roll(int numberOfPins)
        {
            if(numberOfPins > 10 || numberOfPins < 0)
            {
                throw new ArgumentException("Out of range", "numberOfPins");
            }
            rolls.Add(numberOfPins);
        }

        public int Score
        {
            get
            {
                int score = 0;
                int pinIndex = 0;

                for (var frame = 0; frame < 10; frame++)
                {
                    if (IsStrike(pinIndex))
                    {
                        score += StrikeScore(pinIndex);
                        pinIndex += 1;
                    }
                    else if (IsSpare(pinIndex))
                    {
                        score += SpareScore(pinIndex);
                        pinIndex += 2;
                    }                    
                    else
                    {
                        score += ScoreForFrame(pinIndex);
                        pinIndex += 2;
                    }
                }
                return score;
            }            
        }

        private int StrikeScore(int pinIndex)
        {
            return 10 + rolls[pinIndex + 1] + rolls[pinIndex + 2];
        }

        private bool IsStrike(int pinIndex)
        {
            return rolls[pinIndex] == 10;
        }

        private int SpareScore(int pinIndex)
        {
            return 10 + rolls[pinIndex + 2];
        }

        private bool IsSpare(int pinIndex)
        {
            return rolls[pinIndex] + rolls[pinIndex + 1] == 10;
        }

        private int ScoreForFrame(int pinIndex)
        {
            return rolls[pinIndex] + rolls[pinIndex + 1];
        }
    }
}
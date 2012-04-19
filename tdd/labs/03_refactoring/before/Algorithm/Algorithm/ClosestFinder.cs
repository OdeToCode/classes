using System.Collections.Generic;

namespace Algorithm
{

    public class FurthestFinder : Finder
    {
        public FurthestFinder(PersonList people)
            : base(people)
        {
        }

        protected override AgeComparison FindAnswer(
            List<AgeComparison> ageDifferences)
        {
            if (ageDifferences.Count < 1)
            {
                return new AgeComparison();
            }

            AgeComparison answer = ageDifferences[0];
            foreach (var result in ageDifferences)
            {
                if (result.AgeDifference > answer.AgeDifference)
                {
                    answer = result;
                }
            }

            return answer;
        }
    }


    public class ClosestFinder : Finder
    {
        public ClosestFinder(PersonList people) 
            : base(people)
        {
        }

        protected override AgeComparison FindAnswer(            
            List<AgeComparison> ageDifferences)
        {
            if (ageDifferences.Count < 1)
            {
                return new AgeComparison();
            }

            AgeComparison answer = ageDifferences[0];
            foreach (var result in ageDifferences)
            {
                if (result.AgeDifference < answer.AgeDifference)
                {
                   answer = result;
                }
            }

            return answer;
        }
    }
}
using System.Collections.Generic;

namespace Algorithm
{
    public abstract class Finder
    {
        private readonly PersonList _people;

        public Finder(PersonList people)
        {
            _people = people;
        }

        public AgeComparison Find()
        {
            var ageComparisons = new List<AgeComparison>();
            CalculateAgeDifferences(ageComparisons);  
            return FindAnswer(ageComparisons);
        }

        protected abstract AgeComparison FindAnswer(
            List<AgeComparison> ageDifferences);
       

        private void CalculateAgeDifferences(List<AgeComparison> ageDifferences)
        {
            for (var i = 0; i < _people.Count - 1; i++)
            {
                for (var j = i + 1; j < _people.Count; j++)
                {
                    var ageComparison = new AgeComparison(
                                            _people[i], _people[j]);                    
                    ageDifferences.Add(ageComparison);
                }
            }
        }
    }
}
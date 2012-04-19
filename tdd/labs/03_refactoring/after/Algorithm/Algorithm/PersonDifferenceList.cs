using System;
using System.Collections.Generic;

namespace Algorithm
{
    public class PersonDifferenceList : List<PersonDifference>
    {
        public PersonDifferenceList(PersonList people)
        {
            CombineEachPerson(people);
        }

        private void CombineEachPerson(PersonList people)
        {
            for (var i = 0; i < people.Count - 1; i++)
            {
                for (var j = i + 1; j < people.Count; j++)
                {
                    var result = new PersonDifference(people[i], people[j]);
                    Add(result);
                }
            }
        }

        public PersonDifference Find(Func<PersonDifference, PersonDifference, bool> findStrategy)
        {
            var answer = Count > 0 ? this[0] : new PersonDifference();
            foreach (var result in this)
            {
                if(findStrategy(result, answer))
                {
                    answer = result;
                }                
            }
            return answer;
        }
    }
}
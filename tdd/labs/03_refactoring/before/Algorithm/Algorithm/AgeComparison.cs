using System;

namespace Algorithm
{
    public class AgeComparison
    {       
        public AgeComparison()
        {
            
        }

        public AgeComparison(Person person1, Person person2)
        {
            if (person1.BirthDate < person2.BirthDate)
            {
                Person1 = person1;
                Person2 = person2;
            }
            else
            {
                Person1 = person2;
                Person2 = person1;
            }
            AgeDifference = Person2.BirthDate - Person1.BirthDate;
        }
        public Person Person1 { get; set; }
        public Person Person2 { get; set; }
        public TimeSpan AgeDifference { get; set; }

        private Person person;
        private Person person_2;
    }
}
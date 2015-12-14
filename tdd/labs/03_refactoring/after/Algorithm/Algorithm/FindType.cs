using System;

namespace Algorithm
{
    public static class Find
    {
        public static Func<PersonDifference, PersonDifference, bool> Closest = (p1, p2) => p1.Difference < p2.Difference;
        public static Func<PersonDifference, PersonDifference, bool> Furthest = (p1, p2) => p1.Difference > p2.Difference;
    }
}
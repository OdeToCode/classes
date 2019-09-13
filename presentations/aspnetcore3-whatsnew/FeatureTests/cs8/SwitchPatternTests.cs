using System;
using Xunit;

namespace FeatureTests
{
    public enum CuisineType
    {
        None,
        Italian,
        Indian,
        French
    }

    public class Meal
    {
        public Meal(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }


    public class SwitchPatternTests
    {
        [Fact]
        public void Can_Switch_Using_Expressions()
        {
            var cuisine = CuisineType.French;
            var meal = cuisine switch
            {
                CuisineType.French => new Meal("Frites"),
                CuisineType.Indian => new Meal("Chicken Vindaloo"),
                _ => throw new InvalidOperationException("Unknown enum")
            };

            Assert.Equal("Frites", meal.Name);
        }

        [Fact]
        public void Can_Switch_On_Property()
        {
            var meal = new Meal("Pizza");
            var cuisine = meal switch
            {
                { Name: "Frites" } => CuisineType.French,
                { Name: "Pizza" } => CuisineType.Italian,
                _ => CuisineType.None
            };

            Assert.Equal(CuisineType.Italian, cuisine);
        }

        [Fact]
        public void Can_Switch_On_Tuple()
        {
            var pair = ("one", "three");

            var result = pair switch
            {
                ("one", "one") => (1, 1),
                ("one", "two") => (1, 2),
                ("one", "three") => (1, 3),
                ("two", "one") => (2, 1),
                _ => (int.MaxValue, int.MaxValue)
            };

            Assert.Equal((1, 3), result);
        }
    }
}

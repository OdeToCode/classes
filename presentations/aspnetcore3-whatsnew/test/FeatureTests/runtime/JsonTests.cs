using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Xunit;

namespace FeatureTests.runtime
{
    public class JsonTests
    {
        [Fact]
        public void Can_Parse_Json()
        {
            
            var jsonText = "{ \"firstName\":\"Scott\", \"lastName\":\"Allen\" }";
            var jsonBytes = Encoding.UTF8.GetBytes(jsonText);

            var reader = new Utf8JsonReader(jsonBytes);
            var strings = new List<string>();

            while (reader.Read())
            {
                var (type, value) = (reader.TokenType, reader.ValueSequence);
                var result = type switch
                {
                    JsonTokenType.String => reader.GetString(),
                    _ => null
                };

                if (result != null)
                {
                    strings.Add(result);
                } 
            }

            Assert.Equal(new[] { "Scott", "Allen" }, strings);
        }

        [Fact]
        public void Can_Use_Document()
        {
            var jsonText = "{ \"firstName\":\"Scott\", \"lastName\":\"Allen\" }";            
            using var document = JsonDocument.Parse(jsonText);

            var result = document.RootElement.GetProperty("firstName").GetString();
            Assert.Equal("Scott", result);
        }

        public class Person
        {
            public string FirstName { get; set; } = "";
            public int Age { get; set; }
        }

        [Fact]
        public void Can_Serialize()
        {
            var person = new Person { FirstName = "Lisa", Age = 42 };
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            
            var json = JsonSerializer.Serialize(person, options);

            Assert.StartsWith("{\"firstName\":\"Lisa\"", json);
        }

        [Fact]
        public void Can_Deserialize()
        {
            var json = "{\"firstName\":\"Alex\", \"age\":20}";
            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            var person = JsonSerializer.Deserialize<Person>(json, options);

            Assert.Equal("Alex", person.FirstName);
            Assert.Equal(20, person.Age);
        }
    }
}

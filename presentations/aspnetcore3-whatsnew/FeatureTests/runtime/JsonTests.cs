using System.Collections.Generic;
using System.IO;
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
        }
    }
}

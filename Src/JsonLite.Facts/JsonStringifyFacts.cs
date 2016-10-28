using System;
using JsonLite.Ast;
using Xunit;

namespace JsonLite.Facts
{
    public class JsonStringifyFacts
    {
        [Fact]
        public void CanParseString()
        {
            // arrange
            var value1 = new JsonObject(
                new JsonMember("a", new JsonNumber(1)),
                new JsonMember("b", new JsonNumber(2)),
                new JsonMember("c", new JsonString("\"Hello World\"")));

            // act
            var value2 = Json.CreateAst(value1.Stringify());

            // assert
            Assert.IsType<JsonObject>(value2);
            Assert.Equal(3, ((JsonObject)value2).Members.Count);
        }

        [Theory]
        [InlineData("\"\\u0123\"", "\u0123")]
        [InlineData("\"\\u0460\\u849c\\u8089\"", "\u0460\u849c\u8089")]
        public void CanStringifyUnicode(string escaped, string unicode)
        {
            // arrange
            var token = new JsonString(unicode);

            // act
            var output = token.Stringify();

            // assert
            Assert.Equal(escaped, output);
        }
    }
}
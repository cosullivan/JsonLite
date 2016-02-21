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
                new JsonMember("a", new JsonInteger(1)),
                new JsonMember("b", new JsonInteger(2)),
                new JsonMember("c", new JsonString("\"Hello World\"")));

            // act
            var value2 = Json.CreateAst(value1.Stringify());

            // assert
            Assert.IsType<JsonObject>(value2);
            Assert.Equal(3, ((JsonObject)value2).Members.Count);
        }
    }
}

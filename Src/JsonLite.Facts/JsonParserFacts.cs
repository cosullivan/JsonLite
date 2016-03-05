using System.IO;
using JsonLite.Ast;
using Xunit;

namespace JsonLite.Facts
{
    public class JsonParserFacts
    {
        [Fact]
        public void CanParseString()
        {
            // act
            var value = CreateValue("\"hello world!\"");

            // assert
            Assert.IsType<JsonString>(value);
            Assert.Equal("hello world!", ((JsonString)value).Value);
        }

        [Fact]
        public void CanParseQuotedString()
        {
            // act
            var value = CreateValue("\"hello \\\"world\\\"!\"");

            // assert
            Assert.IsType<JsonString>(value);
            Assert.Equal("hello \"world\"!", ((JsonString)value).Value);
        }

        [Fact]
        public void CanParseInteger()
        {
            // act
            var value = CreateValue("123");

            // assert
            Assert.IsType<JsonInteger>(value);
            Assert.Equal(123, ((JsonInteger)value).Value);
        }

        [Fact]
        public void CanParseDecimal()
        {
            // act
            var value = CreateValue("123.01");

            // assert
            Assert.IsType<JsonDecimal>(value);
            Assert.Equal(123.01m, ((JsonDecimal)value).Value);
        }

        [Fact]
        public void CanParseBoolean()
        {
            // act
            var value = CreateValue("true");

            // assert
            Assert.IsType<JsonBoolean>(value);
            Assert.Equal(true, ((JsonBoolean)value).Value);
        }

        [Fact]
        public void CanParseNull()
        {
            // act
            var value = CreateValue("null");

            // assert
            Assert.IsType<JsonNull>(value);
        }

        [Fact]
        public void CanParseObject()
        {
            // act
            var value = CreateValue("{ \"a\" : 1, \"b\" : 2, \"c\" : 3 }");

            // assert
            Assert.IsType<JsonObject>(value);
            Assert.Equal(3, ((JsonObject)value).Members.Count);
        }

        [Fact]
        public void CanParseObjectWithoutWhitespaceSeparators()
        {
            // act
            var value = CreateValue("{\"a\":1,\"b\":2,\"c\":3}");

            // assert
            Assert.IsType<JsonObject>(value);
            Assert.Equal(3, ((JsonObject)value).Members.Count);
        }

        [Fact]
        public void CanParseEmptyObject()
        {
            // act
            var value = CreateValue("{ }");

            // assert
            Assert.IsType<JsonObject>(value);
            Assert.Equal(0, ((JsonObject)value).Members.Count);
        }

        [Fact]
        public void CanParseMember()
        {
            // act
            var value = CreateValue("{ \"a\" : 123 }");

            // assert
            Assert.IsType<JsonObject>(value);
            Assert.Equal(1, ((JsonObject)value).Members.Count);
            Assert.Equal("a", ((JsonObject)value).Members[0].Name);
            Assert.Equal(123, ((JsonInteger)((JsonObject)value).Members[0].Value).Value);
        }

        [Fact]
        public void CanParseArray()
        {
            // act
            var value = CreateValue("[ 1, 2, 3, 4, 5 ]");

            // assert
            Assert.IsType<JsonArray>(value);
            Assert.Equal(5, ((JsonArray)value).Count);
        }

        [Fact]
        public void CanParseEmptyArray()
        {
            // act
            var value = CreateValue("[ ]");

            // assert
            Assert.IsType<JsonArray>(value);
            Assert.Equal(0, ((JsonArray)value).Count);
        }

        [Fact]
        public void ThrowsUnexpectedToken()
        {
            Assert.Throws<JsonAstException>(() => CreateValue("{ \"a\" : 1, }"));
            Assert.Throws<JsonAstException>(() => CreateValue("{ \"a\" : 1, \"b\" : }"));
            Assert.Throws<JsonAstException>(() => CreateValue("[ 1, ]"));
            Assert.Throws<JsonAstException>(() => CreateValue("[ ,1 ]"));
        }

        [Theory]
        [InlineData(@"..\..\sample1.json")]
        public void CanParseFile(string fileName)
        {
            using (var stream = File.OpenRead(fileName))
            {
                Json.CreateAst(stream);
            }
        }

        static JsonValue CreateValue(string json)
        {
            using (var reader = new StringReader(json))
            {
                return new JsonAstParser(new JsonTextReader(reader)).MakeValue();
            }
        }
    }
}

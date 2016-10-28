using System.IO;
using Xunit;

namespace JsonLite.Facts
{
    public class JsonTextReaderFacts
    {
        [Fact]
        public void CanReadString()
        {
            // arrange
            var reader = new JsonTextReader(new StringReader("\"hello\""));

            // act
            var token = reader.NextToken();

            // assert
            Assert.Equal(new JsonToken(JsonTokenKind.String, "hello"), token);
        }

        [Theory]
        [InlineData("\\u0123", "\u0123")]
        [InlineData("\\u0460\\u849c\\u8089", "\u0460\u849c\u8089")]
        public void CanReadUnicodeString(string escaped, string unicode)
        {
            // arrange
            var reader = new JsonTextReader(new StringReader($"\"{escaped}\""));

            // act
            var token = reader.NextToken();

            // assert
            Assert.Equal(new JsonToken(JsonTokenKind.String, unicode), token);
        }

        [Fact]
        public void CanReadColon()
        {
            // arrange
            var reader = new JsonTextReader(new StringReader(":"));

            // act
            var token = reader.NextToken();

            // assert
            Assert.Equal(JsonToken.Colon, token);
        }

        [Fact]
        public void CanReadComma()
        {
            // arrange
            var reader = new JsonTextReader(new StringReader(","));

            // act
            var token = reader.NextToken();

            // assert
            Assert.Equal(JsonToken.Comma, token);
        }

        [Fact]
        public void CanReadInteger()
        {
            // arrange
            var reader = new JsonTextReader(new StringReader("1234567"));

            // act
            var token = reader.NextToken();

            // assert
            Assert.Equal(new JsonToken(JsonTokenKind.Integer, "1234567"), token);
        }

        [Fact]
        public void CanReadDecimal()
        {
            // arrange
            var reader = new JsonTextReader(new StringReader("123.456"));

            // act
            var token = reader.NextToken();

            // assert
            Assert.Equal(new JsonToken(JsonTokenKind.Fractional, "123.456"), token);
        }

        [Theory]
        [InlineData("6.022E23")]
        [InlineData("6.022e23")]
        [InlineData("1e-005")]
        [InlineData("1E+005")]
        public void CanReadExponent(string exponent)
        {
            // arrange
            var reader = new JsonTextReader(new StringReader(exponent));

            // act
            var token = reader.NextToken();

            // assert
            Assert.Equal(new JsonToken(JsonTokenKind.Fractional, exponent), token);
        }

        [Fact]
        public void CanReadBooleanFalse()
        {
            // arrange
            var reader = new JsonTextReader(new StringReader("false"));

            // act
            var token = reader.NextToken();

            // assert
            Assert.Equal(JsonToken.False, token);
        }

        [Fact]
        public void CanReadBooleanTrue()
        {
            // arrange
            var reader = new JsonTextReader(new StringReader("true"));

            // act
            var token = reader.NextToken();

            // assert
            Assert.Equal(JsonToken.True, token);
        }

        [Fact]
        public void CanReadNull()
        {
            // arrange
            var reader = new JsonTextReader(new StringReader("null"));

            // act
            var token = reader.NextToken();

            // assert
            Assert.Equal(JsonToken.Null, token);
        }

        [Fact]
        public void CanIgnoreWhiteSpace()
        {
            // arrange
            var reader = new JsonTextReader(new StringReader("   false   true   null"));

            // act
            var token1 = reader.NextToken();
            var token2 = reader.NextToken();
            var token3 = reader.NextToken();

            // assert
            Assert.Equal(JsonToken.False, token1);
            Assert.Equal(JsonToken.True, token2);
            Assert.Equal(JsonToken.Null, token3);
        }

        [Fact]
        public void ThrowsUnexpectedEnd()
        {
            Assert.Throws<JsonUnexpectedEndException>(() => new JsonTextReader(new StringReader("\"hello")).NextToken());
            Assert.Throws<JsonUnexpectedEndException>(() => new JsonTextReader(new StringReader("123.")).NextToken());
        }

        [Fact]
        public void ThrowsUnexpectedCharacter()
        {
            Assert.Throws<JsonUnexpectedCharacterException>(() => new JsonTextReader(new StringReader("123a")).NextToken());
        }
    }
}

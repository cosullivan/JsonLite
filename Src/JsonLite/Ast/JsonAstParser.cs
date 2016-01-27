using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace JsonLite.Ast
{
    public sealed class JsonAstParser : JsonParser
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="jsonReader">The JSON text reader to parse the content from.</param>
        public JsonAstParser(JsonReader jsonReader) : this(new JsonTokenEnumerator(jsonReader)) { }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="enumerator">The token enumerator to use when parsing the document.</param>
        public JsonAstParser(JsonTokenEnumerator enumerator) : base(enumerator) { }

        /// <summary>
        /// Create a JSON abstract syntax tree.
        /// </summary>
        /// <returns>The JSON value which represents the top level node in the document.</returns>
        public JsonValue CreateAst()
        {
            if (CanMakeObject() == false && CanMakeArray() == false)
            {
                throw new JsonAstException("Could not make an Object or an Array at the current position.");
            }

            return MakeValue();
        }

        /// <summary>
        /// Make a value from the current position of the tree.
        /// </summary>
        /// <returns>The value that exists at the current position.</returns>
        internal JsonValue MakeValue()
        {
            if (CanMakeArray())
            {
                return MakeArray();
            }

            if (CanMakeObject())
            {
                return MakeObject();
            }
            
            if (CanMakeString())
            {
                return MakeString();
            }

            if (CanMakeInteger())
            {
                return MakeInteger();
            }

            if (CanMakeDecimal())
            {
                return MakeDecimal();
            }

            if (CanMakeBoolean())
            {
                return MakeBoolean();
            }

            if (CanMakeNull())
            {
                return MakeNull();
            }

            throw new JsonAstException("Can not make a value at the current position.");
        }

        /// <summary>
        /// Makes a JSON array.
        /// </summary>
        /// <returns>The JSON array that was made from the current position.</returns>
        JsonArray MakeArray()
        {
            ThrowUnexpectedTokenIfNot(JsonToken.StartArray);

            var values = MakeArrayValues().ToList();

            ThrowUnexpectedTokenIfNot(JsonToken.EndArray);

            return new JsonArray(values);
        }

        /// <summary>
        /// Makes a list of array values.
        /// </summary>
        /// <returns>The list of array values.</returns>
        IEnumerable<JsonValue> MakeArrayValues()
        {
            if (Enumerator.Peek() == JsonToken.EndArray)
            {
                yield break;
            }

            yield return MakeValue();

            while (Enumerator.Peek() != JsonToken.EndArray)
            {
                ThrowUnexpectedTokenIfNot(JsonToken.Comma);

                yield return MakeValue();
            }
        }

        /// <summary>
        /// Makes a JSON object.
        /// </summary>
        /// <returns>The JSON object that was made from the current position.</returns>
        JsonObject MakeObject()
        {
            ThrowUnexpectedTokenIfNot(JsonToken.StartObject);

            var members = MakeObjectMembers().ToList();

            ThrowUnexpectedTokenIfNot(JsonToken.EndObject);

            return new JsonObject(members);
        }

        /// <summary>
        /// Make the list of object members.
        /// </summary>
        /// <returns>The list of object members.</returns>
        IEnumerable<JsonMember> MakeObjectMembers()
        {
            if (Enumerator.Peek() == JsonToken.EndObject)
            {
                yield break;
            }

            yield return MakePair();

            while (Enumerator.Peek() != JsonToken.EndObject)
            {
                ThrowUnexpectedTokenIfNot(JsonToken.Comma);

                yield return MakePair();
            }
        }

        /// <summary>
        /// Make a JSON name/pair from the current position.
        /// </summary>
        /// <returns>The name/value pair that was made from the current position.</returns>
        JsonMember MakePair()
        {
            var name = new JsonString(Enumerator.Take().Text);

            ThrowUnexpectedTokenIfNot(JsonToken.Colon);

            return new JsonMember(name, MakeValue());
        }

        /// <summary>
        /// Make a string from the current position.
        /// </summary>
        /// <returns>The string that exists at the current position.</returns>
        JsonString MakeString()
        {
            return new JsonString(Enumerator.Take().Text);
        }

        /// <summary>
        /// Make a integer value from the current position.
        /// </summary>
        /// <returns>The integer value.</returns>
        JsonInteger MakeInteger()
        {
            long value;
            if (Int64.TryParse(Enumerator.Take().Text, out value))
            {
                return new JsonInteger(value);
            }

            throw new JsonAstException("Unexpected long format.");
        }

        /// <summary>
        /// Make a fractional number from the current position.
        /// </summary>
        /// <returns>The fractional number.</returns>
        JsonDecimal MakeDecimal()
        {
            decimal value;
            if (Decimal.TryParse(Enumerator.Take().Text, NumberStyles.Float | NumberStyles.AllowExponent, null, out value))
            {
                return new JsonDecimal(value);
            }

            throw new JsonAstException("Unexpected decimal format.");
        }

        /// <summary>
        /// Make a boolean value from the current position.
        /// </summary>
        /// <returns>The boolean value.</returns>
        JsonBoolean MakeBoolean()
        {
            return new JsonBoolean(Enumerator.Take() == JsonToken.True);
        }

        /// <summary>
        /// Make a null value from the current position.
        /// </summary>
        /// <returns>The null value.</returns>
        JsonNull MakeNull()
        {
            ThrowUnexpectedTokenIfNot(JsonToken.Null);

            return JsonNull.Instance;
        }

        /// <summary>
        /// Throw an exception if the next token is not of the expected one.
        /// </summary>
        /// <param name="expected">The expected token.</param>
        void ThrowUnexpectedTokenIfNot(JsonToken expected)
        {
            var token = Enumerator.Take();

            if (token != expected)
            {
                throw new JsonAstException(
                    "Unexpected token. Expected a token kind of {0} but found {1}.",
                        expected.Kind,
                        token.Kind);
            }
        }
    }
}

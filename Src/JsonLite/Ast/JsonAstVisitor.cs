using System.Linq;

namespace JsonLite.Ast
{
    public abstract class JsonAstVisitor<T>
    {
        /// <summary>
        /// Visit the given JSON value.
        /// </summary>
        /// <param name="jsonValue">The JSON value to visit.</param>
        /// <returns>The type that was visited.</returns>
        protected T Visit(JsonValue jsonValue)
        {
            if (jsonValue is JsonArray)
            {
                return Visit((JsonArray)jsonValue);
            }

            if (jsonValue is JsonObject)
            {
                return Visit((JsonObject)jsonValue);
            }

            if (jsonValue is JsonString)
            {
                return Visit((JsonString)jsonValue);
            }

            if (jsonValue is JsonNumber)
            {
                return Visit((JsonNumber)jsonValue);
            }

            if (jsonValue is JsonBoolean)
            {
                return Visit((JsonBoolean)jsonValue);
            }

            if (jsonValue is JsonNull)
            {
                return Visit((JsonNull)jsonValue);
            }

            throw new JsonAstException("No support for the value if '{0}'.", jsonValue);
        }

        /// <summary>
        /// Visit the JSON array.
        /// </summary>
        /// <param name="jsonArray">The JSON array to visit.</param>
        /// <returns>The type that was visited.</returns>
        protected abstract T Visit(JsonArray jsonArray);

        /// <summary>
        /// Visit the JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object to visit.</param>
        /// <returns>The type that was visited.</returns>
        protected abstract T Visit(JsonObject jsonObject);

        /// <summary>
        /// Visit a JSON string.
        /// </summary>
        /// <param name="jsonString">The JSON string to visit.</param>
        /// <returns>The type that was visited.</returns>
        protected abstract T Visit(JsonString jsonString);

        /// <summary>
        /// Visit a JSON number.
        /// </summary>
        /// <param name="jsonNumber">The JSON number to visit.</param>
        /// <returns>The type that was visited.</returns>
        protected abstract T Visit(JsonNumber jsonNumber);

        /// <summary>
        /// Visit a JSON boolean.
        /// </summary>
        /// <param name="jsonBoolean">The JSON boolean to visit.</param>
        /// <returns>The type that was visited.</returns>
        protected abstract T Visit(JsonBoolean jsonBoolean);

        /// <summary>
        /// Visit a JSON null.
        /// </summary>
        /// <param name="jsonNull">The JSON null to visit.</param>
        /// <returns>The type that was visited.</returns>
        protected abstract T Visit(JsonNull jsonNull);
    }

    public abstract class JsonAstVisitor : JsonAstVisitor<JsonValue>
    {
        /// <summary>
        /// Visit the JSON array.
        /// </summary>
        /// <param name="jsonArray">The JSON array to visit.</param>
        /// <returns>The type that was visited.</returns>
        protected override JsonValue Visit(JsonArray jsonArray)
        {
            return new JsonArray(jsonArray.Select(Visit).ToList());
        }

        /// <summary>
        /// Visit the JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object to visit.</param>
        /// <returns>The type that was visited.</returns>
        protected override JsonValue Visit(JsonObject jsonObject)
        {
            var members = jsonObject.Members.Select(member => new JsonMember(member.Name, Visit(member.Value)));

            return new JsonObject(members.ToList());
        }

        /// <summary>
        /// Visit a JSON string.
        /// </summary>
        /// <param name="jsonString">The JSON string to visit.</param>
        /// <returns>The type that was visited.</returns>
        protected override JsonValue Visit(JsonString jsonString)
        {
            return jsonString;
        }

        /// <summary>
        /// Visit a JSON number.
        /// </summary>
        /// <param name="jsonNumber">The JSON number to visit.</param>
        /// <returns>The type that was visited.</returns>
        protected override JsonValue Visit(JsonNumber jsonNumber)
        {
            return jsonNumber;
        }
        
        /// <summary>
        /// Visit a JSON boolean.
        /// </summary>
        /// <param name="jsonBoolean">The JSON boolean to visit.</param>
        /// <returns>The type that was visited.</returns>
        protected override JsonValue Visit(JsonBoolean jsonBoolean)
        {
            return jsonBoolean;
        }

        /// <summary>
        /// Visit a JSON null.
        /// </summary>
        /// <param name="jsonNull">The JSON null to visit.</param>
        /// <returns>The type that was visited.</returns>
        protected override JsonValue Visit(JsonNull jsonNull)
        {
            return jsonNull;
        }
    }
}
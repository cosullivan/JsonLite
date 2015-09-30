using System.Globalization;
using System.Text;

namespace JsonLite.Ast
{
    public class JsonStringifyVisitor : JsonAstVisitor<string>
    {
        /// <summary>
        /// Perform the output processing.
        /// </summary>
        /// <param name="jsonValue">The value to perform the processing from.</param>
        /// <returns>The string representation of the JSON value.</returns>
        public string Stringify(JsonValue jsonValue)
        {
            return Visit(jsonValue);
        }

        /// <summary>
        /// Visit the JSON array.
        /// </summary>
        /// <param name="jsonArray">The JSON array to visit.</param>
        /// <returns>The type that was visited.</returns>
        protected override string Visit(JsonArray jsonArray)
        {
            var builder = new StringBuilder("[");

            for (var i = 0; i < jsonArray.Count; i++)
            {
                builder.Append(Visit(jsonArray[i]));

                if (i < jsonArray.Count - 1)
                {
                    builder.Append(",");
                }
            }

            builder.Append("]");

            return builder.ToString();
        }

        /// <summary>
        /// Visit the JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object to visit.</param>
        /// <returns>The type that was visited.</returns>
        protected override string Visit(JsonObject jsonObject)
        {
            var builder = new StringBuilder("{");

            for (var i = 0; i < jsonObject.Members.Count; i++)
            {
                builder.Append(Visit(jsonObject.Members[i]));

                if (i < jsonObject.Members.Count - 1)
                {
                    builder.Append(",");
                }
            }

            builder.Append("}");

            return builder.ToString();
        }

        /// <summary>
        /// Visit a JSON pair.
        /// </summary>
        /// <param name="jsonPair">The JSON pair to visit.</param>
        /// <returns>The type that was visited.</returns>
        protected override string Visit(JsonMember jsonPair)
        {
            return $"{Visit(jsonPair.Name)}:{Visit(jsonPair.Value)}";
        }

        /// <summary>
        /// Visit a JSON string.
        /// </summary>
        /// <param name="jsonString">The JSON string to visit.</param>
        /// <returns>The type that was visited.</returns>
        protected override string Visit(JsonString jsonString)
        {
            return $"\"{jsonString.Value}\"";
        }

        /// <summary>
        /// Visit a JSON integer.
        /// </summary>
        /// <param name="jsonInteger">The JSON integer to visit.</param>
        /// <returns>The type that was visited.</returns>
        protected override string Visit(JsonInteger jsonInteger)
        {
            return jsonInteger.Value.ToString();
        }

        /// <summary>
        /// Visit a JSON decimal.
        /// </summary>
        /// <param name="jsonDecimal">The JSON decimal to visit.</param>
        /// <returns>The type that was visited.</returns>
        protected override string Visit(JsonDecimal jsonDecimal)
        {
            return jsonDecimal.Value.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Visit a JSON boolean.
        /// </summary>
        /// <param name="jsonBoolean">The JSON boolean to visit.</param>
        /// <returns>The type that was visited.</returns>
        protected override string Visit(JsonBoolean jsonBoolean)
        {
            return jsonBoolean.Value.ToString();
        }

        /// <summary>
        /// Visit a JSON null.
        /// </summary>
        /// <param name="jsonNull">The JSON null to visit.</param>
        /// <returns>The type that was visited.</returns>
        protected override string Visit(JsonNull jsonNull)
        {
            return "null";
        }
    }
}

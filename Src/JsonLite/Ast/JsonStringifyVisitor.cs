using System.Globalization;
using System.Text;

namespace JsonLite.Ast
{
    public class JsonStringifyVisitor : JsonAstVisitor<string>, IJsonStringifyVisitor
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
            var builder = new StringBuilder().Append("[");

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
            var builder = new StringBuilder().Append("{");

            for (var i = 0; i < jsonObject.Members.Count; i++)
            {
                builder.Append(VisitMember(jsonObject.Members[i]));

                if (i < jsonObject.Members.Count - 1)
                {
                    builder.Append(",");
                }
            }

            builder.Append("}");

            return builder.ToString();
        }

        /// <summary>
        /// Visit a JSON member.
        /// </summary>
        /// <param name="jsonMember">The JSON member to visit.</param>
        /// <returns>The type that was visited.</returns>
        protected virtual string VisitMember(JsonMember jsonMember)
        {
            return $"\"{jsonMember.Name}\": {Visit(jsonMember.Value)}";
        }

        /// <summary>
        /// Visit a JSON string.
        /// </summary>
        /// <param name="jsonString">The JSON string to visit.</param>
        /// <returns>The type that was visited.</returns>
        protected override string Visit(JsonString jsonString)
        {
            var text = jsonString.Value
                .Replace("\\", "\\\\")
                .Replace("\b", "\\b")
                .Replace("\f", "\\f")
                .Replace("\n", "\\n")
                .Replace("\r", "\\r")
                .Replace("\t", "\\t")
                .Replace("\"", "\\\"");

            return $"\"{text}\"";
        }

        /// <summary>
        /// Visit a JSON number.
        /// </summary>
        /// <param name="jsonNumber">The JSON number to visit.</param>
        /// <returns>The type that was visited.</returns>
        protected override string Visit(JsonNumber jsonNumber)
        {
            return jsonNumber.Value.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Visit a JSON boolean.
        /// </summary>
        /// <param name="jsonBoolean">The JSON boolean to visit.</param>
        /// <returns>The type that was visited.</returns>
        protected override string Visit(JsonBoolean jsonBoolean)
        {
            return jsonBoolean.Value.ToString().ToLower();
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
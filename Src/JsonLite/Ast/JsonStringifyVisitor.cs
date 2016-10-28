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
            var text = new StringBuilder(@"""");

            for (var i = 0; i < jsonString.Value.Length; i++)
            {
                var ch = jsonString.Value[i];

                switch (ch)
                {
                    case '\\':
                        text.Append(@"\\");
                        break;

                    case '\b':
                        text.Append(@"\b");
                        break;

                    case '\f':
                        text.Append(@"\f");
                        break;

                    case '\n':
                        text.Append(@"\n");
                        break;

                    case '\r':
                        text.Append(@"\r");
                        break;

                    case '\t':
                        text.Append(@"\\t");
                        break;

                    case '\"':
                        text.Append(@"\""");
                        break;

                    case '\u0085':
                        text.Append(@"\u0085");
                        break;

                    case '\u2028':
                        text.Append(@"\u2028");
                        break;

                    case '\u2029':
                        text.Append(@"\u2029");
                        break;

                    default:
                        if (ch > 127)
                        {
                            text.Append(@"\u");
                            text.Append(((int)ch).ToString("x4"));
                            break;
                        }

                        text.Append(ch);
                        break;

                }
            }

            text.Append(@"""");

            return text.ToString();
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
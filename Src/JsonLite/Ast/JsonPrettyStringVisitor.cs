using System.Text;

namespace JsonLite.Ast
{
    public class JsonPrettyStringVisitor : JsonStringifyVisitor
    {
        int _depth;

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
                    builder.Append(", ");
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
            _depth += 2;

            var builder = new StringBuilder().Append("{").NewLine().Indent(_depth);

            for (var i = 0; i < jsonObject.Members.Count; i++)
            {
                builder.Append(VisitMember(jsonObject.Members[i]));

                if (i < jsonObject.Members.Count - 1)
                {
                    builder.Append(", ").NewLine().Indent(_depth);
                }
            }

            _depth -= 2;

            builder.NewLine().Indent(_depth).Append("}");

            return builder.ToString();
        }

        /// <summary>
        /// Visit a JSON member.
        /// </summary>
        /// <param name="jsonMember">The JSON member to visit.</param>
        /// <returns>The type that was visited.</returns>
        protected override string VisitMember(JsonMember jsonMember)
        {
            return $"\"{jsonMember.Name}\":{Visit(jsonMember.Value)}";
        }
    }
}
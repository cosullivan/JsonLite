using System;
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
            //_depth += 2;

            var builder = new StringBuilder().Append("["); //.NewLine().Indent(_depth);

            for (var i = 0; i < jsonArray.Count; i++)
            {
                builder.Append(Visit(jsonArray[i]));

                if (i < jsonArray.Count - 1)
                {
                    builder.Append(", ").NewLine().Indent(_depth);
                }
            }

            //_depth -= 2;

            builder.Append("]"); //.Indent(_depth);

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
                builder.Append(Visit(jsonObject.Members[i]));

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
        /// Visit a JSON pair.
        /// </summary>
        /// <param name="jsonPair">The JSON pair to visit.</param>
        /// <returns>The type that was visited.</returns>
        protected override string Visit(JsonMember jsonPair)
        {
            return $"{Visit(jsonPair.Name)} : {Visit(jsonPair.Value)}";
        }
    }
}

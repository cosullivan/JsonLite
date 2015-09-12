using System.IO;

namespace JsonLite.Ast
{
    public class JsonTextOutputVisitor : JsonAstVisitor
    {
        readonly TextWriter _writer;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="writer">The text writer to output to.</param>
        public JsonTextOutputVisitor(TextWriter writer)
        {
            _writer = writer;
        }

        /// <summary>
        /// Perform the output processing.
        /// </summary>
        /// <param name="jsonValue">The value to perform the processing from.</param>
        public void Output(JsonValue jsonValue)
        {
            Visit(jsonValue);
        }

        /// <summary>
        /// Visit the JSON array.
        /// </summary>
        /// <param name="jsonArray">The JSON array to visit.</param>
        protected override void Visit(JsonArray jsonArray)
        {
            _writer.Write("[");

            for (var i = 0; i < jsonArray.Count; i++)
            {
                Visit(jsonArray[i]);

                if (i < jsonArray.Count - 1)
                {
                    _writer.Write(",");
                }
            }

            _writer.Write("]");
        }

        /// <summary>
        /// Visit the JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object to visit.</param>
        protected override void Visit(JsonObject jsonObject)
        {
            _writer.Write("{");

            for (var i = 0; i < jsonObject.Members.Count; i++)
            {
                Visit(jsonObject.Members[i]);

                if (i < jsonObject.Members.Count - 1)
                {
                    _writer.Write(",");
                }
            }

            _writer.Write("}");
        }

        /// <summary>
        /// Visit a JSON pair.
        /// </summary>
        /// <param name="jsonPair">The JSON pair to visit.</param>
        protected override void Visit(JsonMember jsonPair)
        {
            Visit(jsonPair.Name);

            _writer.Write(":");

            Visit(jsonPair.Value);
        }

        /// <summary>
        /// Visit a JSON string.
        /// </summary>
        /// <param name="jsonString">The JSON string to visit.</param>
        protected override void Visit(JsonString jsonString)
        {
            _writer.Write($"\"{jsonString.Value}\"");
        }

        /// <summary>
        /// Visit a JSON integer.
        /// </summary>
        /// <param name="jsonInteger">The JSON integer to visit.</param>
        protected override void Visit(JsonInteger jsonInteger)
        {
            _writer.Write(jsonInteger.Value);
        }

        /// <summary>
        /// Visit a JSON decimal.
        /// </summary>
        /// <param name="jsonDecimal">The JSON decimal to visit.</param>
        protected override void Visit(JsonDecimal jsonDecimal)
        {
            _writer.Write(jsonDecimal.Value);
        }

        /// <summary>
        /// Visit a JSON boolean.
        /// </summary>
        /// <param name="jsonBoolean">The JSON boolean to visit.</param>
        protected override void Visit(JsonBoolean jsonBoolean)
        {
            _writer.Write(jsonBoolean.Value);
        }

        /// <summary>
        /// Visit a JSON null.
        /// </summary>
        /// <param name="jsonNull">The JSON null to visit.</param>
        protected override void Visit(JsonNull jsonNull)
        {
            _writer.Write("null");
        }
    }
}

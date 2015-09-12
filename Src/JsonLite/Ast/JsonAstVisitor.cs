namespace JsonLite.Ast
{
    public abstract class JsonAstVisitor
    {
        /// <summary>
        /// Visit the given JSON value.
        /// </summary>
        /// <param name="jsonValue">The JSON value to visit.</param>
        protected void Visit(JsonValue jsonValue)
        {
            if (jsonValue is JsonArray)
            {
                Visit((JsonArray)jsonValue);
            }
            else if (jsonValue is JsonObject)
            {
                Visit((JsonObject)jsonValue);
            }
            else if (jsonValue is JsonMember)
            {
                Visit((JsonMember)jsonValue);
            }
            else if (jsonValue is JsonString)
            {
                Visit((JsonString)jsonValue);
            }
            else if (jsonValue is JsonInteger)
            {
                Visit((JsonInteger)jsonValue);
            }
            else if (jsonValue is JsonDecimal)
            {
                Visit((JsonDecimal)jsonValue);
            }
            else if (jsonValue is JsonBoolean)
            {
                Visit((JsonBoolean)jsonValue);
            }
            else if (jsonValue is JsonNull)
            {
                Visit((JsonNull)jsonValue);
            }
            else
            {
                throw new JsonAstException("No support for the value if '{0}'.", jsonValue);
            }
        }

        /// <summary>
        /// Visit the JSON array.
        /// </summary>
        /// <param name="jsonArray">The JSON array to visit.</param>
        protected virtual void Visit(JsonArray jsonArray)
        {
            foreach (var jsonValue in jsonArray)
            {
                Visit(jsonValue);
            }
        }

        /// <summary>
        /// Visit the JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object to visit.</param>
        protected virtual void Visit(JsonObject jsonObject)
        {
            foreach (var member in jsonObject.Members)
            {
                Visit(member);
            }
        }

        /// <summary>
        /// Visit a JSON pair.
        /// </summary>
        /// <param name="jsonPair">The JSON pair to visit.</param>
        protected virtual void Visit(JsonMember jsonPair)
        {
            Visit(jsonPair.Value);
        }

        /// <summary>
        /// Visit a JSON string.
        /// </summary>
        /// <param name="jsonString">The JSON string to visit.</param>
        protected virtual void Visit(JsonString jsonString) { }

        /// <summary>
        /// Visit a JSON integer.
        /// </summary>
        /// <param name="jsonInteger">The JSON integer to visit.</param>
        protected virtual void Visit(JsonInteger jsonInteger) { }

        /// <summary>
        /// Visit a JSON decimal.
        /// </summary>
        /// <param name="jsonDecimal">The JSON decimal to visit.</param>
        protected virtual void Visit(JsonDecimal jsonDecimal) { }

        /// <summary>
        /// Visit a JSON boolean.
        /// </summary>
        /// <param name="jsonBoolean">The JSON boolean to visit.</param>
        protected virtual void Visit(JsonBoolean jsonBoolean) { }

        /// <summary>
        /// Visit a JSON null.
        /// </summary>
        /// <param name="jsonNull">The JSON null to visit.</param>
        protected virtual void Visit(JsonNull jsonNull) { }
    }
}

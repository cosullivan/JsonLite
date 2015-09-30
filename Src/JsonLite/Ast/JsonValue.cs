namespace JsonLite.Ast
{
    public abstract class JsonValue
    {
        /// <summary>
        /// Output the JSON value as a string.
        /// </summary>
        /// <returns>The JSON value of the node.</returns>
        public string Stringify()
        {
            return new JsonStringifyVisitor().Stringify(this);
        }
    }
}

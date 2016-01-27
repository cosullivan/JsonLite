namespace JsonLite.Ast
{
    public abstract class JsonValue
    {
        /// <summary>
        /// Output the JSON value as a string.
        /// </summary>
        /// <param name="prettify">Indicates whether the output should be prettified.</param>
        /// <returns>The JSON value of the node.</returns>
        public string Stringify(bool prettify = false)
        {
            return new JsonStringifyVisitor(prettify).Stringify(this);
        }
    }
}

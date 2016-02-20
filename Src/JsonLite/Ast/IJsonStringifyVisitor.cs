namespace JsonLite.Ast
{
    public interface IJsonStringifyVisitor
    {
        /// <summary>
        /// Perform the output processing.
        /// </summary>
        /// <param name="jsonValue">The value to perform the processing from.</param>
        /// <returns>The string representation of the JSON value.</returns>
        string Stringify(JsonValue jsonValue);
    }
}

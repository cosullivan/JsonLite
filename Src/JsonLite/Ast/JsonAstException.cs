namespace JsonLite.Ast
{
    public sealed class JsonAstException : JsonException
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="format">The message format.</param>
        /// <param name="args">The message arguments.</param>
        public JsonAstException(string format, params object[] args) : base(format, args) { }
    }
}

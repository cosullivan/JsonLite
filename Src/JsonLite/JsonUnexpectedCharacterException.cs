namespace JsonLite
{
    public sealed class JsonUnexpectedCharacterException : JsonException
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="ch">The character that was unexpected.</param>
        /// <param name="position">The position at which the characher occurred.</param>
        public JsonUnexpectedCharacterException(char ch, int position) : base("Unexpected character '{0}' at position {1}.", ch, position)
        {
            Ch = ch;
            Position = position;
        }

        /// <summary>
        /// Gets the last character that occurred.
        /// </summary>
        public char Ch { get; }

        /// <summary>
        /// Gets the position at which the last character occurred.
        /// </summary>
        public int Position { get; }
    }
}
namespace JsonLite
{
    public abstract class JsonReader
    {
        /// <summary>
        /// Returns the next token for consumption.
        /// </summary>
        /// <returns>The next token for consumption, or JsonToken.None 
        /// when there are no more tokens remaining.</returns>
        public abstract JsonToken NextToken();
    }
}
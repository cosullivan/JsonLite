namespace JsonLite
{
    public abstract class JsonParser
    {
        readonly JsonTokenEnumerator _enumerator;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="enumerator">The token enumerator to use when parsing the document.</param>
        protected JsonParser(JsonTokenEnumerator enumerator)
        {
            _enumerator = enumerator;
        }

        /// <summary>
        /// Indicates whether or not an array can be made from the current position.
        /// </summary>
        /// <returns>true if an array can be made, false if not.</returns>
        protected internal bool CanMakeArray()
        {
            return _enumerator.Peek() == JsonToken.StartArray;
        }

        /// <summary>
        /// Indicates whether or not an object can be made from the current position.
        /// </summary>
        /// <returns>true if an object can be made, false if not.</returns>
        protected internal bool CanMakeObject()
        {
            return _enumerator.Peek() == JsonToken.StartObject;
        }

        /// <summary>
        /// Indicates whether or not a pair can be made from the current position.
        /// </summary>
        /// <returns>true if a pair can be made from the current position, false if not.</returns>
        protected internal bool CanMakePair()
        {
            return _enumerator.Peek().Kind == JsonTokenKind.String && _enumerator.Peek(2) == JsonToken.Colon;
        }

        /// <summary>
        /// Returns a value indicating whether or not a string can be made from the current position.
        /// </summary>
        /// <returns>true if a string can be made, false if not.</returns>
        protected internal bool CanMakeString()
        {
            return _enumerator.Peek().Kind == JsonTokenKind.String;
        }

        /// <summary>
        /// Returns a value indicating whether or not an integer value can be made at the current position.
        /// </summary>
        /// <returns>true if a integer value can be made, false if not.</returns>
        protected internal bool CanMakeInteger()
        {
            return _enumerator.Peek().Kind == JsonTokenKind.Integer;
        }

        /// <summary>
        /// Returns a value indicating whether or not a fractional number can be made at the current position.
        /// </summary>
        /// <returns>true if a fractional number can be made, false if not.</returns>
        protected internal bool CanMakeDecimal()
        {
            return _enumerator.Peek().Kind == JsonTokenKind.Fractional;
        }

        /// <summary>
        /// Returns a value indicating whether or not a boolean value can be made at the current position.
        /// </summary>
        /// <returns>true if a boolean value can be made, false if not.</returns>
        protected internal bool CanMakeBoolean()
        {
            return _enumerator.Peek() == JsonToken.True || _enumerator.Peek() == JsonToken.False;
        }

        /// <summary>
        /// Returns a value indicating whether or not a null value can be made at the current position.
        /// </summary>
        /// <returns>true if a null value can be made, false if not.</returns>
        protected internal bool CanMakeNull()
        {
            return _enumerator.Peek() == JsonToken.Null;
        }

        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        protected JsonTokenEnumerator Enumerator
        {
            get { return _enumerator; }
        }
    }
}

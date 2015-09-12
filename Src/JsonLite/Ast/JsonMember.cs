namespace JsonLite.Ast
{
    public sealed class JsonMember : JsonValue
    {
        readonly JsonString _name;
        readonly JsonValue _value;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">The name of the pair.</param>
        /// <param name="value">The value for the pair.</param>
        public JsonMember(JsonString name, JsonValue value)
        {
            _name = name;
            _value = value;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">The name of the pair.</param>
        /// <param name="value">The value for the pair.</param>
        public JsonMember(string name, JsonValue value) : this(new JsonString(name), value) { }

        /// <summary>
        /// Gets the name of the pair.
        /// </summary>
        public JsonString Name
        {
            get { return _name; }
        }

        /// <summary>
        /// Gets the value for the pair.
        /// </summary>
        public JsonValue Value
        {
            get { return _value; }
        }
    }
}

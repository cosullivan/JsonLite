namespace JsonLite.Ast
{
    public sealed class JsonMember
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">The name of the pair.</param>
        /// <param name="value">The value for the pair.</param>
        public JsonMember(string name, JsonValue value)
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// Gets the name of the pair.
        /// </summary>
        public string Name { get; }
        
        /// <summary>
        /// Gets the value for the pair.
        /// </summary>
        public JsonValue Value { get; }
    }
}
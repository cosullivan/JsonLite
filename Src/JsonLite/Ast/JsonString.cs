using System.Diagnostics;

namespace JsonLite.Ast
{
    [DebuggerDisplay("[String] {Value}")]
    public sealed class JsonString : JsonValue, IJsonPrimitive
    {
        readonly string _value;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="value">The text string.</param>
        public JsonString(string value)
        {
            _value = value;
        }

        /// <summary>
        /// Gets the underlying CLR value.
        /// </summary>
        /// <returns>The CLR value.</returns>
        object IJsonPrimitive.GetClrValue()
        {
            return _value;
        }

        /// <summary>
        /// Gets the text string.
        /// </summary>
        public string Value
        {
            get { return _value; }
        }
    }
}

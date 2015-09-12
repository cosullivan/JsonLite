using System.Diagnostics;

namespace JsonLite.Ast
{
    [DebuggerDisplay("[Boolean] {Value}")]
    public sealed class JsonBoolean : JsonValue, IJsonPrimitive
    {
        public static readonly JsonBoolean True = new JsonBoolean(true);
        public static readonly JsonBoolean False = new JsonBoolean(false);

        readonly bool _value;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="value">The boolean value.</param>
        public JsonBoolean(bool value)
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
        /// Gets the boolean value.
        /// </summary>
        public bool Value
        {
            get { return _value; }
        }
    }
}

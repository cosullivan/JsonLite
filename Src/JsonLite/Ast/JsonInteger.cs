using System.Diagnostics;

namespace JsonLite.Ast
{
    [DebuggerDisplay("[Integer] {Value}")]
    public sealed class JsonInteger : JsonNumber, IJsonPrimitive
    {
        readonly long _value;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="value">The number.</param>
        public JsonInteger(long value)
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
        /// Gets the number.
        /// </summary>
        public long Value
        {
            get { return _value; }
        }
    }
}

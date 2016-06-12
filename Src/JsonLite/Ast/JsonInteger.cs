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
        /// Implicitly convert the integer to a decimal.
        /// </summary>
        /// <param name="integer">The integer to convert to a decimal.</param>
        public static implicit operator JsonDecimal(JsonInteger integer)
        {
            return new JsonDecimal(integer._value);
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

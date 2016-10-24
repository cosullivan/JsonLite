using System.Diagnostics;

namespace JsonLite.Ast
{
    [DebuggerDisplay("[Number] {Value}")]
    public sealed class JsonNumber : JsonValue, IJsonPrimitive
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="value">The fractional number.</param>
        public JsonNumber(decimal value)
        {
            Value = value;
        }

        /// <summary>
        /// Gets the underlying CLR value.
        /// </summary>
        /// <returns>The CLR value.</returns>
        object IJsonPrimitive.GetClrValue()
        {
            return Value;
        }

        /// <summary>
        /// Gets the fractional number.
        /// </summary>
        public decimal Value { get; }
    }
}
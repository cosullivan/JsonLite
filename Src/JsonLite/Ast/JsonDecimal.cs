using System.Diagnostics;

namespace JsonLite.Ast
{
    [DebuggerDisplay("[Decimal] {Value}")]
    public sealed class JsonDecimal : JsonNumber, IJsonPrimitive
    {
        readonly decimal _value;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="value">The fractional number.</param>
        public JsonDecimal(decimal value)
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
        /// Gets the fractional number.
        /// </summary>
        public decimal Value
        {
            get {  return _value; }
        }
    }
}

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
        /// Returns a value indicating the equality of the two objects.
        /// </summary>
        /// <param name="left">The left hand side of the comparisson.</param>
        /// <param name="right">The right hand side of the comparisson.</param>
        /// <returns>true if the left and right side are equal, false if not.</returns>
        static bool Equals(JsonBoolean left, JsonBoolean right)
        {
            if (ReferenceEquals(null, left) && ReferenceEquals(null, right))
            {
                return true;
            }

            if (ReferenceEquals(null, left) || ReferenceEquals(null, right))
            {
                return false;
            }

            return left._value == right._value;
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">Another object to compare to. </param>
        /// <returns>true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false. </returns>
        public override bool Equals(object obj)
        {
            return Equals(this, obj as JsonBoolean);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        /// <summary>
        /// Returns a value indicating the equality of the two objects.
        /// </summary>
        /// <param name="left">The left hand side of the comparisson.</param>
        /// <param name="right">The right hand side of the comparisson.</param>
        /// <returns>true if the left and right side are equal, false if not.</returns>
        public static bool operator ==(JsonBoolean left, JsonBoolean right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Returns a value indicating the inequality of the two objects.
        /// </summary>
        /// <param name="left">The left hand side of the comparisson.</param>
        /// <param name="right">The right hand side of the comparisson.</param>
        /// <returns>false if the left and right side are equal, true if not.</returns>
        public static bool operator !=(JsonBoolean left, JsonBoolean right)
        {
            return Equals(left, right) == false;
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

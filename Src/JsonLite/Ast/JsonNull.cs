using System.Diagnostics;

namespace JsonLite.Ast
{
    [DebuggerDisplay("[Null]")]
    public sealed class JsonNull : JsonValue, IJsonPrimitive
    {
        public static readonly JsonNull Instance = new JsonNull();

        /// <summary>
        /// Constructor.
        /// </summary>
        JsonNull() { }

        ///// <summary>
        ///// Returns a value indicating the equality of the two objects.
        ///// </summary>
        ///// <param name="left">The left hand side of the comparisson.</param>
        ///// <param name="right">The right hand side of the comparisson.</param>
        ///// <returns>true if the left and right side are equal, false if not.</returns>
        //static bool Equals(JsonNull left, JsonNull right)
        //{
        //    // if both arent null then they are both equal
        //    return ReferenceEquals(null, left) == false && ReferenceEquals(null, right) == false;
        //}

        ///// <summary>
        ///// Indicates whether this instance and a specified object are equal.
        ///// </summary>
        ///// <param name="obj">Another object to compare to. </param>
        ///// <returns>true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false. </returns>
        //public override bool Equals(object obj)
        //{
        //    return Equals(this, obj as JsonNull);
        //}

        ///// <summary>
        ///// Returns the hash code for this instance.
        ///// </summary>
        ///// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        //public override int GetHashCode()
        //{
        //    return typeof(JsonNull).GetHashCode();
        //}

        ///// <summary>
        ///// Returns a value indicating the equality of the two objects.
        ///// </summary>
        ///// <param name="left">The left hand side of the comparisson.</param>
        ///// <param name="right">The right hand side of the comparisson.</param>
        ///// <returns>true if the left and right side are equal, false if not.</returns>
        //public static bool operator ==(JsonNull left, JsonNull right)
        //{
        //    return Equals(left, right);
        //}

        ///// <summary>
        ///// Returns a value indicating the inequality of the two objects.
        ///// </summary>
        ///// <param name="left">The left hand side of the comparisson.</param>
        ///// <param name="right">The right hand side of the comparisson.</param>
        ///// <returns>false if the left and right side are equal, true if not.</returns>
        //public static bool operator !=(JsonNull left, JsonNull right)
        //{
        //    return Equals(left, right) == false;
        //}

        /// <summary>
        /// Gets the underlying CLR value.
        /// </summary>
        /// <returns>The CLR value.</returns>
        object IJsonPrimitive.GetClrValue()
        {
            return null;
        }
    }
}

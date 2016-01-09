using System;
using System.Diagnostics;

namespace JsonLite
{
    [DebuggerDisplay("[{Kind}] {Text}")]
    public struct JsonToken
    {
        public static readonly JsonToken None = new JsonToken(JsonTokenKind.None);
        public static readonly JsonToken StartArray = new JsonToken(JsonTokenKind.StartArray);
        public static readonly JsonToken EndArray = new JsonToken(JsonTokenKind.EndArray);
        public static readonly JsonToken StartObject = new JsonToken(JsonTokenKind.StartObject);
        public static readonly JsonToken EndObject = new JsonToken(JsonTokenKind.EndObject);
        public static readonly JsonToken Colon = new JsonToken(JsonTokenKind.Colon);
        public static readonly JsonToken Comma = new JsonToken(JsonTokenKind.Comma);
        public static readonly JsonToken True = new JsonToken(JsonTokenKind.True);
        public static readonly JsonToken False = new JsonToken(JsonTokenKind.False);
        public static readonly JsonToken Null = new JsonToken(JsonTokenKind.Null);

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="kind">The token kind.</param>
        JsonToken(JsonTokenKind kind) : this(kind, String.Empty)
        {
            Kind = kind;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="kind">The token kind.</param>
        /// <param name="text">The token text.</param>
        public JsonToken(JsonTokenKind kind, string text) : this()
        {
            Text = text;
            Kind = kind;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="kind">The token kind.</param>
        /// <param name="ch">The character to create the token from.</param>
        public JsonToken(JsonTokenKind kind, char ch) : this()
        {
            Text = ch.ToString();
            Kind = kind;
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="other">Another object to compare to. </param>
        /// <returns>true if <paramref name="other"/> and this instance are the same type and represent the same value; otherwise, false. </returns>
        public bool Equals(JsonToken other)
        {
            if (Kind == other.Kind)
            {
                return String.Equals(Text, other.Text, StringComparison.OrdinalIgnoreCase);
            }

            return false;
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">Another object to compare to. </param>
        /// <returns>true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false. </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) 
            {
                return false;
            }

            return obj is JsonToken && Equals((JsonToken)obj);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return ((Text?.GetHashCode() ?? 0) * 397) ^ (int)Kind;
            }
        }

        /// <summary>
        /// Returns a value indicating the equality of the two objects.
        /// </summary>
        /// <param name="left">The left hand side of the comparisson.</param>
        /// <param name="right">The right hand side of the comparisson.</param>
        /// <returns>true if the left and right side are equal, false if not.</returns>
        public static bool operator ==(JsonToken left, JsonToken right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Returns a value indicating the inequality of the two objects.
        /// </summary>
        /// <param name="left">The left hand side of the comparisson.</param>
        /// <param name="right">The right hand side of the comparisson.</param>
        /// <returns>false if the left and right side are equal, true if not.</returns>
        public static bool operator !=(JsonToken left, JsonToken right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Returns the string representation of the token.
        /// </summary>
        /// <returns>The string representation of the token.</returns>
        public override string ToString()
        {
            return $"[{Kind}] {Text}";
        }

        /// <summary>
        /// Gets the token text.
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// Gets the token kind.
        /// </summary>
        public JsonTokenKind Kind { get; }
    }
}

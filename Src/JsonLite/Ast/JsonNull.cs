using System.Diagnostics;

namespace JsonLite.Ast
{
    [DebuggerDisplay("[Null]")]
    public sealed class JsonNull : JsonValue, IJsonPrimitive
    {
        public static readonly JsonNull Instance = new JsonNull();

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

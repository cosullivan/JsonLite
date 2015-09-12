using System.Collections;
using System.Collections.Generic;

namespace JsonLite.Ast
{
    public sealed class JsonArray : JsonValue, IReadOnlyList<JsonValue>
    {
        readonly IReadOnlyList<JsonValue> _values;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="values">The list of values.</param>
        public JsonArray(IReadOnlyList<JsonValue> values)
        {
            _values = values;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.</returns>
        public IEnumerator<JsonValue> GetEnumerator()
        {
            return _values.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Gets the element at the specified index in the read-only list.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get. </param>
        /// <returns>The element at the specified index in the read-only list.</returns>
        public JsonValue this[int index]
        {
            get { return _values[index]; }
        }

        /// <summary>
        /// Gets the number of elements in the collection.
        /// </summary>
        /// <returns>The number of elements in the collection.</returns>
        public int Count
        {
            get { return _values.Count; }
        }
    }
}

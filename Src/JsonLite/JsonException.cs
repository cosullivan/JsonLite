using System;

namespace JsonLite
{
    public class JsonException : Exception
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="format">The message format.</param>
        /// <param name="args">The message arguments.</param>
        public JsonException(string format, params object[] args) : base(String.Format(format, args)) { }
    }
}

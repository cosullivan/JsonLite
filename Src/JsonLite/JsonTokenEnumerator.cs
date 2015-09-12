using System;
using System.Collections.Generic;
using System.Linq;

namespace JsonLite
{
    public sealed class JsonTokenEnumerator
    {
        readonly JsonReader _reader;
        readonly Queue<JsonToken> _tokenQueue = new Queue<JsonToken>();
        
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="reader">The JSON reader for reading the tokens.</param>
        public JsonTokenEnumerator(JsonReader reader)
        {
            _reader = reader;
        }

        /// <summary>
        /// Peek at a token in the stream.
        /// </summary>
        /// <param name="count">The number of tokens to look ahead.</param>
        /// <returns>The token at the given number of tokens past the current index, or Token.None if no token exists.</returns>
        public JsonToken Peek(int count = 1)
        {
            if (count < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            if (count <= _tokenQueue.Count)
            {
                return _tokenQueue.ElementAt(count - 1);
            }

            var token = JsonToken.None;

            var remaining = count - _tokenQueue.Count;
            while (remaining-- > 0 && (token = _reader.NextToken()) != JsonToken.None)
            {
                _tokenQueue.Enqueue(token);
            }

            return token;
        }

        /// <summary>
        /// Consume the given number of tokens.
        /// </summary>
        /// <param name="count">The number of tokens to consume.</param>
        /// <returns>The last token that was consumed.</returns>
        public JsonToken Take(int count = 1)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            var token = JsonToken.None;

            while (_tokenQueue.Count > 0 && count-- > 0)
            {
                token = _tokenQueue.Dequeue();
            }

            while (count-- > 0 && (token = _reader.NextToken()) != JsonToken.None)
            {
                // noop
            }

            return token;
        }

        /// <summary>
        /// Skips past the specified number of tokens.
        /// </summary>
        /// <param name="count">The number of tokens to skip.</param>
        public void Skip(int count = 1)
        {
            Take(count);
        }
    }
}

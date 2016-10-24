using System.Collections.Generic;
using System.Linq;

namespace JsonLite.Ast
{
    public sealed class JsonObject : JsonValue
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="members">The list of members.</param>
        public JsonObject(IReadOnlyList<JsonMember> members)
        {
            Members = members;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="members">The list of members.</param>
        public JsonObject(params JsonMember[] members) : this(members.ToList()) { }

        /// <summary>
        /// Gets the JSON value that represents the member with the given name.
        /// </summary>
        /// <param name="name">The name of the member to get the JSON value for.</param>
        /// <returns>The JSON value for the member with the given name.</returns>
        public JsonValue this[string name]
        {
            get { return Members.SingleOrDefault(m => m.Name == name)?.Value; }
        }

        /// <summary>
        /// Gets the list of JSON members.
        /// </summary>
        public IReadOnlyList<JsonMember> Members { get; }
    }
}
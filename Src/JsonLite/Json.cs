using System.IO;
using JsonLite.Ast;

namespace JsonLite
{
    public static class Json
    {
        /// <summary>
        /// Create a Json value from a JSON string.
        /// </summary>
        /// <param name="json">The JSON string to create the node from.</param>
        /// <returns>The Json Value that represents the top level item of the JSON AST.</returns>
        public static JsonValue CreateAst(string json)
        {
            using (var reader = new StringReader(json))
            {
                return new JsonAstParser(new JsonTextReader(reader)).CreateAst();
            }
        }

        /// <summary>
        /// Cretae a JSON AST from a stream.
        /// </summary>
        /// <param name="stream">The stream to create the AST from.</param>
        /// <returns>The JSON value that represents the top level of the JSON AST.</returns>
        public static JsonValue CreateAst(Stream stream)
        {
            return new JsonAstParser(new JsonTextReader(new StreamReader(stream))).CreateAst();
        }
    }
}

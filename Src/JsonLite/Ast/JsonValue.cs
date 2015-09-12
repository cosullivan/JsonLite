using System.IO;
using System.Text;

namespace JsonLite.Ast
{
    public abstract class JsonValue
    {
        /// <summary>
        /// Output the JSON value to a text writer.
        /// </summary>
        /// <param name="textWriter">The text writer to display the output to.</param>
        public void Stringify(TextWriter textWriter)
        {
            new JsonTextOutputVisitor(textWriter).Output(this);
        }

        /// <summary>
        /// Output the JSON value as a string.
        /// </summary>
        /// <returns>The JSON value of the node.</returns>
        public string Stringify()
        {
            var json = new StringBuilder();

            Stringify(new StringWriter(json));

            return json.ToString();
        }
    }
}

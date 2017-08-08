using System;
using System.Text;

namespace JsonLite.Ast
{
    internal static class StringBuilderExtensions
    {
        /// <summary>
        /// Indent the builder.
        /// </summary>
        /// <param name="builder">The builder to apply the indentation to.</param>
        /// <param name="depth">The depth of the indentation.</param>
        /// <returns>The string builder that was modified.</returns>
        internal static StringBuilder Indent(this StringBuilder builder, int depth)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            return builder.Append(' ', depth);
        }

        /// <summary>
        /// Add a new line to the builder.
        /// </summary>
        /// <param name="builder">The builder to apply the new line to.</param>
        /// <returns>The string builder that was modified.</returns>
        internal static StringBuilder NewLine(this StringBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            return builder.Append(Environment.NewLine);
        }
    }
}
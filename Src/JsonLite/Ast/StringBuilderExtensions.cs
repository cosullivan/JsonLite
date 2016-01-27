using System;
using System.Text;

namespace JsonLite.Ast
{
    internal static class StringBuilderExtensions
    {
        /// <summary>
        /// Indent the builder if the condition is met.
        /// </summary>
        /// <param name="builder">The builder to apply the indentation to.</param>
        /// <param name="condition">The condition to test before adding the indentation.</param>
        /// <param name="depth">The depth of the indentation.</param>
        /// <returns>The string builder that was modified.</returns>
        internal static StringBuilder IndentIf(this StringBuilder builder, bool condition, int depth)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (condition)
            {
                builder.Append(' ', depth);
            }

            return builder;
        }

        /// <summary>
        /// Add a new line to the builder if the condition is met.
        /// </summary>
        /// <param name="builder">The builder to apply the new line to.</param>
        /// <param name="condition">The condition to test before adding the new line.</param>
        /// <returns>The string builder that was modified.</returns>
        internal static StringBuilder NewLineIf(this StringBuilder builder, bool condition)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (condition)
            {
                builder.Append(Environment.NewLine);
            }

            return builder;
        }
    }
}

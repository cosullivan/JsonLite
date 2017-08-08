namespace JsonLite.Ast
{
    public interface IJsonPrimitive
    {
        /// <summary>
        /// Gets the underlying CLR value.
        /// </summary>
        /// <returns>The CLR value.</returns>
        object GetClrValue();
    }
}
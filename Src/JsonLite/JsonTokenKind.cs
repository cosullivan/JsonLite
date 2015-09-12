namespace JsonLite
{
    public enum JsonTokenKind
    {
        None,
        StartArray,
        EndArray,
        StartObject,
        EndObject,
        Colon,
        Comma,
        String,
        Integer,
        Fractional,
        True,
        False,
        Null
    }
}

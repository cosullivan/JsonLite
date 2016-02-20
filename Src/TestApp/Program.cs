using System;
using JsonLite.Ast;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var json = new JsonArray(
                new JsonObject(
                    new JsonMember("A", new JsonInteger(1)),
                    new JsonMember("B", new JsonInteger(2)),
                    new JsonMember("C", new JsonArray(new JsonInteger(1), new JsonInteger(2)))),
                new JsonObject(
                    new JsonMember("D", new JsonInteger(3)),
                    new JsonMember("E", new JsonInteger(4))));

            Console.WriteLine(json.Stringify(true));

            Console.WriteLine(JsonBoolean.False == JsonBoolean.True);
            Console.WriteLine(JsonBoolean.False == JsonBoolean.False);
            Console.WriteLine(JsonBoolean.False == null);
        }
    }
}

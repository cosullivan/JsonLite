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
                    new JsonMember("B", new JsonInteger(2))),
                new JsonObject(
                    new JsonMember("C", new JsonInteger(3)),
                    new JsonMember("D", new JsonInteger(4))));

            Console.WriteLine(json.Stringify(true));
        }
    }
}

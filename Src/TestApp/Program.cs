using System;
using JsonLite;
using JsonLite.Ast;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var json = new JsonArray(
            //    new JsonObject(
            //        new JsonMember("A", new JsonNumber(1)),
            //        new JsonMember("B", new JsonNumber(2)),
            //        new JsonMember("C", new JsonArray(new JsonNumber(1), new JsonNumber(2)))),
            //    new JsonObject(
            //        new JsonMember("D", new JsonNumber(3)),
            //        new JsonMember("E", new JsonNumber(4))));

            var nested = new JsonObject(
                new JsonMember("A", new JsonNumber(3)),
                new JsonMember("A", new JsonNumber(3.01m)),
                new JsonMember("A", new JsonNumber(3)));

            var array = new JsonArray(nested, nested, nested);
            var array2 = new JsonArray(new JsonNumber(3), new JsonNumber(2), new JsonNumber(1));

            JsonValue json = new JsonObject(
                new JsonMember("A", new JsonNumber(1)),
                new JsonMember("B", new JsonNumber(2)),
                new JsonMember("C",
                    new JsonObject(
                        new JsonMember("A", new JsonNumber(3)),
                        new JsonMember("A", new JsonNumber(3)),
                        new JsonMember("A", new JsonNumber(3)),
                        new JsonMember("ComplexArray", array),
                        new JsonMember("SimpleArray", array2))));

            //Console.WriteLine(json.Stringify(true));

            json = Json.CreateAst(json.Stringify(true));
        }
    }
}

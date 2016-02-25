using System;
using JsonLite.Ast;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var json = new JsonArray(
            //    new JsonObject(
            //        new JsonMember("A", new JsonInteger(1)),
            //        new JsonMember("B", new JsonInteger(2)),
            //        new JsonMember("C", new JsonArray(new JsonInteger(1), new JsonInteger(2)))),
            //    new JsonObject(
            //        new JsonMember("D", new JsonInteger(3)),
            //        new JsonMember("E", new JsonInteger(4))));

            var nested = new JsonObject(
                new JsonMember("A", new JsonInteger(3)),
                new JsonMember("A", new JsonInteger(3)),
                new JsonMember("A", new JsonInteger(3)));

            var array = new JsonArray(nested, nested, nested);
            var array2 = new JsonArray(new JsonInteger(3), new JsonInteger(2), new JsonInteger(1));

            var json = new JsonObject(
                new JsonMember("A", new JsonInteger(1)),
                new JsonMember("B", new JsonInteger(2)),
                new JsonMember("C", 
                    new JsonObject(
                        new JsonMember("A", new JsonInteger(3)),
                        new JsonMember("A", new JsonInteger(3)),
                        new JsonMember("A", new JsonInteger(3)),
                        new JsonMember("SDKLJ", array),
                        new JsonMember("SimpleArray", array2))));

            Console.WriteLine(json.Stringify(true));
        }
    }
}

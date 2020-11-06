using System;
using Newtonsoft.Json;

namespace Utils
{
    public static class UiHelper
    {
        public static void Print(string title, object dataObject)
        {
            Console.WriteLine(title);
            Console.WriteLine(JsonConvert.SerializeObject(dataObject, Formatting.Indented,  new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            }));
        }
        
        public static void Header(string header)
        {
            Console.WriteLine("#####################################################");
            Console.WriteLine(header);
            Console.WriteLine("#####################################################");
        }
        
        public static void End()
        {
            Console.WriteLine("#####################################################");
            Console.ReadKey();
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader r = new StreamReader(@"D:\test\test.json"))
            {
                string json = r.ReadToEnd();
                var stuff = JObject.Parse(json).Children().FirstOrDefault();
                foreach (var item in stuff)
                {
                    var t = item;
                    foreach (var f in t)
                    {
                        var tt = f.FirstOrDefault();
                        Console.WriteLine(f.ToString());
                        List<string> Locales =
                            tt.SelectToken("Localization")
                                .Select(locale => locale.Value<string>())
                                .ToList();
                        var ProgramName = tt.SelectToken("ProgramName").Value<string>();

                    }
                }
            }
            Console.ReadKey();
        }
    }
}

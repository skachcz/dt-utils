using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DtLib;

namespace Dtsetdate
{
    class Program
    {
        static void Main(string[] args)
        {

            ArgsData data = new ArgsData(args);

            setAttributes(data);

            Console.WriteLine("press key");
            Console.ReadLine();
        }

        static void setAttributes(ArgsData argd)
        {
            string path = argd.ValueArgs[0].Value;

            DateTime newDate;
            bool dateIsOk = DateTime.TryParse(argd.ValueArgs[1].Value, out newDate);

            if (dateIsOk) {

                DateFile dt = new DateFile(path);

                if (argd.NamedArgs.ContainsKey("set"))
                {
                    string atts = argd.NamedArgs["set"].Value;

                    // only allowed characters
                    if (atts.All(c => "acm".Contains(c)))
                    {
                        if (atts.Contains("a"))
                        {
                            dt.DateAccessed = newDate;
                        }

                        if (atts.Contains("c"))
                        {
                            dt.DateCreated = newDate;
                        }

                        if (atts.Contains("m"))
                        {
                            dt.DateModified = newDate;
                        }

                        dt.WriteDateAttributes();
                    }
                    else
                    {
                        Console.WriteLine("Nepovolene parametry");
                    }
                }

            }

        }
    }
}

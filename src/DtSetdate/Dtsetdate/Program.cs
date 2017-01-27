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
            if (argd.ValueArgs.Count != 2)
            {
                msg(Messages.getText(Messages.ERR_ARG_WRONG_NUMBER, new object[] { "Use: <filepath> <datetime> -set=<attributes>" }));
                return;
            }

            string path = argd.ValueArgs[0].Value;

            DateTime newDate;
            bool dateIsOk = DateTime.TryParse(argd.ValueArgs[1].Value, out newDate);

            if (dateIsOk) {

                try {

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
                            msg(Messages.getText(Messages.ERR_ARG_INVALID_VALUE, new object[] { "-set",
                                "Allowed values: acm" }));
                        }
                    }
                    else
                    {
                        msg(Messages.getText(Messages.ERR_ARG_IS_MANDATORY, new object[] { "-set",
                                "Allowed values: acm" }));
                    }

                }

                catch(System.IO.FileNotFoundException exc)
                {
                    msg(Messages.getText(Messages.ERR_FILE_NOT_FOUND, new object[] { path }));
                }
            }
           }

        static void msg(string text)
        {
            Console.WriteLine(text);
        }

        static void printHelp()
        {
            string help = "";

            msg(help);
        }


    }
}

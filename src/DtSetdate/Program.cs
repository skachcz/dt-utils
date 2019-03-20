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
        public static bool NoOutput
        {
            get;
            set;
        }

        public static bool IsError
        {
            get;
            set;
        }

        static void Main(string[] args)
        {
            ArgsData data = new ArgsData(args);

            processAttributes(data);

            if (IsError) {
                printHelp();
            }

            // Console.WriteLine("press key");
            // Console.ReadLine();
        }

        static void processAttributes(ArgsData argd)
        {
            if (argd.ValueArgs.Count != 2)
            {
                msg(Messages.getText(Messages.ERR_ARG_WRONG_NUMBER, new object[] { "Use: <filepath> <datetime> -set=<attributes>" }));
                IsError = true;                
                return;
            }

            string path = argd.ValueArgs[0].Value;

            DateTime newDate;
            bool dateIsOk = DateTime.TryParse(argd.ValueArgs[1].Value, out newDate);

            if (argd.NamedArgs.ContainsKey("quiet"))
            {
                NoOutput = true;
            }

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
                            IsError = true;
                        }
                    }
                    else
                    {
                        msg(Messages.getText(Messages.ERR_ARG_IS_MANDATORY, new object[] { "-set",
                                "Allowed values: acm" }));
                        IsError = true;
                    }

                }

                catch(System.IO.FileNotFoundException exc)
                {
                    msg(Messages.getText(Messages.ERR_FILE_NOT_FOUND, new object[] { path }));
                    IsError = true;
                }
            }
           }

        static void msg(string text)
        {
            if (!NoOutput)
            {
                Console.WriteLine(text);
            }
        }

        static void printHelp()
        {
            string help = Messages.INFO_UTILITY_NAME +
@"
Dtsetdate - sets date attributes for file

Use:
dtsetdate <filename> <date> <arguments>

Mandatory arguments:
-set=<values>  = which date atributte(s) will be changed
                 Possible values:
                    a - accessed
                    c - created
                    m - modified
                Values can be combined - example: -set=am

Optional arguments:
-quiet  = no output
";
            msg(help);
        }


    }
}

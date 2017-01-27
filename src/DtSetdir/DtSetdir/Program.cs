using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DtLib;

namespace DtSetdir
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
            if (argd.ValueArgs.Count != 3)
            {
                msg(Messages.getText(Messages.ERR_ARG_WRONG_NUMBER, new object[] { "Use: <dirpath> <filemask> <datetime> -set=<attributes> Optional: -offset=<offset>" }));
                return;
            }

            string path = argd.ValueArgs[0].Value;
            string mask = argd.ValueArgs[1].Value;

            DateTime newDate;
            bool dateIsOk = DateTime.TryParse(argd.ValueArgs[2].Value, out newDate);

            if (dateIsOk)
            {

                try
                {
                    DateDirectory dr = new DateDirectory(path, mask);

                    dr.SetDate = newDate;

                    #region set parameter
                    if (argd.NamedArgs.ContainsKey("set"))
                    {
                        string atts = argd.NamedArgs["set"].Value;

                        // only allowed characters
                        if (atts.All(c => "acm".Contains(c)))
                        {
                            if (atts.Contains("a"))
                            {
                                dr.SetDateAccessed = true;
                            }

                            if (atts.Contains("c"))
                            {
                                dr.SetDateCreated = true;
                            }

                            if (atts.Contains("m"))
                            {
                                dr.SetDateModified = true;
                            }

                        }
                        else
                        {
                            msg(Messages.getText(Messages.ERR_ARG_INVALID_VALUE, new object[] { "-set",
                                "Allowed values: acm" }));
                            return;
                        }
                        #endregion

                        #region offset parameter

                        if (argd.NamedArgs.ContainsKey("offset"))
                        {
                            try {
                                dr.SetOffset = argd.NamedArgs["offset"].Value;
                            }

                            catch (ArgumentException exc)
                            {
                                msg(Messages.getText(Messages.ERR_ARG_INVALID_VALUE, new object[] { "-offset",
                                "Examples: +5s -10h +3d" }));
                                return;
                            }
                        }
                        #endregion

                        // dr.WriteDateAttributes();

                    }
                    else
                    {
                        msg(Messages.getText(Messages.ERR_ARG_IS_MANDATORY, new object[] { "-set",
                                "Allowed values: acm" }));
                    }

                }

                catch (System.IO.FileNotFoundException exc)
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

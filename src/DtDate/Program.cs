using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DtLib;

namespace DtDate
{
    class Program
    {
        static void Main(string[] args)
        {
            DtLib.ArgsData data = new ArgsData(args);

            string format = "{0:yyyy-MM-dd-HH-mm}";

            if (data.NamedArgs.ContainsKey("format"))
            {
                format = data.NamedArgs["format"].Value;
            }

            try
            {
                Console.WriteLine(String.Format(format, DateTime.Now));
            }

            catch(System.FormatException exc)
            {
                Console.WriteLine(Messages.getText(Messages.ERR_ARG_INVALID_VALUE,
                    new object[] { "-format", "Visit: https://msdn.microsoft.com/en-us/library/8kb3ddd4(v=vs.110).aspx" }));
            }

            Console.ReadLine();

        }
    }
}

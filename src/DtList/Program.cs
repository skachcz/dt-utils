using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DtLib;

namespace Dtlist
{
    class Program
    {
        static void Main(string[] args)
        {
            string path;

            if (args.Length > 0)
            {
                path = args[0];
            }
            else
            {
                path = Directory.GetCurrentDirectory();
            }

            try
            {
                DateDirectory dir = new DateDirectory(path, "*.*");

                Console.WriteLine("{0,-19}\t{1,-19}\t{2,-19}\t{3}",
                    "Created", "Accessed", "Modified", "Filename"
                    );

                foreach (var f in dir.Files)
                {
                    Console.WriteLine("{0,-15}\t{1,-15}\t{2,-15}\t{3}",
                        f.DateCreated, f.DateAccessed, f.DateModified, f.Filename
                        );
                }
            }

            catch(System.IO.DirectoryNotFoundException)
            {
                Console.WriteLine(Messages.getText(Messages.ERR_FILE_NOT_FOUND,
                new object[] { path } ));

            }

            // Console.WriteLine("Press key");
            // Console.ReadLine();
        }

    }
}

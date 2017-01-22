using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtLib
{
    public class DateDirectory
    {
        public string PathMask { get; set; }
        public   List<DateFile> Files { get; }

        public DateDirectory(string path, string searchPattern)
        {
            Files = new List<DateFile>();

           // DirectoryInfo dirInfo = new DirectoryInfo(path);

/*            var filelist = from file in dirInfo.EnumerateFiles(searchPattern, SearchOption.TopDirectoryOnly)
                        orderby file ascending
                        select file; */

            var filelist = from file in Directory.GetFiles(path, searchPattern, SearchOption.TopDirectoryOnly)
                           orderby file ascending
                           select file;


            foreach (var f in filelist)
            {
               DateFile df = new DateFile(f);
               Files.Add(df);
            }


        }


    }
}

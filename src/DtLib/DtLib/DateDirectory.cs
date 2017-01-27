using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DtLib
{
    public class DateDirectory
    {
        private string offsetSign;
        private string offsetValue;
        private string offsetUnit;

        public DateTime SetDate { get; set; }
        public string SetOffset
        {
            set
            {
                setOffset(value);
            }
        }

        public bool SetDateCreated { get; set; }
        public bool SetDateAccessed { get; set; }
        public bool SetDateModified { get; set; }

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

        /// <summary>
        /// Allowed format - [+/-][number][timeunit - hms]
        /// </summary>
        /// <param name="offset"></param>
        private void setOffset(string offsetString)
        {
            string pattern = "([+-])([0-9]+)([ymdhms])";

            Match match = Regex.Match(offsetString, pattern, RegexOptions.IgnoreCase);

            if (match.Success)
            {
                offsetSign = match.Groups[1].Value;
                offsetValue = match.Groups[2].Value;
                offsetUnit = match.Groups[3].Value;
            }
            else
            {
                throw new ArgumentException("Wrong value format");
            }

            bool x = false;
        }


    }
}

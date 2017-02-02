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
        private int offsetSign;
        private int offsetValue;
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
            string pattern = "([+-])([0-9]+)([YMDhms])";

            Match match = Regex.Match(offsetString, pattern, RegexOptions.IgnoreCase);

            if (match.Success)
            {
                string sign = match.Groups[1].Value;
                if (sign == "-")
                {
                    offsetSign = -1;
                }
                else
                {
                    offsetSign = 1;
                }

                offsetValue = Convert.ToInt32(match.Groups[2].Value);
                offsetUnit = match.Groups[3].Value;
            }
            else
            {
                throw new ArgumentException("Wrong value format");
            }

            bool x = false;
        }

        private DateTime addDate(DateTime date)
        {
            int offset = offsetValue * offsetSign;

            switch (offsetUnit)
            {
                case "s":
                    return date.AddSeconds(offset);
                    break;
                case "m":
                    return date.AddMinutes(offset);
                    break;
                case "h":
                    return date.AddHours(offset);
                    break;
                case "D":
                    return date.AddDays(offset);
                    break;
                case "M":
                    return date.AddMonths(offset);
                    break;
                case "Y":
                    return date.AddYears(offset);
                    break;
                default:
                    return date;
                    break;
            }
        }


        public void WriteDateAttributes(bool writeToConsole)
        {
            DateTime date = SetDate;

            foreach (var f in Files)
            {


                if (SetDateAccessed)
                {
                    f.DateAccessed = date;
                }

                if (SetDateCreated)
                {
                    f.DateCreated = date;
                }

                if (SetDateModified)
                {
                    f.DateModified = date;
                }

                try
                {
                    f.WriteDateAttributes();
                }

                catch (System.IO.IOException exc)
                {
                    if (writeToConsole)
                    {
                        System.Console.WriteLine("ERROR: File " + f.FilePath + ", skipping.");
                    }
                }

                if (offsetValue > 0)
                {
                    date = addDate(date);
                }

                if (writeToConsole)
                {
                    System.Console.WriteLine("File " + f.FilePath + " set.");
                }

            }

        }

    }
}

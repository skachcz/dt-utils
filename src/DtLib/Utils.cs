using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtLib
{
    public static class Utils
    {

        public static string ToDateODBCFormat(DateTime date)
        {
            return String.Format("{0:d4}-{1:d2}-{2:d2} {3:d2}:{4:d2}:{5:d2}", 
                date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second);
        }

        public static DateTime FromDateODBCFormat(string text)
        {
            return new DateTime();
        }




    }
}

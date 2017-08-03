using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtLib
{
    public static class Messages
    {
        public const string INFO_UTILITY_NAME = "Dt Utils - Vladimir Skach (C) 2017";

        public const string ERR_FILE_NOT_FOUND = "File {0} not found";
        public const string ERR_ARG_IS_MANDATORY = "Parameter {0} has to be set. {1}";
        public const string ERR_ARG_INVALID_VALUE = "Parameter {0} has some invalid values. {1}";
        public const string ERR_ARG_WRONG_NUMBER = "The number of parameters is invalid. {0}";

        public static string getText(string key, object[] args)
        {
            return String.Format(key, args);
        }

    }
}

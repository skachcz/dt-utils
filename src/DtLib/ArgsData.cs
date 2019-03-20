using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtLib
{
    public class ArgsData
    {
        public Dictionary<int, ArgsItem> ValueArgs;
        public Dictionary<string, ArgsItem> NamedArgs;

        public ArgsData(string[] args)
        {
            int valueOrder = 0;

            ValueArgs = new Dictionary<int, ArgsItem>();
            NamedArgs = new Dictionary<string, ArgsItem>();

            foreach(string arg in args)
            {
                ArgsItem item = new ArgsItem(arg, valueOrder);

                if (item.IsNamedArgument)
                {
                    NamedArgs.Add(item.Key, item);
                }
                else
                {
                    ValueArgs.Add(valueOrder, item);
                    valueOrder++;
                }

            }
        }

    }

    public class ArgsItem {

        public string Key { get; set; }
        public string Value { get; set; }
        public bool IsNamedArgument { get; set; }

        public ArgsItem (string arg, int order)
        {

            if ( (!String.IsNullOrEmpty(arg)) && (arg[0] == '-'))
            {
                IsNamedArgument = true;

                int equalSign = arg.IndexOf('=');
                if (equalSign == -1)
                {
                    Key = arg.TrimStart('-');
                    Value = null;
                }
                else
                {
                    Key = arg.Substring(0, equalSign).TrimStart('-');
                    Value = arg.Substring(equalSign + 1);
                }

            }
            else
            {
                Key = order.ToString();
                Value = arg;
            }
        }

    }

}

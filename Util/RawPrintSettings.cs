using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RawPrintService.Util
{
    static class RawPrintSettings
    {
        public static Dictionary<string, string> Settings { get; set; }

        public static String Printer { get { return Settings["Printer"]; } }

        public static void Load(List<KeyValuePair<string,string>> values)
        {
            if (Settings == null) Settings = new Dictionary<string, string>();

            foreach (var item in values)
            {
                Settings.Add(item.Key, item.Value);
            }
        }
    }
}

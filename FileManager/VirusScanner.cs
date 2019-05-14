using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace FileManager
{
    static class VirusScanner
    {
        
        public static int MalwareSize { get; set; }

        static VirusScanner()
        {
            int malwareSize = Convert.ToInt32(ConfigurationManager.AppSettings["MalwareSize"]);

        }
        public static bool IsFileInfected(MyFile MyFile)
        {
           bool value = false;

            if (MyFile.FileSize == MalwareSize)
            {
                return value = true;
            }
            return value;
        }
    }
}

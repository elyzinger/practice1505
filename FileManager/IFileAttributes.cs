using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    interface IFileAttributes
    {
         int FileSize { get; }
         bool IsReadOnly { get; }
         bool IsArchiveFile { get;  }
        bool IsInfected { get;  }
        void PrintFile();
    }
}

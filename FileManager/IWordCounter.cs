using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    interface IWordCounter
    {
        int NumberOfPages { get; }
        int NumberOfWords { get; }
        string this[int i] { get; }
        
        





    }
}

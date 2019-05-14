using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager 
{
    class ImageFile <T>: MyFile
    {
        
        public int[,] Colors { get; set; }
        //public ImageFile(int[,] colors) //// cant do that!!!!
        //{
        //   Colors = colors;
        //}

        public ImageFile(int[,] colors, int fileSize, bool readOnly, bool archiveFile) : base(fileSize, readOnly, archiveFile)
        {
             Colors = colors;
        }

        public override void PrintFile()
        {
            for (int i = 0; i < Colors.GetLength(0); i++)
            {
                for (int j = 0; j < Colors.GetLength(1); j++)
                {
                    Console.WriteLine(Colors[i,j]);
                }
            }
        }
    }
}

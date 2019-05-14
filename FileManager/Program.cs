using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            WordFile words = new WordFile("how are you", 4, false, false);
            words.PrintFile();

            Random randomGenerator = new Random();
           
            int[,] colors = new int[2, 8];
            for(int i = 0; i < colors.GetLength(0); i++)
            {
                for (int j = 0; j < colors.GetLength(1); j++)
                {
                    colors[i,j] = randomGenerator.Next(0, 4);
                }
            }
            ImageFile imageFile = new ImageFile(colors, 4, false, false);
            imageFile.PrintFile();

            Console.ReadLine();
        }
    }
}

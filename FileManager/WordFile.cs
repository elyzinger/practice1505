using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    class WordFile : MyFile, IWordCounter, ISpecificWordCount
    {
        public string Text { get; set; }
        Dictionary<string, int> words;
        public WordFile(string textFile,string filePath, int fileSize, bool readOnly, bool archiveFile) : base(filePath ,fileSize, readOnly, archiveFile)
        {      
            this.Text = textFile;
            words = new Dictionary<string, int>();
            AddText(this);       
        }
        internal void AddText(WordFile textword)
        {
            if (words.ContainsKey(textword.Text))
            {
                Console.WriteLine("text already exist");
            }
            words.Add(textword.Text, Text.Split(' ').Length);
        }
        public int GetSpecificWordCount(string word)
        {       
                int wordCount = 0;
            if (words.ContainsKey(word))
            {
                string[] allwords = Text.Split(' ');
                foreach (string w in allwords)
                {
                    if (w == word)
                    {
                        wordCount++;
                    }
                }
            }
        
            return wordCount;
        }
     
        public int NumberOfWords
        {
            get
            {
                return Text.Split(' ').Length;

            }
        }
        public int NumberOfPages
        {
            get
            {
                return Text.Split(' ').Length / 10;
            }

        } 


        public string this[int indexer] 
        {
            get { return this[indexer]; }
            set { this[indexer] = value; }
        }

        public override void PrintFile()
        {
            for(int i = 0; i < Text.Split(' ').Length; i++)
            {
                Console.WriteLine(Text.Split(' ')[i]);
            } 
        }
        public static bool operator ==(WordFile thisfile, WordFile otherfile)
        {
            if (ReferenceEquals(thisfile, null) && ReferenceEquals(otherfile, null))
                return true;
            if (ReferenceEquals(thisfile, null) || ReferenceEquals(otherfile, null))
                return false;
            return thisfile.Text == otherfile.Text;

        }
        public static bool operator !=(WordFile thisfile, WordFile otherfile)
        {
            return !(thisfile == otherfile);
        }
        public override bool Equals(object obj)
        {
            var file = obj as WordFile;
            if (ReferenceEquals(file, null))
                return false;

            return this.Text == file.Text;
        }
        public static WordFile operator + (WordFile wordfile1, WordFile wordfile2)
        {
            WordFile bigger = (wordfile1.FileSize > wordfile2.FileSize) ? wordfile1 : wordfile2;
            return new WordFile(wordfile1.Text + wordfile2.Text,bigger.FilePath + ".mrg", wordfile1.FileSize + wordfile2.FileSize,bigger.IsReadOnly ,bigger.IsArchiveFile);
                      
        }

        public override int GetHashCode()
        {
            return this.Text.GetHashCode();
        }


    }
}

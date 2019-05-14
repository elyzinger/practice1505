using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    abstract class MyFile : IFileAttributes , IComparable<MyFile>
    {
        readonly string filePath ;
        const bool hebrewFile = true;
        public int FileSize { get;private set; }
        public bool IsReadOnly { get; private set; }
        public bool IsArchiveFile  { get; private set; }
        public string FilePath
        {
            get
            {
                return filePath;
            }
        }
        public bool IsInfected
        {
            get
            {
                return IsInfected;
            }
            set
            {
                if (IsInfected == true)
                {
                    throw new  InfectedFileDetectedException($"file has a virus{filePath}");
                }
            }
        } 
        List<string> paths = new List<string>();
    
        protected MyFile(string filePath)
        {
            this.filePath = filePath;
            paths.Add(filePath);
        }

        public MyFile(string filePath,int fileSize, bool readOnly, bool archiveFile) : this(filePath)
        {
            
            
            FileSize = fileSize;
            IsReadOnly = readOnly;
            IsArchiveFile = archiveFile;
            IsInfected = VirusScanner.IsFileInfected(this);
            
        }
        public static bool operator ==(MyFile thisfile, MyFile otherfile)
        {
            if(ReferenceEquals(thisfile, null) && ReferenceEquals(otherfile, null))       
                return true;
            if (ReferenceEquals(thisfile, null) || ReferenceEquals(otherfile, null))
                return false;
            return thisfile.FilePath == otherfile.FilePath;

        }
        public static bool operator !=(MyFile thisfile, MyFile otherfile)
        {
            return !(thisfile == otherfile);
        }
        public override bool Equals(object obj)
        {
            var file = obj as MyFile;
            if (ReferenceEquals(file, null))
                return false;

            return  this.FilePath == file.FilePath;
        }

        public override int GetHashCode()
        {
            return this.FilePath.GetHashCode();
        }

      
        public abstract void PrintFile();
        public int CompareTo(MyFile file)
        {
            return this.FileSize - file.FileSize;
        }

    }
}

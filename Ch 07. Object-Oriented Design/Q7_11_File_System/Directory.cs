using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_11_File_System
{
    public class Directory : Entry
    {
        protected IList<Entry> contents;

        public Directory(string n, Directory p) : base(n, p)
        {
            contents = new List<Entry>();
        }

        protected IList<Entry> GetContents()
        {
            return contents;
        }

        public override int Size()
        {
            int size = 0;
            foreach (Entry e in contents)
            {
                size += e.Size();
            }
            return size;
        }

        public int NumberOfFiles()
        {
            int count = 0;
            foreach (Entry e in contents)
            {
                if (e is Directory)
                {
                    count++; // Directory counts as a file
                    Directory d = (Directory)e;
                    count += d.NumberOfFiles();
                }
                else if (e is File)
                {
                    count++;
                }
            }
            return count;
        }

        public bool DeleteEntry(Entry entry)
        {
            return contents.Remove(entry);
        }

        public void AddEntry(Entry entry)
        {
            contents.Add(entry);
        }
    }
}

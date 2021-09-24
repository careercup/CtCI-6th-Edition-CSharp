using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_26_Sparse_Similarity
{
    public class Element : IComparable<Element>
    {
        public int Word { get; private set; }
        public int Document { get; private set; }
        public Element(int w, int d)
        {
            Word = w;
            Document = d;
        }

        public int CompareTo(Element e)
        {
            if (Word == e.Word)
            {
                return Document - e.Document;
            }
            return Word - e.Word;
        }
    }
}

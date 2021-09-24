using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_25_Word_Rectangle
{
    public class Q17_25_Word_Rectangle_Test : Question
    {
        public override void Run()
        {
            Q17_25_Word_Rectangle dict = new Q17_25_Word_Rectangle(AssortedMethods.GetListOfWords());
            Rectangle rect = dict.MaxRectangleA();
            if (rect != null)
            {
                rect.Print();
            }
            else
            {
                Console.WriteLine("No rectangle exists");
            }
        }
    }
}

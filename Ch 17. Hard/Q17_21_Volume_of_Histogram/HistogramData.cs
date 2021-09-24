using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_21_Volume_of_Histogram
{
    public class HistogramData
    {

        private int height;
        private int leftMaxIndex = -1;
        private int rightMaxIndex = -1;

        public HistogramData(int v)
        {
            height = v;
        }

        public int GetHeight() { return height; }
        public int GetLeftMaxIndex() { return leftMaxIndex; }
        public void SetLeftMaxIndex(int idx) { leftMaxIndex = idx; }
        public int GetRightMaxIndex() { return rightMaxIndex; }
        public void SetRightMaxIndex(int idx) { rightMaxIndex = idx; }
    }
}

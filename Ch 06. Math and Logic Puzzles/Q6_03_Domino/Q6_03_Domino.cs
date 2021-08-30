using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_06._Math_and_Logic_Puzzles.Q6_03_Domino
{
    public class Q6_03_Domino
    {
        public bool IsInsertAllDominos()
        {
            // 不可能
            // 棋盤最初有 32黑、32白，去掉對角後(一定會是相同顏色)，剩下 (30,32)
            // 骨牌 一黑一白需要 31黑和31白，所以無法完成條件
            return false;
        }

    }
}

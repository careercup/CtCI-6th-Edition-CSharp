using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_06._Math_and_Logic_Puzzles.Q6_02_Gamble_Choose
{
    public class Q6_02_Gamble_Choose
    {
        // 0 <= rate <= 1
        public int GambleChoose(double p)
        {
            // 3球全進機率 ^3
            // 3球進2球機率 3*(1-p)*p^2
            // p > 3p^2-2p^3 = (2p-1)(p-1)>0
            // p= 0, 0.5,1 2種玩法贏的機率相同
            return p < 0.5 ? 1 : 2;
        }
    }
}

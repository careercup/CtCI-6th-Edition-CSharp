using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ch_06._Math_and_Logic_Puzzles.Q6_01_Find_Heavy_bottle
{
    public class Q6_01_Find_Heavy_bottle:Question
    {
        public int HeavyBottleNumber(double totalWeitght)
        {
            // 瓶子1取1顆藥丸、瓶子2取2顆藥丸以此推，都是1克重的話種共為(1+2+3+..+20)=210
            return (int)((totalWeitght - 210) / 0.1);
        }

        public override void Run()
        {
            double totalWeight = 211.3;
            Console.WriteLine($"Heavy bottle is number {HeavyBottleNumber(totalWeight)}.");
        }
    }
}

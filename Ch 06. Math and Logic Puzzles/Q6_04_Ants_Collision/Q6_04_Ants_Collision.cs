using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_06._Math_and_Logic_Puzzles.Q6_Q4_Ants_Collision
{
    public class Q6_04_Ants_Collision
    {
        public double CollisionRate(int n)
        {
            // P(順時針)=(1/2)^n
            // P(逆時針)=(1/2)^n
            // P(同方向)=(1/2)^n-1
            // P(相撞)=1 - (1/2)^n-1
            return 1 - Math.Pow(0.5, n - 1);
        }
    }
}

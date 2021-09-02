using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_02_Call_Center
{
    class Manager : Employee
    {
        public Manager(CallHandler callHandler) : base(callHandler)
        {
            rank = Rank.Manager;
        }
    }
}

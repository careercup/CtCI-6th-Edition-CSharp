using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_15._Threads_and_Locks.Q15_07_FizzBuzz
{
    public class Q15_07_FizzBuzzC : Question
    {
        public override void Run()
        {
            int n = 100;
            FBThread[] threads = {new FBThread( i => i % 3 == 0 && i % 5 == 0, i => "FizzBuzz", n),
                            new FBThread(i => i % 3 == 0 && i % 5 != 0, i => "Fizz", n),
                            new FBThread(i => i % 3 != 0 && i % 5 == 0, i => "Buzz", n),
                            new FBThread(i => i % 3 != 0 && i % 5 != 0, i => i.ToString(), n)};
            foreach (FBThread thread in threads)
            {
                thread.Start();
            }
        }
    }
}

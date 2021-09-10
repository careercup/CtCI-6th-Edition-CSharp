using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_15._Threads_and_Locks.Q15_07_FizzBuzz
{
    // 多執行緒
    public class Q15_07_FizzBuzzB : Question
    {
        public override void Run()
        {
            int n = 100;
            FizzBuzzThread[] threads = {new FizzBuzzThread(true, true, n, "FizzBuzz"),
                            new FizzBuzzThread(true, false, n, "Fizz"),
                            new FizzBuzzThread(false, true, n, "Buzz"),
                            new NumberThread(false, false, n)};
            foreach (FizzBuzzThread thread in threads)
            {
                thread.Start();
            }
        }
    }
}

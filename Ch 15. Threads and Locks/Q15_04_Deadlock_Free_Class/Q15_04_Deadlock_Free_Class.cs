using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_15._Threads_and_Locks.Q15_04_Deadlock_Free_Class
{
    public class Q15_04_Deadlock_Free_Class : Question
    {
        public override void Run()
        {
			int[] res1 = { 1, 2, 3, 4 };
			int[] res2 = { 1, 5, 4, 1 };
			int[] res3 = { 1, 4, 5 };

			LockFactory.initialize(10);

			LockFactory lf = LockFactory.getInstance();
			Console.WriteLine(lf.declare(1, res1));
			Console.WriteLine(lf.declare(2, res2));
			Console.WriteLine(lf.declare(3, res3));

			Console.WriteLine(lf.getLock(1, 1));
			Console.WriteLine(lf.getLock(1, 2));
			Console.WriteLine(lf.getLock(2, 4));
		}
    }
}

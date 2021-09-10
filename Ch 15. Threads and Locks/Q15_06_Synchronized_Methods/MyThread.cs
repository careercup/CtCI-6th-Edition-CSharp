using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ch_15._Threads_and_Locks.Q15_06_Synchronized_Methods
{
    public class MyThread
    {
		private Foo foo;
		public string Name { get; private set; }
		public string FirstMethod { get; private set; }
		private Thread _thread;
		public MyThread(Foo f, string nm, string fM)
		{
			foo = f;
			Name = nm;
			FirstMethod = fM;
			_thread = new Thread(Run);
		}

		// Thread methods / properties
		public void Start() => _thread.Start();
		public void Join() => _thread.Join();
		public bool IsAlive => _thread.IsAlive;


		public void Run()
		{
			if (FirstMethod.Equals("A"))
			{
				foo.MethodA(Name);
			}
			else
			{
				foo.MethodB(Name);
			}
		}
	}
}

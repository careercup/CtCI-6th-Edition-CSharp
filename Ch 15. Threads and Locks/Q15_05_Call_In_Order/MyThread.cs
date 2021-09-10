using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ch_15._Threads_and_Locks.Q15_05_Call_In_Order
{
    public class MyThread
    {
        private string method;
        private FooBad foo;
        private Thread _thread;

        public MyThread(FooBad foo, string method)
        {
            this.method = method;
            this.foo = foo;
            _thread = new Thread(Run);
        }

        // Thread methods / properties
        public void Start() => _thread.Start();
        public void Join() => _thread.Join();
        public bool IsAlive => _thread.IsAlive;

        public void Run()
        {
            if (method == "first")
            {
                foo.First();
            }
            else if (method == "second")
            {
                foo.Second();
            }
            else if (method == "third")
            {
                foo.Third();
            }
        }
    }
}

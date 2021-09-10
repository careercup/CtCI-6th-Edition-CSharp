using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ch_15._Threads_and_Locks.IntroductionSynchronizedBlocksC
{
    public class MyClass
    {
        private string name;
        private MyObject myObj;
        private Thread _thread;

        public MyClass(MyObject obj, string n)
        {
            name = n;
            myObj = obj;
            _thread = new Thread(Run);
        }

        // Thread methods / properties
        public void Start() => _thread.Start();
        public void Join() => _thread.Join();
        public bool IsAlive => _thread.IsAlive;


        public void Run()
        {
            myObj.Foo(name);
        }
    }
}

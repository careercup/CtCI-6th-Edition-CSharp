using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ch_15._Threads_and_Locks.IntroductionWaitNotifyE
{
    // 需要 lock 物件 才能執行 Monitor.Wait 和 Monitor.Pulse 方法
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
            lock (myObj)
            {
                try
                {
                    Monitor.Wait(myObj, 1000);
                    myObj.Foo(name);
                    Monitor.Pulse(myObj);
                }
                catch (ThreadInterruptedException e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
        }
    }
}

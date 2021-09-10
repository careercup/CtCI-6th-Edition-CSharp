using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ch_15._Threads_and_Locks.Q15_07_FizzBuzz
{
    public class FBThread
    {
        private static Object myLock = new Object();
        protected static int current = 1;
        private int max;
        private Predicate<int> validate;
        private Func<int, string> printer;
        int x = 1;
        private Thread _thread;

        public FBThread(Predicate<int> validate, Func<int, string> printer, int max)
        {
            this.validate = validate;
            this.printer = printer;
            this.max = max;
            _thread = new Thread(Run);
        }

        // Thread methods / properties
        public void Start() => _thread.Start();
        public void Join() => _thread.Join();
        public bool IsAlive => _thread.IsAlive;

        public void Run()
        {
            while (true)
            {
                lock (myLock)
                {
                    if (current > max)
                    {
                        return;
                    }
                    if (validate.Invoke(current))
                    {
                        Console.WriteLine(printer.Invoke(current));
                        current++;
                    }
                }
            }
        }
    }
}

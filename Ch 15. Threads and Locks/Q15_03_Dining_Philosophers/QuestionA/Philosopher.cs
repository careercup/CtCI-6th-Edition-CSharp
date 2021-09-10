using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ch_15._Threads_and_Locks.Q15_03_Dining_Philosophers.QuestionA
{
    public class Philosopher
    {
        private readonly int maxPause = 100;
        private int bites = 10;

        private Chopstick left;
        private Chopstick right;
        private int index;
        private Thread _thread;

        public Philosopher(int i, Chopstick left, Chopstick right)
        {
            index = i;
            this.left = left;
            this.right = right;
            _thread = new Thread(Run);
        }

        // Thread methods / properties
        public void Start() => _thread.Start();
        public void Join() => _thread.Join();
        public bool IsAlive => _thread.IsAlive;

        public void Eat()
        {
            Console.WriteLine("Philosopher " + index + ": start eating");
            if (PickUp())
            {
                chew();
                PutDown();
                Console.WriteLine("Philosopher " + index + ": done eating");
            }
            else
            {
                Console.WriteLine("Philosopher " + index + ": gave up on eating");
            }
        }

        public bool PickUp()
        {
            Pause();
            if (!left.PickUp())
            {
                return false;
            }
            Pause();
            if (!right.PickUp())
            {
                left.PutDown();
                return false;
            }
            Pause();
            return true;
        }

        public void chew()
        {
            Console.WriteLine("Philosopher " + index + ": eating");
            Pause();
        }

        public void Pause()
        {
            try
            {
                int pause = AssortedMethods.RandomIntInRange(0, maxPause);
                Thread.Sleep(pause);
            }
            catch (ThreadInterruptedException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public void PutDown()
        {
            right.PutDown();
            left.PutDown();
        }

        public void Run()
        {
            for (int i = 0; i < bites; i++)
            {
                Eat();
            }
        }
    }
}

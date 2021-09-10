using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_15._Threads_and_Locks.Q15_03_Dining_Philosophers.QuestionB
{
    // 個人不太了解...
    // 方案2: 筷子優先權
    // 哲學家不會在沒有拿到較小者實拿起較大者，可防止環產生
    // 環表示較高的筷子會指向較低的筷子
    public class Q15_03_Dining_PhilosophersB : Question
    {
        public static int Size { get; private set; } = 3;

        public static int LeftOf(int i)
        {
            return i;
        }

        public static int RightOf(int i)
        {
            return (i + 1) % Size;
        }

        public override void Run()
        {
            Chopstick[] chopsticks = new Chopstick[Size + 1];
            for (int i = 0; i < Size + 1; i++)
            {
                chopsticks[i] = new Chopstick(i);
            }

            Philosopher[] philosophers = new Philosopher[Size];
            for (int i = 0; i < Size; i++)
            {
                Chopstick left = chopsticks[LeftOf(i)];
                Chopstick right = chopsticks[RightOf(i)];
                philosophers[i] = new Philosopher(i, left, right);
            }

            for (int i = 0; i < Size; i++)
            {
                philosophers[i].Start();
            }
        }
    }
}

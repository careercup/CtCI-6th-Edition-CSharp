using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_06._Math_and_Logic_Puzzles.Introduction
{
    public class SieveOfEratosthenesB : Question
    {
        public static bool[] SieveOfEratosthenes(int max)
        {
            bool[] flags = new bool[max + 1];

            Init(flags);
            int prime = 2;

            while (prime <= Math.Sqrt(max))
            {
                /* Cross off remaining multiples of prime */
                CrossOff(flags, prime);

                /* Find next value which is true */
                prime = GetNextPrime(flags, prime);
            }

            return flags; //prune(flags, count);
        }

        public static void CrossOff(bool[] flags, int prime)
        {
            /* Cross off remaining multiples of prime. We can start with
             * (prime*prime), because if we have a k * prime, where k < prime,
             * this value would have already been crossed off in a prior
             * iteration. */
            for (int i = prime * prime; i < flags.Length; i += prime)
            {
                flags[i] = false;
            }
        }

        public static int GetNextPrime(bool[] flags, int prime)
        {
            int next = prime + 1;
            while (next < flags.Length && !flags[next])
            {
                next++;
            }
            return next;
        }

        public static void Init(bool[] flags)
        {
            flags[0] = false;
            flags[1] = false;
            for (int i = 2; i < flags.Length; i++)
            {
                flags[i] = true;
            }
        }

        public static int[] Prune(bool[] flags, int count)
        {
            int[] primes = new int[count];
            int index = 0;
            for (int i = 0; i < flags.Length; i++)
            {
                if (flags[i])
                {
                    primes[index] = i;
                    index++;
                }
            }
            return primes;
        }

       

        public override void Run()
        {
            bool[] primes = SieveOfEratosthenes(4);
            for (int i = 0; i < primes.Length; i++)
            {
                if (primes[i])
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}

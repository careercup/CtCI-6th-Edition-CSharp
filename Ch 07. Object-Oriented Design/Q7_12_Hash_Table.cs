using System;
using ctci.Contracts;

namespace Chapter07
{
    public class Q7_12_Hash_Table: Question 
    {
        public override void Run()
        { 
            Dummy bob = new Dummy("Bob", 20);
            Dummy jim = new Dummy("Jim", 25);
            Dummy alex = new Dummy("Alex", 30);
            Dummy tim = new Dummy("Tim", 35);
            Dummy maxwell = new Dummy("Maxwell", 40);
            Dummy john = new Dummy("John", 45);
            Dummy julie = new Dummy("Julie", 50);
            Dummy christy = new Dummy("Christy", 55);
            Dummy tim2 = new Dummy("Tim", 100); // This should replace the first "tim"

            Dummy[] dummies = { bob, jim, alex, tim, maxwell, john, julie, christy, tim2 };

            /* Test: Insert Elements. */
            Hasher<String, Dummy> hash = new Hasher<String, Dummy>(3);
            foreach (Dummy d in dummies)
            {
                Console.WriteLine(hash.Put(d.Name, d));
            }

            hash.PrintTable();

            /* Test: Recall */
            foreach (Dummy d in dummies)
            {
                String name = d.Name;
                Dummy dummy = hash.Get(name);
                if (dummy == null)
                {
                    Console.WriteLine($"Dummy named {name}: null");
                }
                else
                {
                    Console.WriteLine($"Dummy named {name}: {dummy}");
                }
                Dummy d2 = hash.Remove(name);
                if (d2 == null)
                {
                    Console.WriteLine($"Dummy removed named {name}: null");
                }
                else
                {
                    Console.WriteLine($"Dummy removed named {name}: {d2}");
                }
            }        
        }
    }
}

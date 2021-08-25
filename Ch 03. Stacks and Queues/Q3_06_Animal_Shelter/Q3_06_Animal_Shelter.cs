using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_03._Stacks_and_Queues.Q3_06_Animal_Shelter
{
    public class Q3_06_Animal_Shelter : Question
    {
        public override void Run()
        {
			AnimalQueue animals = new AnimalQueue();
			animals.Enqueue(new Cat("Callie"));
			animals.Enqueue(new Cat("Kiki"));
			animals.Enqueue(new Dog("Fido"));
			animals.Enqueue(new Dog("Dora"));
			animals.Enqueue(new Cat("Kari"));
			animals.Enqueue(new Dog("Dexter"));
			animals.Enqueue(new Dog("Dobo"));
			animals.Enqueue(new Cat("Copa"));

			Console.WriteLine(animals.DequeueAny().GetName());
			Console.WriteLine(animals.DequeueAny().GetName());
			Console.WriteLine(animals.DequeueAny().GetName());
			Console.WriteLine();

			animals.Enqueue(new Dog("Dapa"));
			animals.Enqueue(new Cat("Kilo"));

			while (animals.Size() != 0)
			{
				Console.WriteLine(animals.DequeueAny().GetName());
			}
		}
    }
}

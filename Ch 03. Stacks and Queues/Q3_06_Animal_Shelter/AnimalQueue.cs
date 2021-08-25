using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_03._Stacks_and_Queues.Q3_06_Animal_Shelter
{
    public class AnimalQueue
    {
        private LinkedList<Dog> dogs = new LinkedList<Dog>();
        private LinkedList<Cat> cats = new LinkedList<Cat>();
		private int order = 0;

		public void Enqueue(Animal a)
		{
			a.SetOrder(order);
			order++;
			if (a is Dog) {
				dogs.AddLast((Dog)a);
			} else if (a is Cat) {
				cats.AddLast((Cat)a);
			}
		}

		public Animal DequeueAny()
		{
			if (dogs.Count == 0)
			{
				return DequeueCats();
			}
			else if (cats.Count == 0)
			{
				return DequeueDogs();
			}
			Dog dog = dogs.First();
			Cat cat = cats.First();
			if (dog.IsOlderThan(cat))
			{
				dogs.RemoveFirst();
				return dog;
			}
			else
			{
				cats.RemoveFirst();
				return cat;
			}
		}

		public Animal Peek()
		{
			if (dogs.Count == 0)
			{
				return cats.First();
			}
			else if (cats.Count == 0)
			{
				return dogs.First();
			}
			Dog dog = dogs.First();
			Cat cat = cats.First();
			if (dog.IsOlderThan(cat))
			{
				return dog;
			}
			else
			{
				return cat;
			}
		}

		public int Size()
		{
			return dogs.Count + cats.Count;
		}

		public Dog DequeueDogs()
		{
			Dog dog = dogs.First();
			dogs.RemoveFirst();
			return dog;
		}

		public Dog PeekDogs()
		{
			return dogs.First();
		}

		public Cat DequeueCats()
		{
			Cat cat = cats.First();
			cats.RemoveFirst();
			return cat;
		}

		public Cat PeekCats()
		{
			return cats.First();
		}
	}
}

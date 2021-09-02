using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_11_File_System
{
    public class Q7_11_File_System : Question
    {
        public override void Run()
        {
			Directory root = new Directory("Food", null);
			File taco = new File("Taco", root, 4);
			File hamburger = new File("Hamburger", root, 9);
			root.AddEntry(taco);
			root.AddEntry(hamburger);

			Directory healthy = new Directory("Healthy", root);

			Directory fruits = new Directory("Fruits", healthy);
			File apple = new File("Apple", fruits, 5);
			File banana = new File("Banana", fruits, 6);
			fruits.AddEntry(apple);
			fruits.AddEntry(banana);

			healthy.AddEntry(fruits);

			Directory veggies = new Directory("Veggies", healthy);
			File carrot = new File("Carrot", veggies, 6);
			File lettuce = new File("Lettuce", veggies, 7);
			File peas = new File("Peas", veggies, 4);
			veggies.AddEntry(carrot);
			veggies.AddEntry(lettuce);
			veggies.AddEntry(peas);

			healthy.AddEntry(veggies);

			root.AddEntry(healthy);

			Console.WriteLine(root.NumberOfFiles());
			Console.WriteLine(veggies.GetFullPath());
		}
    }
}

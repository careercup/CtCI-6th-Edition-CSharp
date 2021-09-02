using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_04_Parking_Lot
{
    public class Q7_04_Parking_Lot : Question
    {
        public override void Run()
        {
			ParkingLot lot = new ParkingLot();

			Vehicle v = null;
			while (v == null || lot.ParkVehicle(v))
			{
				lot.Print();
				int r = AssortedMethods.RandomIntInRange(0, 10);
				if (r < 2)
				{
					v = new Bus();
				}
				else if (r < 4)
				{
					v = new Motorcycle();
				}
				else
				{
					v = new Car();
				}
				Console.Write("\nParking a ");
				v.Print();
				Console.WriteLine("");
			}
			Console.WriteLine("Parking Failed. Final state: ");
			lot.Print();
		}
    }
}

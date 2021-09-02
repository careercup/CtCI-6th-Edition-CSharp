using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_04_Parking_Lot
{
	public class ParkingLot
	{
		private Level[] levels;
		private readonly int NUM_LEVELS = 5;

		public ParkingLot()
		{
			levels = new Level[NUM_LEVELS];
			for (int i = 0; i < NUM_LEVELS; i++)
			{
				levels[i] = new Level(i, 30);
			}
		}

		/* Park the vehicle in a spot (or multiple spots). Return false if failed. */
		public bool ParkVehicle(Vehicle vehicle)
		{
			for (int i = 0; i < levels.Length; i++)
			{
				if (levels[i].ParkVehicle(vehicle))
				{
					return true;
				}
			}
			return false;
		}

		public void Print()
		{
			for (int i = 0; i < levels.Length; i++)
			{
				Console.Write("Level" + i + ": ");
				levels[i].Print();
				Console.WriteLine("");
			}
			Console.WriteLine("");
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_04_Parking_Lot
{
	public class ParkingSpot
	{
		private Vehicle vehicle;
		private VehicleSize spotSize;
		private int row;
		private int spotNumber;
		private Level level;

		public ParkingSpot(Level lvl, int r, int n, VehicleSize sz)
		{
			level = lvl;
			row = r;
			spotNumber = n;
			spotSize = sz;
		}

		public bool IsAvailable()
		{
			return vehicle == null;
		}

		/* Checks if the spot is big enough for the vehicle (and is available). This compares
		 * the SIZE only. It does not check if it has enough spots. */
		public bool CanFitVehicle(Vehicle vehicle)
		{
			return IsAvailable() && vehicle.CanFitInSpot(this);
		}

		/* Park vehicle in this spot. */
		public bool park(Vehicle v)
		{
			if (!CanFitVehicle(v))
			{
				return false;
			}
			vehicle = v;
			vehicle.ParkInSpot(this);
			return true;
		}

		public int GetRow()
		{
			return row;
		}

		public int GetSpotNumber()
		{
			return spotNumber;
		}

		public VehicleSize GetSize()
		{
			return spotSize;
		}

		/* Remove vehicle from spot, and notify level that a new spot is available */
		public void RemoveVehicle()
		{
			level.SpotFreed();
			vehicle = null;
		}

		public void Print()
		{
			if (vehicle == null)
			{
				if (spotSize == VehicleSize.Compact)
				{
					Console.Write("c");
				}
				else if (spotSize == VehicleSize.Large)
				{
					Console.Write("l");
				}
				else if (spotSize == VehicleSize.Motorcycle)
				{
					Console.Write("m");
				}
			}
			else
			{
				vehicle.Print();
			}
		}
	}
}

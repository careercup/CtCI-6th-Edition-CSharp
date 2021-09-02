using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_04_Parking_Lot
{
	/* Represents a level in a parking garage */
	public class Level
	{
		private int floor;
		private ParkingSpot[] spots;
		private int availableSpots = 0; // number of free spots
		private static readonly int SPOTS_PER_ROW = 10;

		public Level(int flr, int numberSpots)
		{
			floor = flr;
			spots = new ParkingSpot[numberSpots];
			int largeSpots = numberSpots / 4;
			int bikeSpots = numberSpots / 4;
			int compactSpots = numberSpots - largeSpots - bikeSpots;
			for (int i = 0; i < numberSpots; i++)
			{
				VehicleSize sz = VehicleSize.Motorcycle;
				if (i < largeSpots)
				{
					sz = VehicleSize.Large;
				}
				else if (i < largeSpots + compactSpots)
				{
					sz = VehicleSize.Compact;
				}
				int row = i / SPOTS_PER_ROW;
				spots[i] = new ParkingSpot(this, row, i, sz);
			}
			availableSpots = numberSpots;
		}

		public int AvailableSpots()
		{
			return availableSpots;
		}

		/* Try to find a place to park this vehicle. Return false if failed. */
		public bool ParkVehicle(Vehicle vehicle)
		{
			if (AvailableSpots() < vehicle.GetSpotsNeeded())
			{
				return false;
			}
			int spotNumber = FindAvailableSpots(vehicle);
			if (spotNumber < 0)
			{
				return false;
			}
			return ParkStartingAtSpot(spotNumber, vehicle);
		}

		/* Park a vehicle starting at the spot spotNumber, and continuing until vehicle.spotsNeeded. */
		private bool ParkStartingAtSpot(int spotNumber, Vehicle vehicle)
		{
			vehicle.ClearSpots();
			bool success = true;
			for (int i = spotNumber; i < spotNumber + vehicle.SpotsNeeded; i++)
			{
				success &= spots[i].park(vehicle);
			}
			availableSpots -= vehicle.SpotsNeeded;
			return success;
		}

		/* find a spot to park this vehicle. Return index of spot, or -1 on failure. */
		private int FindAvailableSpots(Vehicle vehicle)
		{
			int spotsNeeded = vehicle.GetSpotsNeeded();
			int lastRow = -1;
			int spotsFound = 0;
			for (int i = 0; i < spots.Length; i++)
			{
				ParkingSpot spot = spots[i];
				if (lastRow != spot.GetRow())
				{
					spotsFound = 0;
					lastRow = spot.GetRow();
				}
				if (spot.CanFitVehicle(vehicle))
				{
					spotsFound++;
				}
				else
				{
					spotsFound = 0;
				}
				if (spotsFound == spotsNeeded)
				{
					return i - (spotsNeeded - 1);
				}
			}
			return -1;
		}

		public void Print()
		{
			int lastRow = -1;
			for (int i = 0; i < spots.Length; i++)
			{
				ParkingSpot spot = spots[i];
				if (spot.GetRow() != lastRow)
				{
					Console.Write("  ");
					lastRow = spot.GetRow();
				}
				spot.Print();
			}
		}

		/* When a car was removed from the spot, increment availableSpots */
		public void SpotFreed()
		{
			availableSpots++;
		}
	}
}

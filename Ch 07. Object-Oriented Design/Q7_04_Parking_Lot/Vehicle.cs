using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_04_Parking_Lot
{
	public abstract class Vehicle
	{
		protected IList<ParkingSpot> parkingSpots = new List<ParkingSpot>();
		protected string licensePlate;
		public int SpotsNeeded { get; protected set; }
		protected VehicleSize size;

		public int GetSpotsNeeded()
		{
			return SpotsNeeded;
		}

		public VehicleSize GetSize()
		{
			return size;
		}

		/* Park vehicle in this spot (among others, potentially) */
		public void ParkInSpot(ParkingSpot spot)
		{
			parkingSpots.Add(spot);
		}

		/* Remove car from spot, and notify spot that it's gone */
		public void ClearSpots()
		{
			for (int i = 0; i < parkingSpots.Count; i++)
			{
				parkingSpots[i].RemoveVehicle();
			}
			parkingSpots.Clear();
		}

		public abstract bool CanFitInSpot(ParkingSpot spot);
		public abstract void Print();
	}
}

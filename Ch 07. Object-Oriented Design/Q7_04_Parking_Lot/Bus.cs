using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_04_Parking_Lot
{

    public class Bus : Vehicle
    {
        public Bus()
        {
            SpotsNeeded = 5;
            size = VehicleSize.Large;
        }

        public override bool CanFitInSpot(ParkingSpot spot)
        {
            return spot.GetSize() == VehicleSize.Large;
        }

        public override void Print()
        {
            Console.Write("B");
        }

    }
}

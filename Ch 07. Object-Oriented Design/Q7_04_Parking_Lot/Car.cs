using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_04_Parking_Lot
{
    public class Car : Vehicle
    {
        public Car()
        {
            SpotsNeeded = 1;
            size = VehicleSize.Compact;
        }

        public override bool CanFitInSpot(ParkingSpot spot)
        {
            return spot.GetSize() == VehicleSize.Large || spot.GetSize() == VehicleSize.Compact;
        }

        public override void Print()
        {
            Console.Write("C");
        }
    }
}

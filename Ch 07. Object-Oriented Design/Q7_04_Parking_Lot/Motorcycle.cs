using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_04_Parking_Lot
{
    public class Motorcycle : Vehicle
    {
        public Motorcycle()
        {
            SpotsNeeded = 1;
            size = VehicleSize.Motorcycle;
        }

        public override bool CanFitInSpot(ParkingSpot spot)
        {
            return true;
        }

        public override void Print()
        {
            Console.Write("M");
        }
    }
}

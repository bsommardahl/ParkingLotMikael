using System;

namespace ParkingLotKata2
{
    public class Bus : Vehicle
    {
        public Bus(IDriver driver, string license) : base(new Guid(), driver, license)
        {
        }

        public override double Length => 4;
    }
}
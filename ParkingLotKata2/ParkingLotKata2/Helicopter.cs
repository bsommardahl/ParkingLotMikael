using System;

namespace ParkingLotKata2
{
    public class Helicopter : Vehicle
    {
        public Helicopter(IDriver driver, string license) : base(new Guid(), driver, license)
        {
        }

        public override double Length => 8;
    }
}
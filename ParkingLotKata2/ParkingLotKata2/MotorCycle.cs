using System;

namespace ParkingLotKata2
{
    public class MotorCycle : Vehicle
    {
        public MotorCycle(IDriver driver, string license) : base(new Guid(), driver, license)
        {
        }

        public override double Length => 1;
    }
}
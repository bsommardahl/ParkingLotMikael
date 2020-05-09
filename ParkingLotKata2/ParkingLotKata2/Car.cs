using System;

namespace ParkingLotKata2
{
    public class Car : Vehicle
    {
        public bool HasTrumpSticker { get; private set; }

        public Car(Guid id, IDriver driver, string license, bool hasTrumpSticker = false) : base(id, driver, license)
        {
            HasTrumpSticker = hasTrumpSticker;
        }

        public override double Length => 2;
    }
}
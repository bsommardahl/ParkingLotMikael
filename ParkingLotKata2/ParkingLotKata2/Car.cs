namespace ParkingLotKata2
{
    public class Car : Vehicle
    {
        public bool HasTrumpSticker { get; private set; }

        public Car(IDriver driver, string license, bool hasTrumpSticker = false) : base(driver, license)
        {
            HasTrumpSticker = hasTrumpSticker;
        }

        public override double Length => 2;
    }
}
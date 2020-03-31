namespace ParkingLotKata2
{
    public class Car : Vehicle
    {
        public bool HasTrumpSticker { get; private set; }
        public Car(IDriver driver, bool hasTrumpSticker = false) : base(driver)
        {
            HasTrumpSticker = hasTrumpSticker;
        }
    }
}
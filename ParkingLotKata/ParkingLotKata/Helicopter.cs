namespace ParkingLotKata
{
    public class Helicopter : Vehicle
    {
        public Helicopter(Driver driver, MotorType motorType = MotorType.Normal, bool trumpSticker = false) : base(driver, motorType, trumpSticker)
        {
        }

        public override double GetSize()
        {
            return 10;
        }
    }
}
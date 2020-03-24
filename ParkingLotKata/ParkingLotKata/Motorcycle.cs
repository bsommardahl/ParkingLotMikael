namespace ParkingLotKata
{
    public class Motorcycle : Vehicle
    {
        public Motorcycle(Driver driver, MotorType motorType = MotorType.Normal, bool trumpSticker = false) : base(driver, motorType, trumpSticker)
        {
        }

        public override double GetSize()
        {
            return .5;
        }
    }
}
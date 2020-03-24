namespace ParkingLotKata
{
    public class Car : Vehicle
    {
        public Car(Driver driver, MotorType motorType = MotorType.Normal, bool trumpSticker = false) : base(driver, motorType, trumpSticker)
        {
        }

        public override double GetSize()
        {
            return 1;
        }
    }
}
namespace ParkingLotKata
{
    public class Bus : Vehicle
    {
        public Bus(Driver driver, MotorType motorType = MotorType.Normal, bool trumpSticker = false) : base(driver, motorType, trumpSticker)
        {
        }

        public override double GetSize()
        {
            return 3;
        }
    }
}
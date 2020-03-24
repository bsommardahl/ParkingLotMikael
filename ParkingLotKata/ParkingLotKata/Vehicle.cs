namespace ParkingLotKata
{
    public abstract class Vehicle
    {
        public Vehicle(Driver driver, MotorType motorType = MotorType.Normal,
            bool trumpSticker = false)
        {
            Motor = motorType;
            Driver = driver;
            TrumpSticker = trumpSticker;
        }

        public Driver Driver { get; }
        public bool TrumpSticker { get; }
        public MotorType Motor { get; }

        public abstract double GetSize();
    }
}
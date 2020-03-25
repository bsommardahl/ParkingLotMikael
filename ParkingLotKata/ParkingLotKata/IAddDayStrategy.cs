namespace ParkingLotKata
{
    public interface IAddDayStrategy
    {
    }

    public interface IAddDayStrategy<in T> : IAddDayStrategy where T : Vehicle
    {
        void Execute(T vehicle, int days);
    }
}
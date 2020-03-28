namespace ParkingLotKata2
{
    public class BusCostWithdrawalStrategy : IVehicleCostWithdrawalStrategy<Bus>
    {
        public void Execute(Bus vehicle)
        {
            vehicle.Driver.Withdraw(9);
        }
    }
}
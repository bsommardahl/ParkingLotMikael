namespace ParkingLotKata2
{
    public class CarCostWithdrawalStrategy : IVehicleCostWithdrawalStrategy<Car>
    {
        public void Execute(Car vehicle)
        {
            const int basePrice = 5;
            vehicle.Driver.Withdraw(basePrice);
        }
    }
}
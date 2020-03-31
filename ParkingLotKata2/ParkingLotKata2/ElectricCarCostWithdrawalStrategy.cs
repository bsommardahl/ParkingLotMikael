namespace ParkingLotKata2
{
    public class ElectricCarCostWithdrawalStrategy : IVehicleCostWithdrawalStrategy<ElectricCar>
    {

        public void Execute(ElectricCar vehicle, int days)
        {
            const double basePrice = 2.50;
            var computedPrice = basePrice * days;

           
            vehicle.Driver.Withdraw(computedPrice);
        }
    }
}
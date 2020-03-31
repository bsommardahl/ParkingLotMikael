namespace ParkingLotKata2
{
    public class MotorCycleCostWithdrawalStrategy : IVehicleCostWithdrawalStrategy<MotorCycle>
    {
        public void Execute(MotorCycle vehicle, int days)
        {
            const double basePrice = .5;
            var computedPrice = basePrice * days;

           
            vehicle.Driver.Withdraw(computedPrice);

        }
    }
}
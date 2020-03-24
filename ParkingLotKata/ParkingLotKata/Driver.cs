namespace ParkingLotKata
{
    public class Driver
    {
        public double Wallet { get; private set; }

        public void AddMoney(int value)
        {
            Wallet = value;
        }

        public void Withdraw(double value)
        {
            Wallet -= value;
        }
    }
}
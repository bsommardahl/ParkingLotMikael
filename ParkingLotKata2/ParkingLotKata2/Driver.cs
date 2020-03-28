namespace ParkingLotKata2
{
    public class Driver : IDriver
    {
        public double Wallet { get; private set; }

        public void AddToWallet(int money)
        {
            Wallet += money;
        }

        public void Withdraw(int money)
        {
            Wallet -= money;
        }
    }
}
using System;

namespace ParkingLotKata2
{
    public class Driver : IDriver
    {
        public Driver(double initialWallet = 0)
        {
            Wallet = initialWallet;
        }
        public double Wallet { get; private set; }

        public void AddToWallet(int money)
        {
            Wallet += money;
        }

        public void Withdraw(double money)
        {
            Wallet -= money;
        }

        public double GetWalletSum()
        {
            return Wallet;
        }
    }
}
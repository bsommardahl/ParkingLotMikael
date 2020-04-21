using System;

namespace ParkingLotKata2
{
    public class NotEnoughMoneyException : Exception
    {
        public NotEnoughMoneyException() : base() { }
        public NotEnoughMoneyException(string message) : base(message) { }
    }
}
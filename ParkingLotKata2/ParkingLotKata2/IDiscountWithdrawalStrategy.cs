namespace ParkingLotKata2
{
    public interface IDiscountWithdrawalStrategy
    {
        double Discount(int days, double charge);

    }
}
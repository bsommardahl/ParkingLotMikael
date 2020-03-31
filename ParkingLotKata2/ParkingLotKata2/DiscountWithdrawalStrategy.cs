namespace ParkingLotKata2
{
    public class DiscountWithdrawalStrategy : IDiscountWithdrawalStrategy
    {
        public double Discount(int days, double charge)
        {
            if (days >= 6)
            {
                return charge - charge * 0.30;
            }
            if (days >= 3)
            {
                return charge - charge * 0.20;
            }

            return charge;
        }
    }
}
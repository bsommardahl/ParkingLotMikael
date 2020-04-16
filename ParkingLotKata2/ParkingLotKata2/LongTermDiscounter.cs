namespace ParkingLotKata2
{
    public class LongTermDiscounter : ILongTermDiscounter
    {
        public double Discount(int days, double charge)
        {
            if (days >= 6) return charge - charge * 0.30;
            if (days >= 3) return charge - charge * 0.20;

            return charge;
        }
    }
}
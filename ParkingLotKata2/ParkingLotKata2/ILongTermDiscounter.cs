namespace ParkingLotKata2
{
    public interface ILongTermDiscounter
    {
        double Discount(int days, double charge);

    }
}
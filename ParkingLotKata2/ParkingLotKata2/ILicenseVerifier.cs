namespace ParkingLotKata2
{
    public interface ILicenseVerifier
    {
        bool IsInvalid(string vehicleLicense);
    }
}
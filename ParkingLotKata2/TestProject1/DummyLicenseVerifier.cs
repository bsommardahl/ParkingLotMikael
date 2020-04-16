using ParkingLotKata2;

namespace TestProject1
{
    public class DummyLicenseVerifier : ILicenseVerifier
    {
        public bool IsInvalid(string vehicleLicense)
        {
            return false;
        }
    }
}
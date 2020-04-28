using ParkingLotKata2;

namespace TestProject1
{
    public class FakeLicenseVerifier : ILicenseVerifier
    {
        public bool IsInvalid(string vehicleLicense)
        {
            var firstChar = vehicleLicense[0];
            var isInt = int.TryParse(firstChar.ToString(), out var firstNum);
            if (!isInt)
            {
                return false;
            }
            return firstNum % 2 > 0;
        }
    }
}
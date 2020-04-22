namespace ParkingLotKata2
{
    public class LicenseVerifier : ILicenseVerifier
    {
        public bool IsInvalid(string vehicleLicense)
        {
            var firstChar = vehicleLicense[0];
            var isInt = int.TryParse(firstChar.ToString(), out var firstNum);
            if (!isInt)
            {
                return false;
            }
            return firstNum % 2 <= 0;
        }
    }
}
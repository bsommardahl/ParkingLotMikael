using System.Collections.Generic;
using System.Linq;
using ParkingLotKata2;
using Xunit;

namespace TestProject1
{
    public class when_verify_valid_license_using_a_fake_verifier
    {
        [Fact]
        public void should_behave_like_real_verifier()
        {
            //Arrange
            var verifiers = new List<ILicenseVerifier>
            {
                new FakeLicenseVerifier(),
                new LicenseVerifier()
            };

            //Act
            var result = verifiers.Select(x => x.IsInvalid("122"));

            //Assert
            result.ValueShouldBe(true);
        }

    }
}
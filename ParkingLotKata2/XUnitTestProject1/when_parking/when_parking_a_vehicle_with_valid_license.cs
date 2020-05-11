using System;
using System.Threading.Tasks;
using FakeItEasy;
using FluentAssertions;
using ParkingLotKata2;
using Xunit;

namespace XUnitTestProject1
{
    public class when_attempting_to_park_a_vehicle_with_no_length : given_a_parking_lot
    {
        [Fact]
        public void should_throw_an_appropriate_exception()
        {
            //Arrange
            var vehicle = A.Fake<Vehicle>();
            A.CallTo(() => vehicle.Length).Returns(0);

            //Act
            Func<Task> park = async () => await Sut.ParkVehicle(vehicle);

            //Assert
            park.Should().Throw<VehicleHasNoLengthException>();
        }
    }

    public class when_attempting_to_park_a_vehicle_with_invalid_license : given_a_parking_lot
    {
        [Fact]
        public void should_throw_an_exception()
        {
            //Arrange
            var vehicleWithInvalidLicense = A.Fake<Vehicle>();
            A.CallTo(() => vehicleWithInvalidLicense.Length).Returns(2);
            var license = "invalid";
            A.CallTo(() => vehicleWithInvalidLicense.License).Returns(license);
            A.CallTo(() => _licenseVerifier.IsInvalid(license)).Returns(true);

            //Act
            Func<Task> park = async () => await Sut.ParkVehicle(vehicleWithInvalidLicense);

            //Assert
            park.Should().Throw<InvalidLicenseException>();
        }
    }

    public class when_parking_a_vehicle_with_valid_license : given_a_parking_lot
    {
        private readonly Vehicle _vehicle;

        public when_parking_a_vehicle_with_valid_license()
        {
            //Arrange
            var metersPerSpace = 2;
            _vehicle = A.Fake<Vehicle>();
            A.CallTo(() => _vehicle.Length).Returns(metersPerSpace);
            A.CallTo(() => _calculateSpaces.GetSpaces(_vehicle)).Returns(1);
            A.CallTo(() => _licenseVerifier.IsInvalid(_vehicle.License)).Returns(false);

        }

        [Fact]
        public async void should_allow_the_vehicle_to_be_parked()
        {
            await Act();
            //Assert
            A.CallTo(() => _vehicleRepository.Add(_vehicle)).MustHaveHappened();
        }
        private async Task Act()
        {
            await Sut.ParkVehicle(_vehicle);
        }

    }
}
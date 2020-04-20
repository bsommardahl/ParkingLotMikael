using System;
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
            var vehicle = A.Fake<IVehicle>();
            A.CallTo(() => vehicle.Length).Returns(0);

            //Act
            Action park = () => Sut.ParkVehicle(vehicle);

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
            var vehicleWithInvalidLicense = A.Fake<IVehicle>();
            A.CallTo(() => vehicleWithInvalidLicense.Length).Returns(2);
            var license = "invalid";
            A.CallTo(() => vehicleWithInvalidLicense.License).Returns(license);
            A.CallTo(() => _licenseVerifier.IsInvalid(license)).Returns(true);

            //Act
            Action park = () => Sut.ParkVehicle(vehicleWithInvalidLicense);

            //Assert
            park.Should().Throw<InvalidLicenseException>();
        }
    }

    public class when_parking_a_vehicle_with_valid_license : given_a_parking_lot
    {
        public when_parking_a_vehicle_with_valid_license()
        {
            //Arrange
            var metersPerSpace = 2;
            var vehicle = A.Fake<IVehicle>();
            A.CallTo(() => vehicle.Length).Returns(metersPerSpace);
            A.CallTo(() => _calculateSpaces.GetSpaces(vehicle)).Returns(1);
            A.CallTo(() => _licenseVerifier.IsInvalid(vehicle.License)).Returns(false);

            //Act
            Sut.ParkVehicle(vehicle);
        }

        [Fact]
        public void should_allow_the_vehicle_to_be_parked()
        {
            //Assert
            Sut.Spaces.Should().Be(99);
        }
    }
}
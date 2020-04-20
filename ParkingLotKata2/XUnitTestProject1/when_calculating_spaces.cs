using System.Collections.Generic;
using FakeItEasy;
using FluentAssertions;
using ParkingLotKata2;
using Xunit;

namespace XUnitTestProject1
{
    public class when_instantiating_a_car
    {
        readonly Car sut;
        readonly string expectedLicense;
        Driver _driver;

        public when_instantiating_a_car()
        {
            //Arrange
            expectedLicense = "123";
            _driver = new Driver();

            //Act
            sut = new Car(_driver, expectedLicense);
        }

        [Fact]
        public void should_have_the_license()
        {
            //Assert
            sut.License.Should().Be(expectedLicense);
        }
        
        [Fact]
        public void should_have_the_driver()
        {
            //Assert
            sut.Driver.Should().Be(_driver);
        }
    }

    public class when_calculating_spaces
    {
        CalculateSpaces _sut;


        public when_calculating_spaces()
        {
            _sut = new CalculateSpaces(2);
        }

        [Fact]
        public void should_provide_one_space_per_every_two_meter()
        {
            //Arrange
            var metersPerSpace = 2;
            var vehicle = A.Fake<IVehicle>();
            A.CallTo(() => vehicle.Length).Returns(metersPerSpace);

            //Act
            var spaces = _sut.GetSpaces(vehicle);

            //Assert
            spaces.Should().Be(1);
        }
    }
}
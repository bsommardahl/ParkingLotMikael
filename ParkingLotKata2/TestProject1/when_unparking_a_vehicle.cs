using System;
using System.Threading.Tasks;
using FluentAssertions;
using ParkingLotKata2;
using Xunit;

namespace TestProject1
{
    public class when_unparking_a_vehicle : given_an_integrated_parking_lot
    {
        readonly Driver driver;
        readonly int _startingBalance;
        private readonly Car _vehicle;

        public when_unparking_a_vehicle()
        {
            //Arrange
            _startingBalance = 10;
            driver = new Driver();
            driver.AddToWallet(_startingBalance);
            _vehicle = new Car(new Guid(), driver, "license");
            

        }

        async Task Arrange()
        {
            await sut.ParkVehicle(_vehicle);
        }

        async Task Act()
        {
            sut.UnparkVehicle(_vehicle.License, 1);
        }
        
        [Fact]
        public async Task should_replace_the_spaces()
        {
            await Arrange();
            await Act();
            
            //Assert
            _fakeRepository.Vehicles.Should().NotContain(_vehicle);
        }

        [Fact]
        public async Task should_charge_the_driver()
        {
            await Arrange();
            await Act();
            
            //Assert
            driver.Wallet.Should().Be(_startingBalance - 5);
        }
    }
}
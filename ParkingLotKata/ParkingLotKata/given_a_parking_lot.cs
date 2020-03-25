using System.Collections.Generic;

namespace ParkingLotKata
{
    public abstract class given_a_parking_lot
    {
        protected List<IAddDayStrategy> _addDayStrategies;
        protected List<IParkingLotSizeStrategy> _sizeStrategies;
        protected ParkingLot _parkingLot;

        public given_a_parking_lot()
        {
            _addDayStrategies = new List<IAddDayStrategy>
            {
                new ElectricCarStrategy(),
                new ElectricBusStrategy(),
                new TrumpCarStrategy(),
                new HeliStrategy(),
                new LongTermBusStrategy(),
                new LongTermCarStrategy(),
                new DefaultCar(),
                new DefaultBus(),
                new DefaultMoto(),
                new DefaultHeli()
            };
            _sizeStrategies = new List<IParkingLotSizeStrategy>
            {
                new CarSizeStrategy(),
                new BusSizeStrategy(),
                new MotorcycleSizeStrategy(),
                new HelicopterSizeStrategy()

            };

            _parkingLot = new ParkingLot(50, _addDayStrategies, _sizeStrategies);
        }
    }
}
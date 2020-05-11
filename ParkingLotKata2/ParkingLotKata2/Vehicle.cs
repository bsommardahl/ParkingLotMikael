using System;

namespace ParkingLotKata2
{
    public abstract class Vehicle
    {
        protected Vehicle(Guid id, IDriver driver, string license)
        {
            Driver = driver;
            License = license;
            Id = id;

        }

        public Guid Id { get; set; }
        public virtual IDriver Driver { get; }
        public abstract double Length { get; }
        public virtual string License { get; private set; }

    }
}
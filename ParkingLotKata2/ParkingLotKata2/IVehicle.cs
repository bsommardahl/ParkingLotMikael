using System;

namespace ParkingLotKata2
{
    public interface IVehicle
    {
        
        Guid Id { get; }
        IDriver Driver { get; }
        double Length { get; }
        string License { get; }
    }
}
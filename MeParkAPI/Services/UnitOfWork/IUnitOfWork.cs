using MeParkAPI.Areas.Identity.Data;
using MeParkAPI.Models;
using MeParkAPI.Services.Repository;

namespace MeParkAPI.Services.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<ApplicationUser> ApplicationUserRepository { get; }
        IRepository<Vehicle> VehicleRepository { get; }
        IRepository<Parking> ParkingRepository { get; }
        IRepository<ParkingSpace> ParkingSpaceRepository { get; }
        IRepository<Transaction> TransactionRepository { get; }
        IRepository<ParkingFee> ParkingFeeRepository { get; }

        void SaveChanges();
    }
}

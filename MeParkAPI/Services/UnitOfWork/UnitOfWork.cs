using MeParkAPI.Areas.Identity.Data;
using MeParkAPI.Models;
using MeParkAPI.Services.Repository;
using System;

namespace MeParkAPI.Services.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MeParkAPIContext _context;

        public UnitOfWork(MeParkAPIContext context)
        {

            _context = context;

            ApplicationUserRepository = new Repository<ApplicationUser>(_context);
            VehicleRepository = new Repository<Vehicle>(_context);
            ParkingRepository = new Repository<Parking>(_context);
            ParkingSpaceRepository = new Repository<ParkingSpace>(_context);
            TransactionRepository = new Repository<Transaction>(_context);
            ParkingFeeRepository = new Repository<ParkingFee>(_context);

        }

        public IRepository<ApplicationUser> ApplicationUserRepository { get; }

        public IRepository<Vehicle> VehicleRepository { get; }

        public IRepository<Parking> ParkingRepository { get; }

        public IRepository<ParkingSpace> ParkingSpaceRepository { get; }

        public IRepository<Transaction> TransactionRepository { get; }

        public IRepository<ParkingFee> ParkingFeeRepository { get; }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

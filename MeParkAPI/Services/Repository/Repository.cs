using MeParkAPI.Areas.Identity.Data;
using MeParkAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace MeParkAPI.Services.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly MeParkAPIContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(MeParkAPIContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public IQueryable<T> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public T GetById(string id)
        {
            return _dbSet.Find(id);
        }

        //public T GetByRegistrationPlate(string registrationPlate)
        //{
        //    return _dbSet.FirstOrDefault(registrationPlate);
        //}

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            //_dbSet.Update(entity);

            //_context.Entry(entity).CurrentValues.SetValues(entity);
            _context.Entry(entity).State = EntityState.Modified;

        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public bool ExistingPlate(string registrationPlate)
        {
            if (!_context.Vehicles.Any(v => v.RegistrationPlate == registrationPlate))
                return false;
            return true;
        }

        public Vehicle GetByPlate(string plate)
        {
            var vehicle = _context.Vehicles.FirstOrDefault(v => v.RegistrationPlate == plate);
            if (vehicle == null)
                return null;
            return vehicle;
        }

        public ParkingSpace GetByPlaceNumber(int placeNumber)
        {
            var place = _context.ParkingSpaces.FirstOrDefault(v => v.PlaceNumber == placeNumber);
            if (place == null)
                return null;
            return place;
        }

        public ICollection<ParkingSpace> GetPlacesOfParking(string parkingId)
        {
            var places = _context.ParkingSpaces.Where(p => p.IdParking == parkingId).ToList();
            return places;
        }
    }
}

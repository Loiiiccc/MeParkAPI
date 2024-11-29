using MeParkAPI.Models;

namespace MeParkAPI.Services.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(string id);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);

        bool ExistingPlate(string registrationPlate);
        Vehicle GetByPlate(string plate);
        ParkingSpace GetByPlaceNumber(int placeNumber);
        ICollection<ParkingSpace> GetPlacesOfParking(string parkingId);
    }
}

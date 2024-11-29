using Mapster;
using MeParkAPI.Models;
using MeParkAPI.Models.DTOs.VehiculeDTO;
using MeParkAPI.Services.UnitOfWork;

namespace MeParkAPI.Services
{
    public class VehicleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public VehicleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Vehicle AddVehicle(AddVehicleDto vehicle)
        {
            if (_unitOfWork.VehicleRepository.ExistingPlate(vehicle.RegistrationPlate) == true)
                return null;
            var vehicleObj = new Vehicle();
            vehicle.Adapt(vehicleObj);
            _unitOfWork.VehicleRepository.Add(vehicleObj);
            _unitOfWork.SaveChanges();
            return vehicleObj;
        }

        public Vehicle UpdateVehicle(string plate, UpdateVehicleDto vehicle)
        {
            var vehicleObj = _unitOfWork.VehicleRepository.GetByPlate(plate);
            if (vehicleObj == null)
                return null;
            vehicleObj.RegistrationPlate = plate;
            vehicleObj.Mark = vehicle.Mark;
            vehicleObj.Model = vehicle.Model;
            vehicleObj.IdOwner = vehicle.IdOwner;
            //vehicle.Adapt(vehicleObj);
            _unitOfWork.VehicleRepository.Update(vehicleObj);
            return vehicleObj;

            //if (_unitOfWork.VehicleRepository.ExistingPlate(plate) != true)
            //    return null;
            //var vehicleObj = new Vehicle();
            //vehicle.Adapt(vehicleObj);
            //_unitOfWork.VehicleRepository.Update(vehicleObj);
            //return vehicleObj;
        }

        public Vehicle GetVehicleById(string vehicleId)
        {
            return _unitOfWork.VehicleRepository.GetById(vehicleId);
        }

        public Vehicle GetVehicleByPlate(string plate)
        {
            return _unitOfWork.VehicleRepository.GetByPlate(plate);
        }

        public ICollection<AllVehiclesDto> GetAllVehicles()
        {
            return _unitOfWork.VehicleRepository.GetAll().ToList().Adapt<ICollection<AllVehiclesDto>>();
        }

        public bool RevomeVehicle(string registrationPlate)
        {
            var vehicle = _unitOfWork.VehicleRepository.GetByPlate(registrationPlate);
            if (vehicle != null)
            {
                _unitOfWork.VehicleRepository.Remove(vehicle);
                _unitOfWork.SaveChanges();
                return true;

            }
            return false;
        }

        public IEnumerable<Vehicle> GetVehicleByOwner(string ownerId)
        {
            return _unitOfWork.VehicleRepository
                .GetAll()
                .Where(v => v.IdOwner == ownerId)
                .ToList();
        }


    }
}

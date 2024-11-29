using MeParkAPI.Models.DTOs.VehiculeDTO;
using MeParkAPI.Models;
using MeParkAPI.Services.UnitOfWork;
using MeParkAPI.Models.DTOs.ParkingDTO;
using Mapster;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;

namespace MeParkAPI.Services
{
    public class ParkingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ParkingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddParking(AddParkingDto parkingDto)
        {
            var parkingObj = new Parking();
            
            parkingDto.Adapt(parkingObj);
            for (var i = 1; i < parkingDto.Capacity + 1; i++)
            {
                var place = new ParkingSpace() 
                {
                    PlaceNumber = i,
                    State = "Free",
                    IdParking = parkingObj.Id,
                    Parking = parkingObj                    
                };

                _unitOfWork.ParkingSpaceRepository.Add(place);
            }
            _unitOfWork.ParkingRepository.Add(parkingObj);
            _unitOfWork.SaveChanges();

        }

        public Parking UpdateParking(UpdateParkingDto parkingDto)
        {
            var parkingObj = new Parking();

            parkingDto.Adapt(parkingObj);
            _unitOfWork.ParkingRepository.Update(parkingObj);

            return parkingObj;
        }

        public Parking GetParkingById(string parkingId)
        {
            return _unitOfWork.ParkingRepository.GetById(parkingId);
        }

        public int CountParkingPlaceLeft(string parkingId) 
        {
            var park = _unitOfWork.ParkingRepository.GetById(parkingId);

            var number = park.Capacity - park.ParkingSpaces.Count;
            return number;
        }

        public ICollection<AllParkingsDto> GetAllParkings()
        {
            var parks = _unitOfWork.ParkingRepository.GetAll().ToList().Adapt<ICollection<AllParkingsDto>>();
            return parks;
        }

        public void RevomeParking(string parkingId)
        {
            var parking = _unitOfWork.ParkingRepository.GetById(parkingId);
            if (parking != null)
            {
                _unitOfWork.ParkingRepository.Remove(parking);
                _unitOfWork.SaveChanges();
            }
        }

        

        public bool UpdateParkingSpaces(string parkingId, int newCapacity)
        {
            var places = _unitOfWork.ParkingSpaceRepository.GetPlacesOfParking(parkingId);
            var count = places.Count;
            if (count < newCapacity)
            {
                for (var i = count; i < newCapacity; i++)
                {
                    var place = new ParkingSpace()
                    {
                        PlaceNumber = count + 1,
                        State = "Free",
                        IdParking = parkingId
                    };

                    _unitOfWork.ParkingSpaceRepository.Add(place);
                    _unitOfWork.SaveChanges();

                }
                return true;
            }

            if (count > newCapacity)
            {
                for (var i = newCapacity; i < count ; i++)
                {
                    var placeToRemove = places.FirstOrDefault(p => p.State == "Free");
                    //var placeToRemove = places.LastOrDefault();
                    //if(placeToRemove.State != "Free")
                    //{
                    //    placeToRemove = places.FirstOrDefault(p => p.State == "Free");
                    //}
                    _unitOfWork.ParkingSpaceRepository.Remove(placeToRemove);
                    _unitOfWork.SaveChanges();
                }
                return true;
            }

            return false;
        }

    }
}

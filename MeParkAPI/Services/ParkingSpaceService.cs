using Mapster;
using MeParkAPI.Models;
using MeParkAPI.Models.DTOs.ParkingSpaceDTO;
using MeParkAPI.Services.UnitOfWork;

namespace MeParkAPI.Services
{
    public class ParkingSpaceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ParkingSpaceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ParkingSpace GetPlace(int placeNumber)
        {
            var place = _unitOfWork.ParkingSpaceRepository.GetByPlaceNumber(placeNumber);
            return place;
        }

        public ICollection<AllParkingSpaceDTO> GetAll()
        {
            var places = _unitOfWork.ParkingSpaceRepository.GetAll().ToList().Adapt<ICollection<AllParkingSpaceDTO>>();
            return places;
        }

        public ParkingSpace updateParkingSpace(UpdateParkingSpaceDTO parkingSpace) {
            var place = new ParkingSpace();

            parkingSpace.Adapt(place);
            _unitOfWork.ParkingSpaceRepository.Update(place);
            return place;
            
        }

    }
}

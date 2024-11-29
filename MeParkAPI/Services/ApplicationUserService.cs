using Mapster;
using MeParkAPI.Areas.Identity.Data;
using MeParkAPI.Models;
using MeParkAPI.Models.DTOs.AccountDTO;
using MeParkAPI.Models.DTOs.VehiculeDTO;
using MeParkAPI.Services.UnitOfWork;

namespace MeParkAPI.Services
{
    public class ApplicationUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ApplicationUserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ICollection<AllUsers> GetAll()
        {
            return _unitOfWork.ApplicationUserRepository.GetAll().ToList().Adapt<ICollection<AllUsers>>();
        }

        public ApplicationUser GetApplicationUserById(string userId)
        {
            return _unitOfWork.ApplicationUserRepository.GetById(userId);
        }

        public void DeleteApplicationUserById(string userId)
        {
            var user = _unitOfWork.ApplicationUserRepository.GetById(userId);
            if (user != null)
            {
                _unitOfWork.ApplicationUserRepository.Remove(user);
                _unitOfWork.SaveChanges();
            }
        }


    }
}

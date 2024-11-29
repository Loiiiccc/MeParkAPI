using MeParkAPI.Areas.Identity.Data;

namespace MeParkAPI.Models.DTOs.VehiculeDTO
{
    public class AddVehicleDto
    {
        public string Mark { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string RegistrationPlate { get; set; }

        public string IdOwner { get; set; }
    }
}

using MeParkAPI.Areas.Identity.Data;

namespace MeParkAPI.Models.DTOs.VehiculeDTO
{
    public class AllVehiclesDto
    {
        public string Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string RegistrationPlate { get; set; }

        public string Owner { get; set; }
        //public string IdOwner { get; set; }

    }
}

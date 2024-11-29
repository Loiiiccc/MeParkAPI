using MeParkAPI.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace MeParkAPI.Models
{
    public class Vehicle
    {
        [Key]
        public string Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string RegistrationPlate { get; set; }

        public string IdOwner { get; set; }
        public ApplicationUser Owner { get; set; }

        public Vehicle()
        {
            Id = "VEH" + Guid.NewGuid().ToString();
        }
    }
}

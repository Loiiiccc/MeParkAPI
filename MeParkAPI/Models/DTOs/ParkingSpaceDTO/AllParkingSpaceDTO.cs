using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MeParkAPI.Models.DTOs.ParkingSpaceDTO
{
    public class AllParkingSpaceDTO
    {
        public string Id { get; set; }
        public int PlaceNumber { get; set; }
        public string State { get; set; }
        public string Parking { get; set; }
    }
}

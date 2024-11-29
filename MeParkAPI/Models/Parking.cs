using System.ComponentModel.DataAnnotations;

namespace MeParkAPI.Models
{
    public class Parking
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Capacity { get; set; }

        public List<ParkingSpace> ParkingSpaces { get; set; }

        public Parking()
        {
            Id = "PRK" + Guid.NewGuid().ToString();
        }
    }
}

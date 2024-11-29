using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeParkAPI.Models
{
    public class ParkingSpace
    {
        [Key]
        public string Id { get; set; }
        [Column(Order = 1)]
        public int PlaceNumber { get; set; }
        public string State { get; set; }

        public string IdParking { get; set; }
        public Parking Parking { get; set; }


        public IList<Transaction> Transactions { get; set; }


        public ParkingSpace()
        {
            Id = "PRKSP" + Guid.NewGuid().ToString();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MeParkAPI.Models
{
    public class ParkingFee
    {
        [Key]
        public string Id { get; set; }
        [Precision(10, 2)]
        public decimal Amount { get; set; }
        public string Type { get; set; }

        public IList<Transaction> Transactions { get; set; }

        public ParkingFee()
        {
            Id = "PKFE" + Guid.NewGuid().ToString();
        }
    }
}

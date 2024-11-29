using MeParkAPI.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MeParkAPI.Models
{
    public class Transaction
    {
        [Key]
        public string Id { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime? ExitTime { get; set; }
        [Precision(10, 2)]
        public decimal AmountPaid { get; set; }

        public string IdOwer { get; set; }
        public ApplicationUser Owner { get; set; }

        public string IdSpace { get; set; }
        public ParkingSpace Space { get; set; }

        public string IdFee { get; set; }
        public ParkingFee ParkinsFees { get; set; }

        public Transaction()
        {
            Id = "TRAN" + Guid.NewGuid().ToString();
        }
    }
}

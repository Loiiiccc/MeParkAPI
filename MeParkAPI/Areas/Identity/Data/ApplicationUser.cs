using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeParkAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace MeParkAPI.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }

    public ICollection<Vehicle> Vehicles { get; set; }
    public ICollection<Transaction> Transactions { get; set; }
}


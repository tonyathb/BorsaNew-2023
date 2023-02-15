using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BorsaUsers_12d.Data
{
    public class Customer:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Order> Orders { get; set; } //1:M
    }
}
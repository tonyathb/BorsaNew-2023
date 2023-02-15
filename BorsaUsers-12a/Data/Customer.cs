using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BorsaUsers_12a.Data
{
    public class Customer:IdentityUser
    {
        public string FullName { get; set; }

        public ICollection<Order> Orders { get; set; } //1:M
    }
}
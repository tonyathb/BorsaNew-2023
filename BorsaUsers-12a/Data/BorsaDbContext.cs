using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorsaUsers_12a.Data
{
    public class BorsaDbContext : IdentityDbContext<Customer>
    {
        public BorsaDbContext(DbContextOptions<BorsaDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<TypeProduct> TypesProducts { get; set; }
    }
}

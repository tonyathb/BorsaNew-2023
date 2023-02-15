using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BorsaUsers_12d.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public int TypesProductId { get; set; } //FK    M -->1
        public TypeProduct TypesProducts { get; set; } //table

        public DateTime DateCreated { get; set; }


        public ICollection<Order> Orders { get; set;  // 1 --> M
    }
}
    }

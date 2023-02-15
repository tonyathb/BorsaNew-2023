using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BorsaUsers_12a.Data
{
    public class TypeProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime RegisterOn { get; set; }

        //Connection 1 -- > M
        public ICollection<Product> Products { get; set; }
    }
}

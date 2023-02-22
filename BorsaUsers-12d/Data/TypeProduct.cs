using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace BorsaUsers_12d.Data
{
    public class TypeProduct
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime RegisterOn { get; set; }

        //Connection 1 -- > M
        
        public ICollection<Product> Products { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace BorsaUsers_12d.Models
{
    public class OrderVM
    {
        public int Id { get; set; }

        public int ProductId { get; set; } //FK M --> 1
        public List<SelectListItem> Products { get; set; } //padast spisak

        public string CustomerId { get; set; } //FK  M -->1
        

        public DateTime OrderOn { get; } = DateTime.Now;

    }
}
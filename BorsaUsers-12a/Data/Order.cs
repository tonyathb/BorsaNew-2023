using System;

namespace BorsaUsers_12a.Data
{
    public class Order
    {
        public int Id { get; set; }

        public int ProductId { get; set; } //FK M --> 1
        public Product Products { get; set; } //tablica

        public string CustomerId { get; set; } //FK  M -->1
        public Customer Customers { get; set; } //table

        public DateTime OrderOn { get; } = DateTime.Now;

    }
}
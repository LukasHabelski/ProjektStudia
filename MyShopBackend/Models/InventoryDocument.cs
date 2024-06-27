using System;

namespace MyShopBackend.Models
{
    public class InventoryDocument
    {
        public int Id { get; set; }
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime Date { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;

namespace MyShopBackend.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CalendarTask> CalendarTasks { get; set; }
        public DbSet<InventoryItem> Inventory { get; set; }
        public DbSet<InventoryDocument> InventoryDocuments { get; set; }
    }
}

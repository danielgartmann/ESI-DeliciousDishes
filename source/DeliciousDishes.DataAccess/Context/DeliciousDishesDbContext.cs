using System.Data.Entity;
using DeliciousDishes.DataAccess.Entities;

namespace DeliciousDishes.DataAccess.Context
{

    public class DeliciousDishesDbContext : DbContext
    {
        public DeliciousDishesDbContext()
            : base("DeliciousDishes") 
        {
                   
        }
        public DbSet<DailyOffer> DailyOffers { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuOrder> MenuOrders { get; set; }
    }
}

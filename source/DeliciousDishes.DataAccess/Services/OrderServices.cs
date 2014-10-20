using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliciousDishes.DataAccess.Context;
using DeliciousDishes.DataAccess.Entities;

namespace DeliciousDishes.DataAccess.Services
{
    public class OrderServices
    {
        public MenuOrder GetOrder(long id)
        {
            try
            {
                using (var context = new DeliciousDishesDbContext())
                {
                    return context.MenuOrders.Find(id);
                }
            }
            catch (Exception)
            {
                // Todo:Exception handling
                throw;
            }
        }

        public void CreateOrder(MenuOrder menuOrder)
        {
            try
            {
                using (var context = new DeliciousDishesDbContext())
                {
                    context.MenuOrders.Add(menuOrder);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                // Todo:Exception handling
                throw;
            }
        }
    }
}

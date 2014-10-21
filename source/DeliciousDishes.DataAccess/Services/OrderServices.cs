using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliciousDishes.DataAccess.Context;
using DeliciousDishes.DataAccess.Entities;

namespace DeliciousDishes.DataAccess.Services
{
    public class OrderServices : IOrderServices
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

        public IEnumerable<MenuOrder> GetOrders(string user, DateTime date)
        {
            try
            {
                using (var context = new DeliciousDishesDbContext())
                {
                    return context.MenuOrders.Where(o => o.OrderUser == user && o.DailyOffer.Date == date && !o.IsCancelled);
                }
            }
            catch (Exception)
            {
                // Todo:Exception handling
                throw;
            }
        }

        public void UpdateOrder(long id, long dailyOfferId, string recipientUserId, string remarks)
        {
            try
            {
                using (var context = new DeliciousDishesDbContext())
                {
                    var menuOrder = context.MenuOrders.Find(id);
                    menuOrder.DailyOfferId = dailyOfferId;
                    menuOrder.RecipientUser = recipientUserId;
                    menuOrder.Remarks = remarks;
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                // Todo:Exception handling
                throw;
            }
        }

        public void CancelOrder(long id)
        {
            try
            {
                using (var context = new DeliciousDishesDbContext())
                {
                    var menuOrder = context.MenuOrders.Find(id);
                    menuOrder.IsCancelled = true;
                    menuOrder.CancellationDateTime = DateTime.UtcNow;
                    context.SaveChanges();
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

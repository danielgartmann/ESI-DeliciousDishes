using System;
using System.Collections.Generic;
using System.Linq;
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
                return null;
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

        public bool UpdateOrder(long id, long dailyOfferId, string recipientUserId, string remarks)
        {
            try
            {
                using (var context = new DeliciousDishesDbContext())
                {
                    var menuOrder = context.MenuOrders.Find(id);
                    if (menuOrder == null)
                    {
                        return false;
                    }

                    menuOrder.DailyOfferId = dailyOfferId;
                    menuOrder.RecipientUser = recipientUserId;
                    menuOrder.Remarks = remarks;
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                // Todo:Exception handling
                return false;
            }
        }

        public bool CancelOrder(long id)
        {
            try
            {
                using (var context = new DeliciousDishesDbContext())
                {
                    var menuOrder = context.MenuOrders.Find(id);
                    if (menuOrder == null)
                    {
                        return false;
                    }

                    menuOrder.IsCancelled = true;
                    menuOrder.CancellationDateTime = DateTime.UtcNow;
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                // Todo:Exception handling
                return false;
            }
        }

        public long CreateOrder(long dailyOfferId, string orderUserId, string recipientUserId, string remarks)
        {
            try
            {
                using (var context = new DeliciousDishesDbContext())
                {
                    var newOrder = new MenuOrder()
                    {
                        DailyOfferId = dailyOfferId,
                        OrderUser = orderUserId,
                        RecipientUser = recipientUserId,
                        Remarks = remarks
                    };

                    context.MenuOrders.Add(newOrder);
                    context.SaveChanges();
                    return newOrder.Id;
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

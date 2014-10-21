using System;
using System.Collections.Generic;
using DeliciousDishes.DataAccess.Entities;

namespace DeliciousDishes.DataAccess.Services
{
    public interface IOrderServices
    {
        MenuOrder GetOrder(long id);
        long CreateOrder(long dailyOfferId, string orderUserId, string recipientUserId, string remarks);
        void CancelOrder(long id);
        void UpdateOrder(long id, long dailyOfferId, string recipientUserId, string remarks);
        IEnumerable<MenuOrder> GetOrders(string user, DateTime date);
    }
}
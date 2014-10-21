using System;
using System.Collections.Generic;
using DeliciousDishes.DataAccess.Entities;

namespace DeliciousDishes.DataAccess.Services
{
    public interface IOrderServices
    {
        MenuOrder GetOrder(long id);
        void CreateOrder(MenuOrder menuOrder);
        void CancelOrder(long id);
        void UpdateOrder(long id, long dailyOfferId, string recipientUserId, string remarks);
        IEnumerable<MenuOrder> GetOrders(string user, DateTime date);
    }
}
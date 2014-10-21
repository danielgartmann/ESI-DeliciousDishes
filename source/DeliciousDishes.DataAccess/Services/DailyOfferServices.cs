using System;
using System.Collections.Generic;
using System.Linq;
using DeliciousDishes.DataAccess.Context;
using DeliciousDishes.DataAccess.Entities;

namespace DeliciousDishes.DataAccess.Services
{
    public class DailyOfferServices : IDailyOfferServices
    {
        public IEnumerable<DailyOffer> GetDailyOffers(DateTime date)
        {
            try
            {
                using (var context = new DeliciousDishesDbContext())
                {
                    var dailyOffers = context.DailyOffers.Include("Menu").Where(d => d.Date == DateTime.Today);
                    return dailyOffers.ToList();
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

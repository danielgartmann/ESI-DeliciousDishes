using System;
using System.Collections.Generic;
using DeliciousDishes.DataAccess.Entities;

namespace DeliciousDishes.DataAccess.Services
{
    public interface IDailyOfferServices
    {
        IEnumerable<DailyOffer> GetDailyOffers(DateTime date);
    }
}
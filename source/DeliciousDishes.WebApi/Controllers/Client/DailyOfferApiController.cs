using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DeliciousDishes.DataAccess.Context;
using DeliciousDishes.WebApi.Models.Client;

namespace DeliciousDishes.WebApi.Controllers.Client
{
    public class DailyOfferApiController : ApiController
    {
        [HttpGet]
        [Route("client/dailyOffer")]
        public IHttpActionResult GetOffers(DateTime date)
        {
            try
            {
                using (var context = new DeliciousDishesDbContext())
                {
                    var dailyOffers = context.DailyOffers
                        .Where(d => d.Date == DateTime.Today)
                        .Select(o => new DailyOfferDto()
                        {
                            DailyOfferId = o.Id,
                            Description = o.Menu.Description,
                            ImageUrl = o.Menu.ImageUrl,
                            Price = o.Menu.Price,
                            Stock = o.Stock,
                            Title = o.Menu.Title
                        }).ToList();
                    return this.Ok(dailyOffers);
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

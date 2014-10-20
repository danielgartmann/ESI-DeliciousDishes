using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DeliciousDishes.DataAccess.Context;
using DeliciousDishes.DataAccess.Services;
using DeliciousDishes.WebApi.Models.Client;

namespace DeliciousDishes.WebApi.Controllers.Client
{
    public class DailyOfferApiController : ApiController
    {
        private DailyOfferServices dailyOfferServices = new DailyOfferServices();

        [HttpGet]
        [Route("client/dailyOffer")]
        public IHttpActionResult GetOffers(DateTime date)
        {
            var dailyOffers = this.dailyOfferServices.GetDailyOffers(date)
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
}

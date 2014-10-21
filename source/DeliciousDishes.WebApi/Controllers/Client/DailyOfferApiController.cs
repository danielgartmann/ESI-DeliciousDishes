using System;
using System.Linq;
using System.Web.Http;
using DeliciousDishes.DataAccess.Services;
using DeliciousDishes.WebApi.Models.Client;

namespace DeliciousDishes.WebApi.Controllers.Client
{
    public class DailyOfferApiController : ApiController
    {
        private readonly IDailyOfferServices dailyOfferServices = new DailyOfferServices();

        [HttpGet]
        [Route("client/dailyOffer")]
        public IHttpActionResult GetOffers(DateTime date)
        {
            var dailyOffers = dailyOfferServices.GetDailyOffers(date)
                .Select(o => new DailyOfferDto
                {
                    DailyOfferId = o.Id,
                    Description = o.Menu.Description,
                    ImageUrl = o.Menu.ImageUrl,
                    Price = o.Menu.Price,
                    Stock = o.Stock,
                    Title = o.Menu.Title
                }).ToList();
            return Ok(dailyOffers);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Web.Http;
using DeliciousDishes.WebApi.Models.Client;

namespace DeliciousDishes.WebApi.Controllers.Client
{
    public class DailyOfferApiController : ApiController
    {
        [HttpGet]
        [Route("client/dailyOffer")]
        public IHttpActionResult GetOffers(DateTime date)
        {
            var someOffers = new List<DailyOfferDto>(new[]
            {
                new DailyOfferDto()
                {
                    DailyOfferId = 123,
                    Title = "Käsesuppe mit Parmesan",
                    Description = "hhhhm sehr fein...",
                    Price = 12.5,
                    Stock = 12,
                    ImageUrl = "http://www.sundancesquare.com/files/4213/2381/3456/Simply-Fondue.jpg"
                },
                
                new DailyOfferDto()
                {
                    DailyOfferId = 123,
                    Title = "Cheese Burger mit Pommes",
                    Description = "Mit Käse überbackenes Schweinsmedalion in Teighülle dazu fritierte Kartoffel ",
                    Price = 10.5,
                    Stock = 18,
                    ImageUrl = "http://www.snexx.de/Cheeseburger___Pommes_BREIT.jpg"
                }

            });

            return this.Ok(someOffers);
        }
    }
}

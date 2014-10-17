using System;
using System.Collections.Generic;
using System.Web.Http;
using DeliciousDishes.WebApi.Models.Client;

namespace DeliciousDishes.WebApi.Controllers.Client
{
    public class DailyOfferController : ApiController
    {
        [HttpGet]
        [Route("client/dailyOffer")]
        public IHttpActionResult GetOffers(DateTime date)
        {
            var someOffers = new List<DailyOfferDto>();

            return this.Ok(someOffers);
        }
    }
}

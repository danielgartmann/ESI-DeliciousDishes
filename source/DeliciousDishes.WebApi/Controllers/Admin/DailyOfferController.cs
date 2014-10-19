using System.Web.Http;
using DeliciousDishes.WebApi.Filter;
using DeliciousDishes.WebApi.Models.Admin;

namespace DeliciousDishes.WebApi.Controllers.Admin
{
    public class DailyOfferController : ApiController
    {
        [HttpPost]
        [Route("admin/dailyOffer")]
        [EnsureHasContentFilter]
        public IHttpActionResult AddDailyOffer([FromBody] DailyOfferDto dailyOffer)
        {
            return Created("admin/dailyOffer/1", dailyOffer);
        }
    }
}

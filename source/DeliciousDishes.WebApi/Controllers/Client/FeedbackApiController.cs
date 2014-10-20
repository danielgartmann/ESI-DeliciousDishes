using System.Web.Http;
using DeliciousDishes.WebApi.Filter;
using DeliciousDishes.WebApi.Models.Client;

namespace DeliciousDishes.WebApi.Controllers.Client
{
    public class FeedbackApiController : ApiController
    {
        [HttpPost]
        [Route("client/feedback")]
        [EnsureHasContentFilter]
        [ValidateModelFilter]
        public IHttpActionResult AddFeedback([FromBody] FeedbackDto feedback)
        {
            return this.Ok();
        }

    }
}

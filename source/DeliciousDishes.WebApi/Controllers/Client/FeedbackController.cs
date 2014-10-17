using System.Web.Http;
using DeliciousDishes.WebApi.Filter;
using DeliciousDishes.WebApi.Models.Client;

namespace DeliciousDishes.WebApi.Controllers.Client
{
    public class FeedbackController : ApiController
    {
        [HttpPost]
        [Route("client/feedback")]
        [EnsureContentFilter]
        [ValidateModelFilter]
        public IHttpActionResult AddFeedback([FromBody] FeedbackDto feedback)
        {
            return this.Ok();
        }

    }
}

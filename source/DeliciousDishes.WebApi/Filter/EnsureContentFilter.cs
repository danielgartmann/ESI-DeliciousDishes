using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using DeliciousDishes.WebApi.Infrastructure;

namespace DeliciousDishes.WebApi.Filter
{
    public class EnsureContentFilter : ActionFilterAttribute, IOrderedFilter
    {
        private const string ContentMissingCode = "ContentMissing";
        private const string ContentMissingMessage = "Missing content";

        public EnsureContentFilter()
        {
            this.Order = 20;
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.Request.Content == null)
            {
                throw new HttpResponseException(new ApiErrorHttpResponseMessage(new GeneralApiError { Code = ContentMissingCode, Message = ContentMissingMessage }));
            }

            base.OnActionExecuting(actionContext);
        }

        public int Order { get; set; }
    }
}
using System;
using System.Web.Http;

namespace DeliciousDishes.WebApi.Controllers
{
    public class OrderController : ApiController
    {
        [Route("order")]
        [HttpPost]
        IHttpActionResult NewOrder(MenuOrderDto order)
        {
            var theInsertedOrder = order;
            var aInsertedId = new Random(DateTime.UtcNow.Millisecond).Next(0, 10 ^ 6);
            theInsertedOrder.MenuOrderId = aInsertedId;

            return Created("/order/" + aInsertedId, theInsertedOrder);
        }
    }
}

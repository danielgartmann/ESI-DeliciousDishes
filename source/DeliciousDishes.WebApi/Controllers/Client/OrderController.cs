using System;
using System.Collections.Generic;
using System.Web.Http;
using DeliciousDishes.WebApi.Filter;
using DeliciousDishes.WebApi.Models.Client;

namespace DeliciousDishes.WebApi.Controllers.Client
{
    public class OrderController : ApiController
    {
        [Route("client/order")]
        [HttpPost]
        [EnsureHasContentFilter]
        [ValidateModelFilter]
        public IHttpActionResult NewOrder([FromBody] MenuOrderDto order)
        {
            var theInsertedOrder = order;
            var aInsertedId = new Random(DateTime.UtcNow.Millisecond).Next(0, 1000);
            theInsertedOrder.MenuOrderId = aInsertedId;

            return this.Created("/order/" + aInsertedId, theInsertedOrder);
        }

        [Route("client/order/{menuOrderId}")]
        [HttpGet]
        public IHttpActionResult ShowOrder(long menuOrderId)
        {
            var theOrderFromDatabase = new MenuOrderDto
            {
                MenuOrderId = menuOrderId,
                OrderUserId = "you",
                DailyOfferId = 1234,
                RecipientUserId = "other"
            };

            return this.Ok(theOrderFromDatabase);
        }

        [Route("client/order")]
        [HttpPut]
        [EnsureHasContentFilter]
        [ValidateModelFilter]
        public IHttpActionResult UpdateOrder([FromBody] MenuOrderDto order)
        {
            return this.Ok(order);
        }

        [Route("client/order")]
        [HttpDelete]
        public IHttpActionResult CancelOrder(long orderId)
        {
            // TODO: Cancel the Order
            return this.Ok();
        }

        [Route("client/order/")]
        [HttpGet]
        public IHttpActionResult ShowList(string user, DateTime date)
        {
            var orderUserId = user;

            var random = new Random(DateTime.UtcNow.Millisecond);
            
            var orders = new List<MenuOrderDto>(new[]
            {
                new MenuOrderDto()
                {
                    DailyOfferId = 12345,
                    MenuOrderId = random.Next(0, 1000),
                    OrderUserId = orderUserId,
                    RecipientUserId = "other",
                }, 
                new MenuOrderDto()
                {
                    DailyOfferId = 12345,
                    MenuOrderId = random.Next(0, 1000),
                    OrderUserId = orderUserId,
                    RecipientUserId = orderUserId,
                }, 
            });

            return this.Ok(orders);
        }
    }
}

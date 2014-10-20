using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DeliciousDishes.DataAccess.Context;
using DeliciousDishes.DataAccess.Entities;
using DeliciousDishes.DataAccess.Services;
using DeliciousDishes.WebApi.Filter;
using DeliciousDishes.WebApi.Models.Client;

namespace DeliciousDishes.WebApi.Controllers.Client
{
    public class OrderApiController : ApiController
    {
        private readonly OrderServices orderServices = new OrderServices();

        [Route("client/order")]
        [HttpPost]
        [EnsureHasContentFilter]
        [ValidateModelFilter]
        public IHttpActionResult NewOrder([FromBody] MenuOrderDto order)
        {
            var menuOrder = new MenuOrder
            {
                OrderUser = order.OrderUserId,
                DailyOfferId = order.DailyOfferId,
                RecipientUser = order.RecipientUserId,
                Remarks = order.Remarks
            };
            orderServices.CreateOrder(menuOrder);

            return this.Created("/order/" + menuOrder.Id, order);
        }

        [Route("client/order/{menuOrderId}")]
        [HttpGet]
        public IHttpActionResult ShowOrder(long menuOrderId)
        {
            // Todo: Exception handling
            var menuOrder = orderServices.GetOrder(menuOrderId);
            var menuOrderDto = new MenuOrderDto
            {
                MenuOrderId = menuOrder.Id,
                OrderUserId = menuOrder.OrderUser,
                DailyOfferId = menuOrder.DailyOfferId,
                RecipientUserId = menuOrder.RecipientUser,
            };
            return this.Ok(menuOrderDto);
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

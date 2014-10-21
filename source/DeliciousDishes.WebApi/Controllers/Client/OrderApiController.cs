using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DeliciousDishes.DataAccess.Entities;
using DeliciousDishes.DataAccess.Services;
using DeliciousDishes.WebApi.Filter;
using DeliciousDishes.WebApi.Models.Client;

namespace DeliciousDishes.WebApi.Controllers.Client
{
    public class OrderApiController : ApiController
    {
        private readonly IOrderServices orderServices = new OrderServices();

        [Route("client/order")]
        [HttpPost]
        [EnsureHasContentFilter]
        [ValidateModelFilter]
        public IHttpActionResult NewOrder([FromBody] MenuOrderDto order)
        {
            // Todo: Exception handling
            var newOrderId = orderServices.CreateOrder(order.DailyOfferId, order.OrderUserId, order.RecipientUserId, order.Remarks);

            return Created("/order/" + newOrderId, order);
        }

        [Route("client/order/{menuOrderId}")]
        [HttpGet]
        public IHttpActionResult ShowOrder(long menuOrderId)
        {
            // Todo: Exception handling
            var menuOrder = orderServices.GetOrder(menuOrderId);

            if (menuOrder == null)
            {
                return NotFound();
            }

            var menuOrderDto = new MenuOrderDto
            {
                MenuOrderId = menuOrder.Id,
                OrderUserId = menuOrder.OrderUser,
                DailyOfferId = menuOrder.DailyOfferId,
                RecipientUserId = menuOrder.RecipientUser,
            };
            return Ok(menuOrderDto);
        }

        [Route("client/order")]
        [HttpPut]
        [EnsureHasContentFilter]
        [ValidateModelFilter]
        public IHttpActionResult UpdateOrder([FromBody] MenuOrderDto order)
        {
            if (orderServices.UpdateOrder(order.MenuOrderId, order.DailyOfferId, order.RecipientUserId, order.Remarks))
            {
                return Ok(order);
            }
            else
            {
                return NotFound();
            }

        }

        [Route("client/order")]
        [HttpDelete]
        public IHttpActionResult CancelOrder(long orderId)
        {
            if (orderServices.CancelOrder(orderId))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [Route("client/order/")]
        [HttpGet]
        public IHttpActionResult ShowList(string user, DateTime date)
        {
            var orderUserId = user;

            // Todo: Exception handling
            var orders = orderServices.GetOrders(user, date).Select(o => new MenuOrderDto
            {
                CancellationDateTime = o.CancellationDateTime,
                DailyOfferId = o.DailyOfferId,
                IsCancelled = o.IsCancelled,
                MenuOrderId = o.Id,
                OrderUserId = o.OrderUser,
                RecipientUserId = o.RecipientUser,
                Remarks = o.Remarks
            });

            return Ok(orders);
        }
    }
}

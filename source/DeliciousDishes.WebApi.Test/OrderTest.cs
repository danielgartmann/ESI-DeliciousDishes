using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using DeliciousDishes.DataAccess.Context;
using DeliciousDishes.DataAccess.Entities;
using DeliciousDishes.WebApi.Models.Client;
using Microsoft.Owin.Hosting;
using Newtonsoft.Json;
using NUnit.Framework;


namespace DeliciousDishes.WebApi.Test
{
    public class OrderTest
    {
        private readonly HttpClient httpClient;
        private readonly string baseAddress;
        private IDisposable webApp;

        private const string MinimalisticOrderSample = @"
            {
                'DailyOfferId': 123,
                'OrderUserId': 'mis'
            }";

        public OrderTest()
        {
            this.baseAddress = "http://localhost:9000/";

            // Start OWIN host 
            this.webApp = WebApp.Start<Startup>(baseAddress);

            this.httpClient = new HttpClient();
        }

        private Menu testMenu1;
        private DailyOffer testDailyOffer1;

        [SetUp]
        public void BeforeTest()
        {
            using (var context = new DeliciousDishesDbContext())
            {
                //context.MenuOrders.RemoveRange(context.MenuOrders);
                //context.DailyOffers.RemoveRange(context.DailyOffers);
                //context.Menus.RemoveRange(context.Menus);

                testMenu1 = new Menu { Description = "Test menu", Price = 12.5, Title = "Pasta" };
                context.Menus.Add(testMenu1);
                testDailyOffer1 = new DailyOffer { Date = DateTime.Today, Menu = testMenu1, Stock = 12 };
                context.DailyOffers.Add(testDailyOffer1);
                context.SaveChanges();
            }
        }

        [TearDown]
        public void AfterTest()
        {
            using (var context = new DeliciousDishesDbContext())
            {
                context.DailyOffers.Remove(context.DailyOffers.Single(d => d.Id == testDailyOffer1.Id));
                context.Menus.Remove(context.Menus.Single(d => d.Id == testMenu1.Id));
                context.SaveChanges();
            }
        } 

        [TestCase]
        public void SendAndOrder_WithAllFilledOut_ShouldReturnOk()
        {
            var response = httpClient.PostAsync(baseAddress + "client/order", new StringContent(MinimalisticOrderSample, Encoding.UTF8, "application/json")).Result;

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

        [TestCase]
        public void RequestDailyOffer_WithDate_ReturnsAList()
        {
            var url = string.Format(baseAddress + "client/dailyoffer?date={0:yyyy-MM-dd}", DateTime.UtcNow);

            var response = httpClient.GetAsync(url).Result;
            var content = response.Content.ReadAsStringAsync().Result;

            var listOfOffers = JsonConvert.DeserializeObject<DailyOfferDto[]>(content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.GreaterOrEqual(listOfOffers.Count(), 1);
            Assert.IsTrue(listOfOffers.Any(o => o.DailyOfferId == testDailyOffer1.Id));
            
        }
    }
}

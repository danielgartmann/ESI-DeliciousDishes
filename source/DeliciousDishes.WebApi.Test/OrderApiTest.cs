using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using DeliciousDishes.DataAccess.Context;
using DeliciousDishes.DataAccess.Entities;
using Microsoft.Owin.Hosting;
using NUnit.Framework;


namespace DeliciousDishes.WebApi.Test
{
    public class OrderApiTest
    {
        private readonly HttpClient httpClient;
        private readonly string baseAddress;
        private IDisposable webApp;

        private const string MinimalisticOrderSample = @"
            {
                'DailyOfferId': 123,
                'OrderUserId': 'mis'
            }";

        private Menu testMenu1;
        private DailyOffer testDailyOffer1;

        [SetUp]
        public void BeforeTest()
        {
            using (var context = new DeliciousDishesDbContext())
            {
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

        public OrderApiTest()
        {
            this.baseAddress = "http://localhost:9001/";

            // Start OWIN host 
            this.webApp = WebApp.Start<Startup>(baseAddress);

            this.httpClient = new HttpClient();
        }

        [TestCase]
        public void PostOrder_WithAllFilledOut_ShouldReturnOk()
        {
            var response = httpClient.PostAsync(baseAddress + "client/order", new StringContent(CreateOrderSample(), Encoding.UTF8, "application/json")).Result;

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

        [TestCase]
        public void PostOrder_ValidOrder_MustBeStoredInDb()
        {
            var response = httpClient.PostAsync(baseAddress + "client/order", new StringContent(CreateOrderSample(), Encoding.UTF8, "application/json")).Result;

            using (var context = new DeliciousDishesDbContext())
            {
                Assert.AreEqual(1, context.MenuOrders.Count(o => o.DailyOfferId == testDailyOffer1.Id));
            }
        }

        private string CreateOrderSample()
        {
            return 
            @"{
                'DailyOfferId': " + testDailyOffer1.Id + @",
                'OrderUserId': 'mis'
            }";
        }
    }
}

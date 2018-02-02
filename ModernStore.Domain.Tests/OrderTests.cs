using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernStore.Domain.Entities;

namespace ModernStore.Domain.Tests
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        [TestCategory("Order - new order")]
        public void GivenAnOutOfStockProductItShouldReturnAnError()
        {

            var user = new User("danielvieiravega", "Vega123");
            var customer = new Customer("Daniel", "Vieira", "daniel@teste.com", user);
            var mouse = new Product("mouse", 299, "mouse.jpg", 0);

            var order = new Order(customer, 8, 10);
            order.AddItem(new OrderItem(mouse, 2));

            Assert.IsFalse(order.IsValid());

        }

        [TestMethod]
        [TestCategory("Order - new order")]
        public void GivenAnInStockProductItShouldUpdateQuantityOnHand()
        {

            var user = new User("danielvieiravega", "Vega123");
            var customer = new Customer("Daniel", "Vieira", "daniel@teste.com", user);
            var mouse = new Product("mouse", 299, "mouse.jpg", 0);

            var order = new Order(customer, 8, 10);
            order.AddItem(new OrderItem(mouse, 2));

            Assert.IsTrue(mouse.QuantityOnHand == 18);

        }


        [TestMethod]
        [TestCategory("Order - new order")]
        public void GivenAnInValidOrderTheTotalShouldBe310()
        {
            var user = new User("danielvieiravega", "Vega123");
            var customer = new Customer("Daniel", "Vieira", "daniel@teste.com", user);
            var mouse = new Product("mouse", 300, "mouse.jpg", 0);

            var order = new Order(customer, 12, 1);
            order.AddItem(new OrderItem(mouse, 1));

            Assert.IsTrue(order.Total() == 310);
        }
    }
}

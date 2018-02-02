using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernStore.Domain.Entities;

namespace ModernStore.Domain.Tests
{
    [TestClass]
    public class CustomerTests
    {
        private readonly User _user = new User("danielvieiravega", "123qwe!@#");   

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidFirstNameShouldReturnaANotification()
        {
           
            var customer = new Customer("", "Vega", "daniel@teste.com",_user);
            Assert.IsFalse(customer.IsValid());
        }

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidLastNameShouldReturnaANotification()
        {
            var customer = new Customer("Daniel", "", "daniel@teste.com", _user);
            Assert.IsFalse(customer.IsValid());
        }

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidEmailShouldReturnaANotification()
        {
            var customer = new Customer("Daniel", "Vega", "", _user);
            Assert.IsFalse(customer.IsValid());
        }
    }
}

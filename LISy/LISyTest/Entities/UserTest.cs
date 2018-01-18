using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LISy.Entities;

namespace LISyTest.Entities
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void User_Constructor()
        {
            string name = "Example name", phone = "1234567", address = "Example address";
            long cardNumber = 1;

            User user = new User(name, cardNumber, phone, address);

            Assert.AreEqual(user.Name, name);
            Assert.AreEqual(user.CardNumber, cardNumber);
            Assert.AreEqual(user.Phone, phone);
            Assert.AreEqual(user.Address, address);
        }
    }
}

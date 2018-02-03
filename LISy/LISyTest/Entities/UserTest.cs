using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LISy.Entities;
using LISy.Entities.Users;
using LISy.Entities.Users.Patrons;

namespace LISyTest.Entities
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void User_Constructor()
        {
            string firstName = "Example first name", secondName = "Example second name", phone = "1234567", address = "Example address";
            long cardNumber = 1;

            User user = new Faculty(firstName, secondName, cardNumber, phone, address);

            Assert.AreEqual(user.FirstName, firstName);
            Assert.AreEqual(user.SecondName, secondName);
            Assert.AreEqual(user.CardNumber, cardNumber);
            Assert.AreEqual(user.Phone, phone);
            Assert.AreEqual(user.Address, address);
        }
    }
}

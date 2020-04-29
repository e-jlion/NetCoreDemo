using NUnit.Framework;
using System;

namespace Jlion.NetCore.User.Application.Test
{
    public class Tests : BaseTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void User_AddTest()
        {
            var bl = userService.AddAsync(new Domain.Entities.UserEntity()
            {
                AddTime = DateTime.Now,
                MerchantId = 10002,
                Password = "123456",
                RealName = "dotNET²©Ê¿",
                UserName = "test"
            }).GetAwaiter().GetResult();

            Assert.IsTrue(bl);
        }

        [Test]
        public void User_GetTest()
        {
            var user = userService.GetByIdAsync(1, 10001).GetAwaiter().GetResult();
            Assert.IsTrue(user != null);
        }
    }
}
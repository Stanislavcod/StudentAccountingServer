using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StudentAccounting.BusinessLogic.Services.Contracts;
using StudentAccounting.Controllers;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccountingServer.Tests.Implementations
{
    [TestClass]
    public class UserControllerTests
    {
        private readonly UserController _controller;
        private readonly Mock<IUserService> _mockUserService;

        public UserControllerTests()
        {
            _mockUserService = new Mock<IUserService>();
            _controller = new UserController(_mockUserService.Object);
        }

        [TestMethod]
        public void Get_ReturnsUsers()
        {
            // Arrange
            _mockUserService.Setup(service => service.Get()).Returns(new[]
            {
                new User { Id = 1, Login = "login1", Password = "password1" },
                new User { Id = 2, Login = "login2", Password = "password2" }
            });

            // Act
            var result = _controller.Get();

            // Assert
            var actionResult = result;
            Assert.IsNotNull(actionResult);
            var users = actionResult.Value as IEnumerable<User>;
            Assert.IsNotNull(users);
            var list = users.ToList();
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(1, list[0].Id);
            Assert.AreEqual("login1", list[0].Login);
            Assert.AreEqual("password1", list[0].Password);
            Assert.AreEqual(2, list[1].Id);
            Assert.AreEqual("login2", list[1].Login);
            Assert.AreEqual("password2", list[1].Password);
        }

        [TestMethod]
        public void Get_WithLogin_ReturnsUser()
        {
            // Arrange
            _mockUserService.Setup(service => service.Get("login1")).Returns(new User { Id = 1, Login = "login1", Password = "password1" });

            // Act
            var result = _controller.Get("login1");

            // Assert
            var actionResult = result as OkObjectResult;
            Assert.IsNotNull(actionResult);
            var user = actionResult.Value as User;
            Assert.IsNotNull(user);
            Assert.AreEqual(1, user.Id);
            Assert.AreEqual("login1", user.Login);
            Assert.AreEqual("password1", user.Password);
        }
    }
}
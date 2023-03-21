using BioscoopSysteemAPI.Controllers;
using BioscoopSysteemAPI.DTOs;
using BioscoopSysteemAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BioscoopSysteemAPI.Tests.Controllers
{
    [TestClass]
    public class MailControllerTests
    {
        private readonly MailDataDto _mailDataDto = new MailDataDto
        {
            To = "test@example.com",
            Subject = "Test email",
            Body = "This is a test email."
        };

        [TestMethod]
        public void SendMail_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var mockMailService = new Mock<IMailService>();
            mockMailService.Setup(mailService => mailService.SendEmail(_mailDataDto));

            var mailController = new MailController(mockMailService.Object);

            // Act
            var result = mailController.SendMail(_mailDataDto);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void SendMail_InvalidRequest_ReturnsBadRequestResult()
        {
            // Arrange
            var mockMailService = new Mock<IMailService>();
            mockMailService.Setup(mailService => mailService.SendEmail(null));

            var mailController = new MailController(mockMailService.Object);

            // Act
            var result = mailController.SendMail(null);

            // Assert
            Assert.IsNotInstanceOfType(result, typeof(OkObjectResult));
        }
    }
}

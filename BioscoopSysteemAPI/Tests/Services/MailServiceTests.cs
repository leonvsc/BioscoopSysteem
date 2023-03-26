using BioscoopSysteemAPI.DTOs;
using BioscoopSysteemAPI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace BioscoopSysteemAPI.Tests.Services
{
    [TestClass]
    public class MailServiceTests
    {
        private readonly Mock<IConfiguration> _configMock = new();
        private MailService _mailService;

        [TestInitialize]
        public void TestInitialize()
        {
            _configMock.Setup(x => x.GetSection("EmailUsername").Value).Returns("test@example.com");
            _configMock.Setup(x => x.GetSection("EmailPassword").Value).Returns("password");
            _configMock.Setup(x => x.GetSection("EmailHost").Value).Returns("smtp.example.com");

            _mailService = new MailService(_configMock.Object);
        }

        [TestMethod]
        public void SendEmail_ThrowsArgumentNullException_WhenToAddressIsNull()
        {
            // Arrange
            var request = new MailDataDto
            {
                To = null,
                Subject = "Test email",
                Body = "<p>This is a test email.</p>"
            };

            // Act and Assert
            Assert.ThrowsException<ArgumentNullException>(() => _mailService.SendEmail(request));
        }
    }
}
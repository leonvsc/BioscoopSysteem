
using BioscoopSysteemAPI.DTOs;
using BioscoopSysteemAPI.Services;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;

namespace BioscoopSysteemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : Controller
    {
        private readonly IMailService _mail;

        public MailController(IMailService mail)
        {
            _mail = mail;
        }
        [HttpPost("sendmail")]
        public IActionResult SendMail(MailDataDto request)
        {
            _mail.SendEmail(request);
            return Ok();
        }
    }
}

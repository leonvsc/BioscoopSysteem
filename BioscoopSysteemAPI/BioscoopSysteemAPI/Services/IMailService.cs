using BioscoopSysteemAPI.DTOs;

namespace BioscoopSysteemAPI.Services
{
    public interface IMailService
    {
        void SendEmail(MailDataDto mailData);
    }
}

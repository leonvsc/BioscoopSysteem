using BioscoopSysteemAPI.DTOs;

namespace BioscoopSysteemWeb.Service.Contracts
{
    public interface IMailService
    {
        Task<MailDataDto> SubscribeEmail(string email);
    }
}

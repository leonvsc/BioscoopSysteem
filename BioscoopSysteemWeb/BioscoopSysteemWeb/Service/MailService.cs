using BioscoopSysteemAPI.DTOs.MovieDTOs;
using System.Net.Http;
using BioscoopSysteemWeb.Service.Contracts;
using BioscoopSysteemAPI.DTOs;
using System.Net.Http.Json;

namespace BioscoopSysteemWeb.Service
{
    public class MailService : IMailService
    {


        private readonly HttpClient _httpClient;

        public MailService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }


        public async Task<MailDataDto> SubscribeEmail(string email)
        {
            MailDataDto mailDataDto = new MailDataDto();
            mailDataDto.To = email;
            mailDataDto.Subject = "test nieuwsbrief";
            mailDataDto.Body = "beste klant, bedankt voor het aanmelden voor de nieuwsbrief groetjes joejoe";

            try
            {
                var response = await _httpClient.PostAsJsonAsync(email, "api/mail/sendmail");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(MailDataDto);
                    }
                    return await response.Content.ReadFromJsonAsync<MailDataDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

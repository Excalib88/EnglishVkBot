using System.Threading.Tasks;

namespace EnglishVkBot.IdentityServer.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}

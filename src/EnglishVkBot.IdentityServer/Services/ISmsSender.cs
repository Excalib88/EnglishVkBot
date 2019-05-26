using System.Threading.Tasks;

namespace EnglishVkBot.IdentityServer.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}

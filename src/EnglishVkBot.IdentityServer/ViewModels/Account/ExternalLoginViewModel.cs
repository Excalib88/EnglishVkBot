using System.ComponentModel.DataAnnotations;

namespace EnglishVkBot.IdentityServer.ViewModels.Account
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}

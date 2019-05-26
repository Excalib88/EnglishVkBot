using System.ComponentModel.DataAnnotations;

namespace EnglishVkBot.IdentityServer.ViewModels.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}

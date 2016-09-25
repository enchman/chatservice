using ProfileModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using AssistModule.Extensions;

namespace ChatService.Models
{
    public class Account: IAccount
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string Username { get; set; }
        public byte[] Password { get; set; }
    }

    public class AccountLogin
    {
        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string Username { get; set; }
        [Required]
        [StringLength(128, MinimumLength = 6)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }

    public class AccountTemplate
    {
        [Required]
        [StringLength(64, MinimumLength = 2)]
        public string DisplayName { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [StringLength(128, MinimumLength = 6, ErrorMessage = "Password is too short, must be at least 6 characters")]
        public string Password { get; set; }

        [Required]
        [StringLength(128, MinimumLength = 6)]
        [Compare("Password", ErrorMessage = "Password is not match")]
        public string Repassword { get; set; }

        public Account Create()
        {
            byte[] hash = Password.ToSecureHash();

            return new Account()
            {
                Username = Username,
                Password = hash,
                DisplayName = DisplayName,
            };
        }
    }
}

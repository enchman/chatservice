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
        [Required]
        [StringLength(64, MinimumLength = 2)]
        public string DisplayName { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string Username { get; set; }

        public byte[] Password { get; set; }
    }

    public class AccountTemplate: Account
    {
        [Required]
        [StringLength(128, MinimumLength = 6, ErrorMessage = "Password is too short, must be at least 6 characters")]
        public string Passcode { get; set; }

        [Required]
        [StringLength(128, MinimumLength = 6)]
        [Compare("Passcode", ErrorMessage = "Password is not match")]
        public string Repasscode { get; set; }

        public bool SetPassword()
        {
            if (Passcode == Repasscode)
            {
                Password = Passcode.ToSecureHash();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

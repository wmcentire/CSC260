using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace WAM_SocialMediaSite_02.Models
{
    public class User
    {
        [Key] 
        public string profileID { get; set; }

        [Required(ErrorMessage = "You did not input a name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You did not input an Email.")]
        public string Email { get; set; }

        public string userImageLink { get; set; }

        [Required(ErrorMessage = "You did not input a password.")]
        public string Password { get; set; }

        public User() { }
    }
}

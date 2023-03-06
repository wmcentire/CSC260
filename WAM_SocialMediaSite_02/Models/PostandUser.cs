using System.ComponentModel.DataAnnotations;
namespace WAM_SocialMediaSite_02.Models
{
    public class PostandUser
    {
        [Key]
        public int Id { get; set; }

        public User user { get; set; }
        public PostClass post { get; set; }
        public string threadID { get; set; }

        public PostandUser() { }
    }
}

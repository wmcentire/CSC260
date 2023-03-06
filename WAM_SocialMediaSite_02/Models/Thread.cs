using System.ComponentModel.DataAnnotations;

namespace WAM_SocialMediaSite_02.Models
{
    public class Thread
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int creatorID { get; set; }

    }
}

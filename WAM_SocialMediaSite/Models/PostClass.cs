using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WAM_SocialMediaSite_02.Models
{
    public class PostClass
    {
        [Key]
        public string? Id { get; set; }

        [Required(ErrorMessage = "You are missing the title.")]
        public string Title { get; set; }
        [AllowNull]
        public string? ImageLink { get; set; }
        [AllowNull]
        public string Description { get; set; }
        [AllowNull]
        public string? Tag { get; set; }

        [AllowNull]
        public string? postUser { get; set; }

        [AllowNull]
        public string? lookUser { get; set; }
    }
}

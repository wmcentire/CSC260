using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GameLibrary.Models
{
    public class Game
    {
        private static int nextID = 0;
        public int? Id { get; set; } = nextID++;
        [Required(ErrorMessage = "A game must have a title.")]
        [MaxLength(100, ErrorMessage = "The title is too long.")]
        public string Title { get; set; } = "[NO TITLE]";
        public double? Cost { get; set; } = 0.00;
        [Required(ErrorMessage = "Please rate the game between 1 and 5.")]
        [Range(1, 5, ErrorMessage = "Please rate the game between 1 and 5.")]
        public float? Rating { get; set; } = 0f;
        public string? ESRB { get; set; } = "Not Rated";
        public string? Image { get; set; }
        [Required(ErrorMessage = "A game must have a platform.")]
        [MaxLength(50, ErrorMessage = "The platform name is too long.")]
        public string? Platform { get; set; }
        [Required(ErrorMessage = "A game must have at least one genre.")]
        [MaxLength(100, ErrorMessage = "The genre names are too long.")]
        public string? Genre { get; set; }
        public bool Available { get; set; } = true;
        public DateTime? CheckOutDate { get; set; }
        public string? CurrentOwner { get; set; } = "";
        public Game()
        {

        }
        public Game(string inTitle, double inCost, float inRating, string inImage, string inPlatform, string? genre, string? eSRB)
        {
            Available = true;
            Title = inTitle;
            Cost = inCost;
            Rating = inRating;
            Image = inImage;
            Platform = inPlatform;
            Genre = genre;
            ESRB = eSRB;
        }
    }
}

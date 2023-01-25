using Microsoft.AspNetCore.Mvc;

namespace GameLibrary.Models
{
    public class Game : Controller
    {
        private static int nextID = 0;
        public int? Id { get; set; } = nextID++;

        public string Title { get; set; } = "[NO TITLE]";
        public double? Cost { get; set; } = 0.00;
        public float? Rating { get; set; } = 0f;
        public string? ESRB { get; set; } = "Not Rated";
        public string Image { get; set; }
        public string? Platform { get; set; }
        public string? Genre { get; set; }
        public bool Available { get; set; } = true;
        public DateTime? CheckOutDate { get; set; }
        public string? CurrentOwner { get; set; } = "";
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

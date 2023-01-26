using System.ComponentModel.DataAnnotations;

namespace Movies.Models
{
    public class Movie
    {
        private static int nextID = 0;
        public int? Id { get; set; } = nextID++;
        [Required(ErrorMessage = "RIP BOZO NO TITLE LMAO")]
        [MaxLength(40)]
        public string Title { get; set; }
        [Required(ErrorMessage = "BRO JUST ADD THE YEAR SMH")]
        [Range(1888,2023, ErrorMessage = "HEY IDIOT LOOK UP THE YEAR IT'S NOT HARD")]
        public int? Year { get; set; }
        [Required(ErrorMessage = "RATE THE MOVIE ALREADY DAMN")]
        [Range(0.1f,5, ErrorMessage = "ARE YOU INCAPABLE OF COUNTING????? 1-5 DUMBASS")]
        public float? Rating { get; set; }

        public DateTime? ReleaseDate { get; set; }
        public string? Image { get; set; }
        public string? Genre { get; set; }

        public Movie()
        {
            
        }
        public Movie(string title, int year, float rating)
        {
            Title = title;
            Year = year;
            Rating = rating;
        }

        public override string ToString()
        {
            return $"{Title} - {Year} - {Rating} stars";
        }

    }
}

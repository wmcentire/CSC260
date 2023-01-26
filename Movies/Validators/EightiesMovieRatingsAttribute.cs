using Movies.Models;
using System.ComponentModel.DataAnnotations;

namespace Movies.Validators
{
    public class EightiesMovieRatingsAttribute : ValidationAttribute
    {
        // custom validator
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;
            
            if(movie.Year >= 1980 &&
                movie.Year <= 1990 &&
                movie.Rating < 2.5f)
            {
                return new ValidationResult("Movies cannot be bad in the eighties");
            } 
            return ValidationResult.Success;
        }
    }
}

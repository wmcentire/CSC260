using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ValidationExercise.Models
{
    public class PersonModel : Controller
    {
        private static int nextID = 0;
        public int? Id { get; set; } = nextID++;
        [Required(ErrorMessage = "RIP BOZO NO NAME LMAO")]
        [MaxLength(40)]
        public string Name { get; set; }
        [Required(ErrorMessage = "BRO HOW OLD ARE YOU")]
        [Range(5, int.MaxValue, ErrorMessage = "NAH THAT'S NOT YOUR AGE")]
        public int? Age { get; set; }
        public string? Address { get; set; }
        public PersonModel()
        {

        }
        public PersonModel(string name, int age, string address)
        {
            Name = name;
            Age = age;
            Address = address;
        }
    }
}

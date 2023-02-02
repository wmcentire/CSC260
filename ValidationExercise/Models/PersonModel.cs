using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ValidationExercise.Models
{
    public class PersonModel
    {
        private static int nextID = 0;
        public int? Id { get; set; } = nextID++;
        [Required(ErrorMessage = "Please enter your name.")]
        [MaxLength(40)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter an age.")]
        [Range(5, int.MaxValue, ErrorMessage = $"Only ages between 5 and up are permitted.")]
        public int? Age { get; set; }
        
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Street { get; set; }
        public int? ZipCode { get; set; }

        public PersonModel()
        {

        }

        public PersonModel(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public PersonModel(string name, int? age, string? address, string? city, string? state, int? zipCode, string? street)
        {
            Name = name;
            Age = age;
            Address = address;
            City = city;
            State = state;
            ZipCode = zipCode;
            Street = street;
        }

        public override string ToString()
        {
            return "Name: " + Name + ", Age: " + Age + ", Address: " + Address;
        }
    }
}

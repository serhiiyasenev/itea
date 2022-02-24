using System;
using System.ComponentModel.DataAnnotations;

namespace CoreBL.Models
{
    public class Car
    {
        public Guid Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(12)]
        public string RegistrationPlate { get; set; }

        public Guid UserId { get; set; }
    }
}

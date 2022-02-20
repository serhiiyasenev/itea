using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace CoreBL.Models
{
    public class Car
    {
        private DateTime _releaseDate;
        
        public Guid Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(12)]
        public string RegistrationPlate { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(25)]
        public string Brand { get; set; }

        [Required]
        public DateTime ReleaseDate
        {
            get => _releaseDate;
            set
            {
                if (!DateTime.TryParse(value.ToString(CultureInfo.InvariantCulture), out _releaseDate))
                {
                    throw new ArgumentException($"Cannot parse ReleaseDate from '{value}'");
                }
                
            }
        }

        List<User> Users { get; set; }
    }
}

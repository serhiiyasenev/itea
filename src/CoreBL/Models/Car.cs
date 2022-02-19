using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace CoreBL.Models
{
    public class Car
    {
        private DateTime _birthDate;
        
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
        public DateTime BirthDate
        {
            get => _birthDate;
            set => _birthDate = DateTime.Parse(value.ToString(CultureInfo.InvariantCulture));
        }

        List<User> Users { get; set; }
    }
}

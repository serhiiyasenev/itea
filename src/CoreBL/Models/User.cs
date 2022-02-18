using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace CoreBL.Models
{
    public class User
    {
        private DateTime _birthDate;
        
        public Guid Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        public DateTime BirthDate
        {
            get => _birthDate;
            set => _birthDate = DateTime.Parse(value.ToString(CultureInfo.InvariantCulture));
        }
    }
}

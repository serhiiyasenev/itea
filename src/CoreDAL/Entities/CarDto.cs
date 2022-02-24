using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreDAL.Entities
{
    [Table("Cars")]
    public class CarDto
    {
        public Guid Id { get; set; }

        public string RegistrationPlate { get; set; }

        public Guid UserId { get; set; }

        public UserDto User { get; set; }

    }
}

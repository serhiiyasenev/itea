using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreDAL.Entities
{
    [Table("Users")]
    public class UserDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public CarDto Car { get; set; }
    }
}

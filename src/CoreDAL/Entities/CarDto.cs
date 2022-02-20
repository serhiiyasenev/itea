using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreDAL.Entities
{
    [Table("Cars")]
    public class CarDto
    {
        [Key, Column("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column("RegistrationPlate")]
        public string RegistrationPlate { get; set; }

        [Column("Brand")]
        public string Brand { get; set; }

        [Column("ReleaseDate")]
        public int ReleaseDate { get; set; }

        public List<UserDto> Users { get; set; }
    }
}

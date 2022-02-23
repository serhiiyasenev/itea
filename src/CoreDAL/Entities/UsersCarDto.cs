using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreDAL.Entities
{
    [Table("UsersCars")]
    public class UsersCarDto
    {
        public Guid UserId { get; set; }
        public Guid CarId { get; set; }
    }
}

using Core;
using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Database.Entity
{
    public class User: BaseEntity
    {
        [MaxLength(255)]
        public string FirstName{ get; set; }

        [MaxLength(255)]
        public string LastName { get; set; }

        [MaxLength(25)]
        public string NickName { get; set; }

        [MaxLength(255)]
        public string MiddleName { get; set; }

        [MaxLength(255)]
        public string Email { get; set; }
    }
}

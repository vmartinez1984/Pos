using System.ComponentModel.DataAnnotations;
using Pos.Core.Validators;

namespace Pos.Core.Dtos
{
    public class UserDto : UserDtoIn
    {
        public string Id { get; set; }

        public DateTime DateRegistration { get; set; }
    }

    public class UserDtoIn
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        [ExistsEmail]
        public string Email { get; set; }

        public string Password { get; set; }

        public string RoleName { get; set; }
        public string UserId { get; set; }
    }

    public class UserLoginDtoIn
    {
        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(12)]
        public string Password { get; set; }
    }
}
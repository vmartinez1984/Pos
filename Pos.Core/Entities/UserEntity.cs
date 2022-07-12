using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pos.Core.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Name { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Password { get; set; }

        //[ForeignKey(nameof(RoleEntity))]
        public string RoleName { get; set; }

        public string UserId { get; set; }
    }
}
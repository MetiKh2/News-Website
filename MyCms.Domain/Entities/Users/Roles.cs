using System.Collections.Generic;
using MyCms.Domain.Common;
namespace MyCms.Domain.Entities.Users
{
    public class Roles:BaseEntity
    {
        public string Role { get; set; }
        public virtual ICollection<UserInRoles> UserInRoles { get; set; }
    }


}

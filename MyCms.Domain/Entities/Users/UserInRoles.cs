using MyCms.Domain.Common;
namespace MyCms.Domain.Entities.Users
{
    public class UserInRoles:BaseEntity
    {
       
        public virtual User User { get; set; }
        public long UserID { get; set; }

        public virtual Roles Role { get; set; }
        public long RoleID { get; set; }
    }


}

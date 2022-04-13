using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCms.Domain.Common;
using MyCms.Domain.Entities.News;

namespace MyCms.Domain.Entities.Users
{
    public class User : BaseEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public virtual List<NewsLikes> Likes { get; set; }
        //public long RoleID { get; set; }
        public virtual ICollection<UserInRoles> UserInRoles { get; set; }

    }


}

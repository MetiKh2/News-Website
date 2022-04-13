using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCms.Domain.Entities.News
{
   public class NewsLikes
    {
        public long ID { get; set; }
        public DateTime InsertTime { get; set; } = DateTime.Now;
        public bool IsRemoved { get; set; }

        public long NewsID { get; set; }
        public List<News> News { get; set; }

        public long UserID { get; set; }
        public List<Users.User> User { get; set; }
    }
}

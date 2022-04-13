using MyCms.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCms.Domain.Entities.News
{
   public class NewsImage:BaseEntity
    {
        public News News { get; set; }
        public long NewsID { get; set; }
        public string Src { get; set; }

    }
}

using MyCms.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCms.Domain.Entities.Categories
{
  public  class Category:BaseEntity
    {
        public string CategoryName { get; set; }
        public virtual ICollection<News.News> News { get; set; }
        public long NewsCount { get; set; }
    }
}


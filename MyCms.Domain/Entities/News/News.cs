using MyCms.Domain.Common;
using MyCms.Domain.Entities.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCms.Domain.Entities.News
{
    public class News : BaseEntity
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Text { get; set; }
        public bool DisPlayed { get; set; }
        public bool IsSlider { get; set; }
        public bool IsInNews { get; set; }
        public long ViewCount { get; set; }
        public long LikeCount { get; set; }
        public virtual List<NewsLikes> Likes { get; set; }
        public virtual Category Category { get; set; }
        public long CategoryID { get; set; }

        public List<NewsImage> NewsImages { get; set; }


    }
}


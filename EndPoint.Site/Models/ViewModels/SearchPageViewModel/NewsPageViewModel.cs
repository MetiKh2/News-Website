using MyCms.Application.Services.Category.Query.GetCategories;
using MyCms.Application.Services.News.Query.GetNewsInNews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MyCms.Application.Services.News.Query.GetNewsForSite.GetNewsForSiteService;

namespace EndPoint.Site.Models.ViewModels.SearchPageViewModel
{
    public class NewsPageViewModel
    {
        public List<NewsForSiteDto> News { get; set; }
        public List<GetNewsInNewsDto> InstantNews { get; set; }
    }
}

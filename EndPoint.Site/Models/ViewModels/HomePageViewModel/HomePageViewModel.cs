using MyCms.Application.Services.Category.Query.GetCategories;
using MyCms.Application.Services.News.Query.GetNewsInNews;
using MyCms.Application.Services.News.Query.GetNewsInSlider;
using MyCms.Application.Services.News.Query.GetNewsOfDay;
using MyCms.Application.Services.News.Query.GetOneTopNews;
using MyCms.Application.Services.News.Query.GetPopularNews;
using MyCms.Application.Services.News.Query.GetTopNews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MyCms.Application.Services.News.Query.GetNewsForSite.GetNewsForSiteService;

namespace EndPoint.Site.Models.ViewModels.HomePageViewModel
{
    public class HomePageViewModel
    {
        public List<GetCategoriesDto> Categories { get; set; }
        public List<NewsForSiteDto> News { get; set; }
        public List<GetTopNewsDto> TopNews { get; set; }
        public GetOneTopNewsDto OneTopNews { get; set; }
        public List<GetNewsInSliderDto> ShowSlider { get; set; }
        public List<GetNewsInNewsDto> InstantNews { get; set; }
        public List<GetNewsOfDayDto>  NewsOfDay { get; set; }
        public List<GetPopularNewsDto> PopularNews { get; set; }

    }
}

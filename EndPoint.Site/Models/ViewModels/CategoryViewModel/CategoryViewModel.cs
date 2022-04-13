using MyCms.Application.Services.Category.Query.GetCategories;
using MyCms.Application.Services.News.Query.GetNewsByCategory;
using MyCms.Application.Services.News.Query.GetNewsInNews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.Models.ViewModels.CategoryViewModel
{
    public class CategoryViewModel
    {
        public List<GetNewsByCategoryDto> News { get; set; }
        public List<GetCategoriesDto> Categories { get; set; }
        public List<GetNewsInNewsDto> instantNews { get; set; }

    }
}

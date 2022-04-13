using EndPoint.Site.Models.ViewModels.CategoryViewModel;
using Microsoft.AspNetCore.Mvc;
using MyCms.Application.Services.Category.Query.GetCategories;
using MyCms.Application.Services.News.Query.GetNewsByCategory;
using MyCms.Application.Services.News.Query.GetNewsInNews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.Controllers
{
    public class CategoryController : Controller
    {
       private readonly  IGetNewsByCategoryService _getNewsByCategoryService;
        private readonly IGetCategoriesService _getCategoriesService;
        private readonly IGetNewsInNewsService _getNewsInNewsService;
        public CategoryController(IGetNewsInNewsService getNewsInNewsService,IGetNewsByCategoryService getNewsByCategoryService,IGetCategoriesService getCategoriesService)
        {
            _getNewsInNewsService = getNewsInNewsService;
            _getCategoriesService = getCategoriesService;
            _getNewsByCategoryService = getNewsByCategoryService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetNewsByCategory(long ID)
        {
            CategoryViewModel categoryViewModel = new CategoryViewModel { 
            News=_getNewsByCategoryService.Execute(ID).Data,
            Categories=_getCategoriesService.Execute().Data,
            instantNews=_getNewsInNewsService.Execute().Data
            };

            return View(categoryViewModel);
        }
    }
}

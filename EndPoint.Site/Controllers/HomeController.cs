using EndPoint.Site.Models;
using EndPoint.Site.Models.ViewModels.HomePageViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyCms.Application.Services.Category.Query.GetCategories;
using MyCms.Application.Services.News.Query.GetNewsForSite;
using MyCms.Application.Services.News.Query.GetNewsInNews;
using MyCms.Application.Services.News.Query.GetNewsInSlider;
using MyCms.Application.Services.News.Query.GetNewsOfDay;
using MyCms.Application.Services.News.Query.GetOneTopNews;
using MyCms.Application.Services.News.Query.GetPopularNews;
using MyCms.Application.Services.News.Query.GetTopNews;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGetCategoriesService _getCategoriesService;
        private readonly ILogger<HomeController> _logger;
        private readonly IGetNewsForSiteService _getNewsForSiteService;
        private readonly IGetTopNewsService _getTopNewsService;
        private readonly IGetOneTopNewsService _getOneTopNewsService;
        private readonly IGetNewsInSliderService _getNewsInSliderService;
        private readonly IGetNewsInNewsService _getNewsInNewsService;
        private readonly IGetNewsOfDayService _getNewsOfDayService;
        private readonly IGetPopularNewsService _getPopularNewsService1;
        public HomeController(ILogger<HomeController> logger, IGetCategoriesService getCategoriesService
            , IGetNewsForSiteService getNewsForSiteService,
            IGetTopNewsService getTopNewsService,
            IGetOneTopNewsService getOneTopNewsService,
            IGetNewsInSliderService getNewsInSliderService,
            IGetNewsInNewsService getNewsInNewsService,
            IGetNewsOfDayService getNewsOfDayService,
            IGetPopularNewsService getPopularNewsService)
        {
            _getPopularNewsService1 = getPopularNewsService;
            _getNewsOfDayService = getNewsOfDayService;
            _getNewsInNewsService = getNewsInNewsService;
            _getNewsInSliderService = getNewsInSliderService;
            _getOneTopNewsService = getOneTopNewsService;
            _getNewsForSiteService = getNewsForSiteService;
            _getCategoriesService = getCategoriesService;
            _logger = logger;
            _getTopNewsService = getTopNewsService;
        }

        public IActionResult Index()
        {

            return View(new HomePageViewModel
            {
                Categories = _getCategoriesService.Execute().Data,
                News = _getNewsForSiteService.Execute(null).Data,
                TopNews = _getTopNewsService.Execute().Data,
                OneTopNews =_getOneTopNewsService.Execute().Data
                ,ShowSlider=_getNewsInSliderService.Execute().Data,
                InstantNews=_getNewsInNewsService.Execute().Data,
                NewsOfDay=_getNewsOfDayService.Execute().Data,
                PopularNews=_getPopularNewsService1.Execute().Data
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

      
    }
}

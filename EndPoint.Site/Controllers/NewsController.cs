using EndPoint.Site.Models.ViewModels.SearchPageViewModel;
using EndPoint.Site.Utilities;
using Microsoft.AspNetCore.Mvc;
using MyCms.Application.Services.Category.Query.GetCategories;
using MyCms.Application.Services.News.Command.AddDisLike;
using MyCms.Application.Services.News.Command.AddLike;
using MyCms.Application.Services.News.Query.GetDetailNewsForSite;
using MyCms.Application.Services.News.Query.GetNewsForSite;
using MyCms.Application.Services.News.Query.GetNewsInNews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.Controllers
{

    public class NewsController : Controller
    {
      private readonly  IGetDetailNewsForSiteService _getDetailNewsForSiteService;
        private readonly IGetNewsForSiteService _getNewsForSiteService;
        private readonly IGetNewsInNewsService _getNewsInNewsService;
        private readonly IAddLikeService _addLikeService;
        private readonly IAddDisLikeService _addDisLikeService;

        public NewsController(IGetDetailNewsForSiteService getDetailNewsForSiteService,IGetNewsForSiteService getNewsForSiteService,
            IGetNewsInNewsService getNewsInNewsService,
            IAddLikeService addLikeService,
            IAddDisLikeService addDisLikeService)
        {
            _addDisLikeService = addDisLikeService;
            _addLikeService = addLikeService;
            _getNewsInNewsService = getNewsInNewsService;
            _getNewsForSiteService = getNewsForSiteService;
            _getDetailNewsForSiteService = getDetailNewsForSiteService;
        }
        public IActionResult Index()
        {
            NewsPageViewModel newsPageViewModel = new NewsPageViewModel { 
            InstantNews=_getNewsInNewsService.Execute().Data,
            News=_getNewsForSiteService.Execute(null).Data
            };
            return View(newsPageViewModel);
        }

        public IActionResult Detail(long ID)
        {
            ViewBag.UserID = ClaimUtility.GetUserId(User);
            return View(_getDetailNewsForSiteService.Execute(ID).Data);

        }

        public IActionResult Search(string SearchKey)
        {
            ViewBag.searchKey = SearchKey;
            NewsPageViewModel searchPageViewModel = new NewsPageViewModel() { 
            News=_getNewsForSiteService.Execute(SearchKey).Data,
            InstantNews=_getNewsInNewsService.Execute().Data
                        };
            return View(searchPageViewModel);
        }
        [HttpPost]
        public IActionResult AddLike(long newsID, long userID)
        {
            return Json(_addLikeService.Execute(new RequestAddLikeDto {NewsID=newsID,UserID=userID }));
        }

        [HttpPost]
        public IActionResult DisLike(long newsID, long userID)
        {
            return Json(_addDisLikeService.Execute(new RequestAddDisLikeDto { NewsID = newsID, UserID = userID }));
        }
    }
}

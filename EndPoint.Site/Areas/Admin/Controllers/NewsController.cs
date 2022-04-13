using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyCms.Application.Services.Category.Query.GetCategories;
using MyCms.Application.Services.News.Command.AddNews;
using MyCms.Application.Services.News.Command.ChangeStatusNews;
using MyCms.Application.Services.News.Command.DeleteNews;
using MyCms.Application.Services.News.Command.EditNews;
using MyCms.Application.Services.News.Command.ShowInNews;
using MyCms.Application.Services.News.Command.ShowNewsInSlider;
using MyCms.Application.Services.News.Query.GetDetailNewsForAdmin;
using MyCms.Application.Services.News.Query.GetNews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Operator")]
    public class NewsController : Controller
    {
      private readonly  IGetCategoriesService _getCategoriesService;
        private readonly IAddNewsService _addNewsService;
        private readonly IGetNewsService _getNewsService;
        private readonly IGetDetailNewsForAdminService _getNewsDetailForAdminService;
        private readonly IDeleteNewsService _deleteNewsService;
        private readonly IEditNewsService _editNewsService;
        private readonly IChangeStatusNewsService _changeStatusNewsService;
        private readonly IShowNewsInSliderService _showNewsInSlider;
        private readonly IShowInNewsService _showInNewsService;
        public NewsController(IAddNewsService addNewsService,IGetCategoriesService getCategoriesService,IGetNewsService getNewsService
            ,IGetDetailNewsForAdminService getDetailNewsForAdminService,
            IDeleteNewsService deleteNewsService,
            IEditNewsService editNewsService,
            IChangeStatusNewsService changeStatusNewsService,
            IShowNewsInSliderService showNewsInSlider,
            IShowInNewsService showInNewsService)
        {
            _showInNewsService = showInNewsService;
            _showNewsInSlider = showNewsInSlider;
            _changeStatusNewsService = changeStatusNewsService;
            _editNewsService = editNewsService;
            _deleteNewsService = deleteNewsService;
            _getNewsDetailForAdminService = getDetailNewsForAdminService;
            _getNewsService = getNewsService;
            _addNewsService = addNewsService;
            _getCategoriesService = getCategoriesService;
        }
        public IActionResult Index(string searchKey)
        {
            return View(_getNewsService.Execute(searchKey).Data);
        }
        [HttpGet]
        public IActionResult Add()
        {
            var categories = _getCategoriesService.Execute().Data;
            ViewBag.categories = new SelectList(categories,"ID","Name");
            return View();
        }
        [HttpPost]
        public IActionResult Add(string Title,string Text,string ShortDescription,long CatID ,List< IFormFile> Images,bool Displayed)
        {
            List<IFormFile> images = new List<IFormFile>();
            for (int i = 0; i < Request.Form.Files.Count; i++)
            {
                var file = Request.Form.Files[i];
                images.Add(file);
            }
            Images = images;
          
            return Json(_addNewsService.Execute(new RequestAddNews { CatID = CatID, Displayed = Displayed, Images = Images, ShortDescription = ShortDescription, Text = Text, Title = Title }));
        }

        public IActionResult Detail(long ID)
        {
            return View(_getNewsDetailForAdminService.Execute(ID).Data);
        }

        [HttpPost]
        public IActionResult Delete(long newsID)
        {
            return Json(_deleteNewsService.Execute(newsID));
        }

        [HttpGet]
        public IActionResult Edit(long ID)
        {
            var categories = _getCategoriesService.Execute().Data;
            ViewBag.categories = new SelectList(categories, "ID", "Name");
            return View(_getNewsDetailForAdminService.Execute(ID).Data);
        }
        [HttpPost]
        public IActionResult Edit(RequestEditNewsDto request)
        {
            List<IFormFile> images = new List<IFormFile>();
            for (int i = 0; i < Request.Form.Files.Count; i++)
            {
                var file = Request.Form.Files[i];
                images.Add(file);
            }
            request.Images = images;
            return Json(_editNewsService.Execute(new RequestEditNewsDto { CatID=request.CatID,DisPlayed=request.DisPlayed
           ,Images=request.Images,
            ShortDescription=request.ShortDescription,
            Text=request.Text,
            Title=request.Title,
            NewsID=request.NewsID
            }));
        }

        public IActionResult ChangeNewsStatus(long NewsID)
        {
            return Json(_changeStatusNewsService.Execute(NewsID));
        }
        public IActionResult ShowInSlider(long NewsID)
        {
            return Json(_showNewsInSlider.Execute(NewsID));
        }

        public IActionResult ShowInNews(long NewsID)
        {
            return Json(_showInNewsService.Execute(NewsID));
        }
    }
}

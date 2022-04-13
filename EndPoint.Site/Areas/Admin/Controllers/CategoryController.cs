using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCms.Application.Services.Category.Command.AddCategory;
using MyCms.Application.Services.Category.Command.DeleteCategory;
using MyCms.Application.Services.Category.Query.GetCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Operator")]
    public class CategoryController : Controller
    {
      private readonly  IGetCategoriesService _getCategoriesService;
        private readonly IAddCategoryService _addCategoryService;
        private readonly IDeleteCategoryService _deleteCategoryService;
        public CategoryController(IGetCategoriesService getCategoriesService,IAddCategoryService addCategoryService,IDeleteCategoryService deleteCategoryService)
        {
            _deleteCategoryService = deleteCategoryService;
            _addCategoryService = addCategoryService;
            _getCategoriesService = getCategoriesService;
        }
        public IActionResult Index()
        {
            return View(_getCategoriesService.Execute().Data);
        }

        [HttpPost]
        public IActionResult Add(string name)
        {
            return Json(_addCategoryService.Execute(new RequestCategoryDto { Name=name}));
        }

        [HttpPost]
        public IActionResult Delete(long catID)
        {
            return Json(_deleteCategoryService.Execute(catID));
        }
    }
}

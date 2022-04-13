using MyCms.Application.Interfaces;
using MyCms.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCms.Application.Services.Category.Command.AddCategory
{
   public interface IAddCategoryService
    {
        ResultDto Execute(RequestCategoryDto request);
    }

    public class AddCategoryService : IAddCategoryService
    {
        private readonly IDatabaseContext _context;
        public AddCategoryService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestCategoryDto request)
        {
            if (string.IsNullOrEmpty(request.Name))
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "نام دسته بندی را وارد نمایید",
                };
            }
            MyCms.Domain.Entities.Categories.Category category = new Domain.Entities.Categories.Category {
            CategoryName=request.Name,
            };
            _context.Categories.Add(category);
            _context.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true,
                Message = "دسته بندی اضافه شد" };
        }
    }

    public class RequestCategoryDto
    {
        public string Name { get; set; }
    }
}

using MyCms.Application.Interfaces;
using MyCms.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCms.Application.Services.Category.Command.DeleteCategory
{
  public  interface IDeleteCategoryService
    {
        ResultDto Execute(long catID);
    }

    public class DeleteCategoryService : IDeleteCategoryService
    {
        private readonly IDatabaseContext _context;
        public DeleteCategoryService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDto Execute(long catID)
        {
            var category = _context.Categories.Find(catID);
            if (category==null)
            {
                return new ResultDto { IsSuccess=false,Message="دسته بندی یافت نشد"};
            }
            category.IsRemoved = true;
            category.RemoveTime = DateTime.Now;
            _context.SaveChanges();
            return new ResultDto {
            IsSuccess=true,
            Message="دسته بندی با موفقیت حذف شد"
            };
        }
    }
}

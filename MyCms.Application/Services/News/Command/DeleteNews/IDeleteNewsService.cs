using Microsoft.EntityFrameworkCore;
using MyCms.Application.Interfaces;
using MyCms.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCms.Application.Services.News.Command.DeleteNews
{
  public  interface IDeleteNewsService
    {
        ResultDto Execute(long newsID);
    }
    public class DeleteNewsService : IDeleteNewsService
    {
        private readonly IDatabaseContext _context;
        public DeleteNewsService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(long newsID)
        {
            var news = _context.News.Find(newsID);
            var category = _context.Categories.Find(news.CategoryID);
            if (news==null)
            {
                return new ResultDto { 
                IsSuccess=false,
                Message="خبر یافت نشد"
                };
            }

            news.IsRemoved = true;
            news.RemoveTime = DateTime.Now;
            category.NewsCount--;
            _context.SaveChanges();

            return new ResultDto
            {
              Message="خبر با موفقیت حذف شد",
                IsSuccess = true,

            };

        }
    }


}

using MyCms.Application.Interfaces;
using MyCms.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCms.Application.Services.News.Command.ShowInNews
{
    public interface IShowInNewsService
    {
        ResultDto Execute(long ID);
    }
    public class ShowInNewsService : IShowInNewsService
    {
        private readonly IDatabaseContext _context;
        public ShowInNewsService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(long ID)
        {
            var news = _context.News.Find(ID);
            news.IsInNews = !news.IsInNews;
            _context.SaveChanges();
            if (news.DisPlayed == true&&news.IsInNews)
            {
                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "خبر در اخبار فوری نشان داده می شود"
                };

            }
            else
            {
                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "خبر در اخبار فوری نشان داده نمی شود"
                };
            }

        }
    }
}

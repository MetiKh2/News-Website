using MyCms.Application.Interfaces;
using MyCms.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCms.Application.Services.News.Command.ChangeStatusNews
{
    public interface IChangeStatusNewsService
    {
        ResultDto Execute(long ID);
    }

    public class ChangeStatusNewsService : IChangeStatusNewsService
    {
        private readonly IDatabaseContext _context;
        public ChangeStatusNewsService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(long ID)
        {
            var news = _context.News.Find(ID);
            news.DisPlayed = !news.DisPlayed;
            _context.SaveChanges();
            if (news.DisPlayed==true)
            {
                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "خبر نشان داده میشود"
                };

            }
            else
            {
                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "خبر نشان داده نمیشود"
                };
            }
          
        }
    }
}

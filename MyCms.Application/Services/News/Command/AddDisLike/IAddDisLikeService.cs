using MyCms.Application.Interfaces;
using MyCms.Common.Dto;
using MyCms.Domain.Entities.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCms.Application.Services.News.Command.AddDisLike
{
  public  interface IAddDisLikeService
    {


        ResultDto Execute(RequestAddDisLikeDto request);
    }

    public class AddDisLikeService : IAddDisLikeService
    {
        private readonly IDatabaseContext _context;
        public AddDisLikeService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDto Execute(RequestAddDisLikeDto request)
        {
            if (request.UserID == 0)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "برای لنظر دهی باید ثبت نام کنید"
                };
            }
            var newsLike = _context.NewsLikes.Where(p => p.NewsID == request.NewsID && p.UserID == request.UserID).FirstOrDefault();
           
            if (newsLike==null)
            {
                return new ResultDto { 
                IsSuccess=false,
                Message="شما هنوز لایک نکرده اید"
                };
            }
            var news = _context.News.Find(request.NewsID);
            news.LikeCount--;
            newsLike.IsRemoved = true;
     
            _context.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true,
                Message = "ثبت شد  . . ."
            };
        }
    }

    public class RequestAddDisLikeDto
    {
        public long NewsID { get; set; }
        public long UserID { get; set; }

    }
}


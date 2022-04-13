using MyCms.Application.Interfaces;
using MyCms.Common.Dto;
using MyCms.Domain.Entities.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCms.Application.Services.News.Command.AddLike
{
    public interface IAddLikeService
    {
        ResultDto Execute(RequestAddLikeDto request);
    }

    public class AddLikeService:IAddLikeService
    {
        private readonly IDatabaseContext _context;
        public AddLikeService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDto Execute(RequestAddLikeDto request)
        {
            if (request.UserID == 0)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "برای لایک کردن باید ثبت نام کنید"
                };
            }
            var news = _context.News.Find(request.NewsID);
            news.LikeCount++;
            var newsLike = _context.NewsLikes.Where(p => p.NewsID == request.NewsID && p.UserID == request.UserID).FirstOrDefault();
            if (newsLike!=null)
            {
                return new ResultDto { 
                IsSuccess=false,
                Message="شما قبلا این خبر را لایک  کرده اید ."
                };
            }
          
            NewsLikes newsLikes = new NewsLikes { 
           NewsID=request.NewsID,
           UserID=request.UserID
            };
            _context.NewsLikes.Add(newsLikes);
            _context.SaveChanges();
            return new ResultDto { 
            IsSuccess=true,
            Message="ممنون از مشارکتتان . . ."
            };
        }
    }

    public class RequestAddLikeDto
    {
        public long NewsID { get; set; }
        public long UserID { get; set; }

    }
}

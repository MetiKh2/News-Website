using MyCms.Application.Interfaces;
using MyCms.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCms.Application.Services.News.Query.GetPopularNews
{
  public  interface IGetPopularNewsService
    {
        ResultDto<List<GetPopularNewsDto>> Execute();
    }

    public class GetPopularNewsService : IGetPopularNewsService
    {
        private readonly IDatabaseContext _context;
        public GetPopularNewsService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<GetPopularNewsDto>> Execute()
        {
            var popularNews = _context.News.Where(p=>p.DisPlayed).OrderByDescending(p => p.LikeCount).ToList().Select(p => new GetPopularNewsDto
            {
                ID = p.ID,
                NewsLike = p.LikeCount,
                Ttitle = p.Title
            }).ToList();

            return new ResultDto<List<GetPopularNewsDto>> { 
            Data=popularNews,
            IsSuccess=true
            };
        }
    }

    public class GetPopularNewsDto
    {
        public long ID { get; set; }
        public long NewsLike { get; set; }
        public string Ttitle { get; set; }

    }
}

using MyCms.Application.Interfaces;
using MyCms.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCms.Application.Services.News.Query.GetNewsInNews
{
   public interface IGetNewsInNewsService
    {
        ResultDto<List<GetNewsInNewsDto>> Execute();
    }

    public class GetNewsInNewsService : IGetNewsInNewsService
    {
        private readonly IDatabaseContext _context;
        public GetNewsInNewsService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<GetNewsInNewsDto>> Execute()
        {
            var news = _context.News.Where(p => p.DisPlayed == true && p.IsInNews).ToList().Select(p => new GetNewsInNewsDto { 
           ID=p.ID,
           Title=p.Title
            }).ToList();

            return new ResultDto<List<GetNewsInNewsDto>> { 
            Data=news,
            IsSuccess=true
            };
        }
    }

    public class GetNewsInNewsDto
    {
        public long ID { get; set; }
        public string Title { get; set; }
    }
}

using MyCms.Application.Interfaces;
using MyCms.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCms.Application.Services.News.Query.GetTopNews
{
    public interface IGetTopNewsService
    {
        ResultDto<List<GetTopNewsDto>> Execute();
    }

    public class GetTopNewsService : IGetTopNewsService
    {
        private readonly IDatabaseContext _context;
        public GetTopNewsService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<GetTopNewsDto>> Execute()
        {
            var topNews = _context.News.Where(p=>p.DisPlayed==true).ToList().OrderByDescending(x => x.ViewCount).Select(p => new GetTopNewsDto
            {
                CatID = p.CategoryID,
                NewsID = p.ID,
                Title = p.Title
               ,
                CreateDate = p.InsertTime
               ,
                Category = p.Category.CategoryName
            }).Skip(1).ToList();

            return new ResultDto<List<GetTopNewsDto>> { Data=topNews
           ,IsSuccess=true};
        }
    }

    public class GetTopNewsDto
    {
        public long NewsID { get; set; }
        public string Title { get; set; }
        public long CatID { get; set; }
        public DateTime CreateDate { get; set; }
        public string Category { get; set; }
    }
}

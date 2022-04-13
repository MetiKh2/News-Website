using Microsoft.EntityFrameworkCore;
using MyCms.Application.Interfaces;
using MyCms.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCms.Application.Services.News.Query.GetNewsOfDay
{
   public interface IGetNewsOfDayService
    {
        ResultDto<List<GetNewsOfDayDto>> Execute();
    }


    public class GetNewsOfDayService : IGetNewsOfDayService
    {
        private readonly IDatabaseContext _context;
        public GetNewsOfDayService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<GetNewsOfDayDto>> Execute()
        {
            var news = _context.News.Include(p => p.NewsImages).Include(p => p.Category).Where(p => p.InsertTime.Day == DateTime.Now.Day&&p.DisPlayed).ToList().OrderByDescending(p=>p.ID)
                .Select(
                p => new GetNewsOfDayDto { 
                ID=p.ID,
                Category=p.Category.CategoryName,
                CatID=p.CategoryID,
                Src=p.NewsImages.FirstOrDefault().Src,
                Title=p.Title
                }
                ).ToList();

            return new ResultDto<List<GetNewsOfDayDto>> { 
            Data=news,
            IsSuccess=true
            };
        }
    }

    public class GetNewsOfDayDto
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public string Src { get; set; }
        public long CatID { get; set; }
        public string Category { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using MyCms.Application.Interfaces;
using MyCms.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyCms.Application.Services.News.Query.GetNews.GetNewsService;

namespace MyCms.Application.Services.News.Query.GetNews
{
    public interface IGetNewsService
    {
        ResultDto<List<GetNewsDto>> Execute(string searchKey);
    }
   public class GetNewsService:IGetNewsService
    {
        private readonly IDatabaseContext _context;
        public GetNewsService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<GetNewsDto>> Execute(string searchKey)
        {
            var news = _context.News.Include(p => p.Category).AsQueryable();
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                news = news.Where(p => p.ID.ToString() == searchKey || p.Title.ToLower().Contains(searchKey)).AsQueryable();

            }





            return new ResultDto<List<GetNewsDto>>
            {

                Data = news.Select(p => new GetNewsDto
                {
                    ID = p.ID,
                    Title = p.Title,
                    CatName = p.Category.CategoryName,
                    DisPlayed = p.DisPlayed,
                    IsSlider = p.IsSlider,
                    IsInNews = p.IsInNews
                }).OrderByDescending(p=>p.ID).ToList()
            ,
                IsSuccess = true
            };
        }
    }

    public class GetNewsDto
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public string CatName { get; set; }
        public bool DisPlayed { get; set; }
        public bool IsSlider { get; set; }
        public bool IsInNews { get; set; }
    }
}

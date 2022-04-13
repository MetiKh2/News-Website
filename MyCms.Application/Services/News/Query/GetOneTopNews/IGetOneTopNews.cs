using Microsoft.EntityFrameworkCore;
using MyCms.Application.Interfaces;
using MyCms.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCms.Application.Services.News.Query.GetOneTopNews
{
    public interface IGetOneTopNewsService
    {
        ResultDto<GetOneTopNewsDto> Execute();
    }

    public class GetOneTopNewsService : IGetOneTopNewsService
    {
        private readonly IDatabaseContext _context;
        public GetOneTopNewsService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDto<GetOneTopNewsDto> Execute()
        {
            var topNews = _context.News.Include(p=>p.NewsImages).Where(p=>p.DisPlayed==true).OrderByDescending(x => x.ViewCount).Select(p => new GetOneTopNewsDto
            {
                CatID = p.CategoryID,
                NewsID = p.ID,
                Title = p.Title
               ,
                CreateDate = p.InsertTime
               ,
                Category = p.Category.CategoryName
                ,Src=p.NewsImages.FirstOrDefault().Src
                ,ShortDescription=p.ShortDescription
            }).FirstOrDefault();

            return new ResultDto<GetOneTopNewsDto>
            {
                Data = topNews
           ,
                IsSuccess = true
            };
        }
    }

    public class GetOneTopNewsDto
    {
        public long NewsID { get; set; }
        public string Title { get; set; }
        public long CatID { get; set; }
        public DateTime CreateDate { get; set; }
        public string Category { get; set; }
        public string Src { get; set; }
        public string ShortDescription { get; set; }
    }
}


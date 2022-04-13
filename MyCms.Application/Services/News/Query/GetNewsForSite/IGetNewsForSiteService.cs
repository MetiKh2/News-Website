using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MyCms.Application.Interfaces;
using MyCms.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyCms.Application.Services.News.Query.GetNewsForSite.GetNewsForSiteService;

namespace MyCms.Application.Services.News.Query.GetNewsForSite
{
    public interface IGetNewsForSiteService
    {
        ResultDto<List<NewsForSiteDto>> Execute(string searchKey);
    }


    public class GetNewsForSiteService : IGetNewsForSiteService
    {
        private readonly IDatabaseContext _context;
        public GetNewsForSiteService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<NewsForSiteDto>> Execute(string searchKey)
        {
            var News = _context.News.Include(p => p.NewsImages).AsQueryable();
            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                News = News.Where(p => p.DisPlayed && p.ShortDescription.ToLower().Contains(searchKey) ||
                p.Title.ToLower().Contains(searchKey) ||
               p.ID.ToString() == searchKey).AsQueryable();
            }


            return new ResultDto<List<NewsForSiteDto>>
            {
                Data = News.Select(p => new NewsForSiteDto { Category=p.Category.CategoryName,
                CatID=p.CategoryID,
                CreateDate=p.InsertTime,
                NewsID=p.ID,
                ShortDescription=p.ShortDescription,
                Src=p.NewsImages.FirstOrDefault().Src,
                Title=p.Title
                }).OrderByDescending(p=>p.NewsID).ToList()
                ,IsSuccess=true
            };


        }

        public class NewsForSiteDto
        {
            public long NewsID { get; set; }
            public string Title { get; set; }
            public string ShortDescription { get; set; }
            public string Src { get; set; }
            public long CatID { get; set; }
            public DateTime CreateDate { get; set; }
            public string Category { get; set; }

        }
        //public class ResultGetNewsForSiteDto
        //{
        //    public List<NewsForSiteDto> News { get; set; }
        //    // public int TotalRow { get; set; }
        //}
    }
}

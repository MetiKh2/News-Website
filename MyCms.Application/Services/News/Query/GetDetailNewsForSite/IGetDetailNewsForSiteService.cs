using Microsoft.EntityFrameworkCore;
using MyCms.Application.Interfaces;
using MyCms.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCms.Application.Services.News.Query.GetDetailNewsForSite
{
    public interface IGetDetailNewsForSiteService
    {
        ResultDto<GetDetailNewsForSiteDto> Execute(long ID);
    }

    public class GetDetailNewsForSiteService : IGetDetailNewsForSiteService
    {
        private readonly IDatabaseContext _context;
        public GetDetailNewsForSiteService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto<GetDetailNewsForSiteDto> Execute(long ID)
        {
            var news = _context.News.Include(p=>p.Category).Include(p => p.NewsImages).Where(p => p.ID == ID).FirstOrDefault();
            news.ViewCount++;
            _context.SaveChanges();

            return new ResultDto<GetDetailNewsForSiteDto>
            {
                Data = new GetDetailNewsForSiteDto
                {
                    CatID = news.CategoryID,
                    Category = news.Category.CategoryName,
                    CreateDate = news.InsertTime,
                    NewsID = news.ID,
                    ShortDescription = news.ShortDescription,
                    Text = news.Text,
                    Title = news.Title,
                    Images = news.NewsImages.Select(p => p.Src).ToList(),
                    LikeCount=news.LikeCount
                }
               ,IsSuccess=true

            };

        }
    }



    public class GetDetailNewsForSiteDto
    {
        public long NewsID { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public List<string> Images { get; set; }
        public long CatID { get; set; }
        public DateTime CreateDate { get; set; }
        public string Category { get; set; }
        public string Text { get; set; }
        public long LikeCount { get; set; }

    }

}

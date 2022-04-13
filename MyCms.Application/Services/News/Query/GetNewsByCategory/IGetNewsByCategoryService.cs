using Microsoft.EntityFrameworkCore;
using MyCms.Application.Interfaces;
using MyCms.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCms.Application.Services.News.Query.GetNewsByCategory
{
   public interface IGetNewsByCategoryService
    {
        ResultDto<List<GetNewsByCategoryDto>> Execute(long CatID);
    }

    public class GetNewsByCategoryService : IGetNewsByCategoryService
    {
        private readonly IDatabaseContext _context;
        public GetNewsByCategoryService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<GetNewsByCategoryDto>> Execute(long CatID)
        {
            var news = _context.News.Include(p=>p.NewsImages).Include(p=>p.Category).Where(p => p.CategoryID == CatID).ToList().OrderByDescending(p=>p.ID).Select(p => new GetNewsByCategoryDto
            {
                CatID = CatID,
                Category = p.Category.CategoryName,
                CreateDate = p.InsertTime,
                NewsID = p.ID,
                ShortDescription = p.ShortDescription,
                Src = p.NewsImages.FirstOrDefault().Src,
                Title = p.Title
            }).ToList();

            return new ResultDto<List<GetNewsByCategoryDto>> { 
            Data=news,
            IsSuccess=true
            };
        }
    }

    public class GetNewsByCategoryDto
    {
        public long NewsID { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Src { get; set; }
        public long CatID { get; set; }
        public DateTime CreateDate { get; set; }
        public string Category { get; set; }
    }
}

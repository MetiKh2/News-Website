using MyCms.Application.Interfaces;
using MyCms.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;

namespace MyCms.Application.Services.News.Query.GetDetailNewsForAdmin
{
   public interface IGetDetailNewsForAdminService
    {
        ResultDto<GetDetailNewsForAdminDto> Execute(long ID);
    }

    public class GetDetailNewsForAdminService : IGetDetailNewsForAdminService
    {
        private readonly IDatabaseContext _context;
        public GetDetailNewsForAdminService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto<GetDetailNewsForAdminDto> Execute(long ID)
        {

            var detailNews = _context.News.Include(p => p.Category).Where(p => p.ID == ID).Select(p => new GetDetailNewsForAdminDto
            {
                ID=p.ID,
                CatID = p.CategoryID,
                CatName = p.Category.CategoryName
                   ,
                DisPlayed = p.DisPlayed,
                ShortDescription = p.ShortDescription,
                Text = p.Text,
                Title = p.Title,
                ViewCount = p.ViewCount
            }).FirstOrDefault();

            return new ResultDto<GetDetailNewsForAdminDto> { 
            Data=detailNews,
            IsSuccess=true,
            
            };
               
        }
    }

    public class GetDetailNewsForAdminDto
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Text { get; set; }
        public bool DisPlayed { get; set; }
        public long ViewCount { get; set; }
        public long CatID { get; set; }
        public string CatName { get; set; }
    }
}

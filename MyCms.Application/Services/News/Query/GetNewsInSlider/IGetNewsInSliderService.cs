using Microsoft.EntityFrameworkCore;
using MyCms.Application.Interfaces;
using MyCms.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCms.Application.Services.News.Query.GetNewsInSlider
{
    public interface IGetNewsInSliderService
    {
        ResultDto<List<GetNewsInSliderDto>> Execute();
    }

    public class GetNewsInSliderService : IGetNewsInSliderService
    {
        private readonly IDatabaseContext _context;
        public GetNewsInSliderService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<GetNewsInSliderDto>> Execute()
        {
            var news = _context.News.Include(p => p.NewsImages).Where(p => p.IsSlider == true && p.DisPlayed == true).ToList().Select(p => new GetNewsInSliderDto
            {
                CreateDate = p.InsertTime,
                ID = p.ID,
                ShortDescription = p.ShortDescription,
                Title = p.Title
                ,Src=p.NewsImages.FirstOrDefault().Src
            }).ToList();

            return new ResultDto<List<GetNewsInSliderDto>> { 
            Data=news,
             IsSuccess=true
            };
        }
    }

    public class GetNewsInSliderDto
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public DateTime CreateDate { get; set; }
        public string Src { get; set; }

    }
}

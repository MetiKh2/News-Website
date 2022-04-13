using MyCms.Application.Interfaces;
using MyCms.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCms.Application.Services.News.Command.ShowNewsInSlider
{
  public  interface IShowNewsInSliderService
    {
        ResultDto Execute(long ID);
    }
    public class ShowNewsInSliderService : IShowNewsInSliderService
    {
        private readonly IDatabaseContext _context;
        public ShowNewsInSliderService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(long ID)
        {
            var news = _context.News.Find(ID);
            news.IsSlider = !news.IsSlider;
            _context.SaveChanges();
            if (news.DisPlayed == true&&news.IsSlider)
            {
                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "خبر در اسلایدر نشان داده میشود"
                };

            }
            else
            {
                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "خبر در اسلایدر نشان داده نمیشود"
                };
            }

        }
    }

}

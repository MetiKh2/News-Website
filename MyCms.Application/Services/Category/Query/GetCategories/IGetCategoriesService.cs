using MyCms.Application.Interfaces;
using MyCms.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCms.Application.Services.Category.Query.GetCategories
{
   public interface IGetCategoriesService
    {
        ResultDto<List<GetCategoriesDto>> Execute();
    }

    public class GetCategoriesService:IGetCategoriesService
    {
        private readonly IDatabaseContext _context;
        public GetCategoriesService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<GetCategoriesDto>> Execute()
        {
            var categories = _context.Categories.ToList().Select(p => new GetCategoriesDto { Name = p.CategoryName,ID=p.ID,NewsCount=p.NewsCount }).ToList();

            return new ResultDto<List<GetCategoriesDto>> { 
            Data=categories,
            IsSuccess=true
            };
        }
    }

    public class GetCategoriesDto
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public long NewsCount { get; set; }
    }
}

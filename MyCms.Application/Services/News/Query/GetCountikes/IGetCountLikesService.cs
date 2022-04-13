using MyCms.Application.Interfaces;
using MyCms.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCms.Application.Services.News.Query.GetCountikes
{
    public interface IGetCountLikesService
    {
        ResultDto<GetCountLikesDto> Execute(RequestGetCountLikesDto request);
    }

    public class GetCountLikesService : IGetCountLikesService
    {
        private readonly IDatabaseContext _context;
        public GetCountLikesService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto<GetCountLikesDto> Execute(RequestGetCountLikesDto request)
        {
            var news = _context.News.Where(p=>p.ID==request.NewsID).Select(p=>new GetCountLikesDto { 
            Count=p.LikeCount
            }).FirstOrDefault();
            
            return new ResultDto<GetCountLikesDto> {
            Data=news,
            IsSuccess=true
            };
        }
    }

    public class GetCountLikesDto
    {
        public long Count { get; set; }
    }

    public class RequestGetCountLikesDto
    {
        public long NewsID { get; set; }
    }

}

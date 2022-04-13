using MyCms.Application.Interfaces;
using MyCms.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCms.Application.Services.Roles.Query.GetRoles
{
    public interface IGetRolesService
    {
        ResultDto<List<GetRolesDto>> Execute();
    }

    public class GetRolesService : IGetRolesService
    {
        private readonly IDatabaseContext _context;
        public GetRolesService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<GetRolesDto>> Execute()
        {
            var roles = _context.Roles.ToList().Select(p => new GetRolesDto
            {
                ID = p.ID,
                Role = p.Role
            }).ToList();

            return new ResultDto<List<GetRolesDto>> 
            {
            Data=roles,
            IsSuccess=true
            };
        }
    }

    public class GetRolesDto
    {
        public long ID { get; set; }
        public string Role { get; set; }
    }

}

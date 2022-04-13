using MyCms.Application.Interfaces;
using MyCms.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCms.Application.Services.User.Query.GetUsersInRole
{
    public interface IGetUsersInRoleService
    {
        ResultDto<List<UserInRoleDto>> Execute(long RoleID);
    }

    public class GetUsersInRoleService : IGetUsersInRoleService
    {
        private readonly IDatabaseContext _context;
        public GetUsersInRoleService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<UserInRoleDto>> Execute(long RoleID)
        {
            var result = _context.UserInRoles.Where(p => p.RoleID == RoleID).Select(p => new UserInRoleDto
            {
                User = p.User,
                UserID = p.UserID
            }).ToList();


            return new ResultDto<List<UserInRoleDto>>
            {
                Data = result,
                IsSuccess = true
            };
        }
    }

    public class UserInRoleDto
    {
        public MyCms.Domain.Entities.Users.User User { get; set; }
        public long UserID { get; set; }


    }
}

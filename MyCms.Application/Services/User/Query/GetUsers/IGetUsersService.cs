using Microsoft.EntityFrameworkCore;
using MyCms.Application.Interfaces;
using MyCms.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCms.Application.Services.User.Query.GetUsers
{
    public interface IGetUsersService
    {
        ResultDto<List<GetUsersDto>> Execute(RequestGetUsers request);
    }

    public class GetUsersService : IGetUsersService
    {
        private readonly IDatabaseContext _context;
        public GetUsersService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<GetUsersDto>> Execute(RequestGetUsers request)
        {
            var users = _context.Users.AsQueryable();
         //   var roles = _context.UserInRoles.Where(p => p.RoleID == request.RoleID).FirstOrDefault();
            if (!string.IsNullOrWhiteSpace(request.SearchKey))
            {

               users= users.Where(p => p.FullName.Contains(request.SearchKey) || p.Mobile.Contains(request.SearchKey) || p.Email.Contains(request.SearchKey)).AsQueryable();
            }
            
            var UserList = users.ToList().Select(u => new GetUsersDto
            {
                ID = u.ID,
                FullName = u.FullName,
                Mobile = u.Mobile,
                Password = u.Password,
                Email = u.Email,
                IsActive = u.IsActive,
              // RoleID=roles.RoleID,


            }).ToList();
            return new ResultDto<List<GetUsersDto>>
            {
                Data = UserList,
                IsSuccess=true
             
            };

        }
    }

    public class GetUsersDto
    {
        public long ID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
       // public long RoleID { get; set; }
    }


    public class RequestGetUsers
    {
       // public long RoleID { get; set; }
        public string SearchKey { get; set; }
    }
}

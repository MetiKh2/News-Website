using MyCms.Application.Interfaces;
using MyCms.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCms.Application.Services.User.Command.RemoveUser
{
   public interface IRemoveUserService
    {
        ResultDto Execute(RequestRemoveUserDto request);
    }
    public class RemoveUserService:IRemoveUserService
    {
        private readonly IDatabaseContext _context;
        public RemoveUserService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDto Execute(RequestRemoveUserDto request)
        {
            var user = _context.Users.Find(request.UserID);
            if (user==null)
            {
                return new ResultDto {
                IsSuccess=false,
                Message="کاربر یافت نشد"};
            }
            user.IsRemoved = true;
            user.RemoveTime = DateTime.Now;
            _context.SaveChanges();
            return new ResultDto { IsSuccess=true,Message="کاربر حذف شد"};
        }
    }
    public class RequestRemoveUserDto
    {
        public long UserID { get; set; }
    }
}

using MyCms.Application.Interfaces;
using MyCms.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCms.Application.Services.User.Command.ChangeUserStatus
{
   public interface IChangeUserStatusService
    {
        ResultDto Execute(long userID);
    }

    public class ChangeUserStatusService:IChangeUserStatusService
    {
        private readonly IDatabaseContext _context;
        public ChangeUserStatusService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDto Execute(long userID)
        {
            var user = _context.Users.Find(userID);
            if (user==null)
            {
                return new ResultDto { IsSuccess=false,Message="کاربر یافت نشد"};
            }
            user.IsActive = !user.IsActive;
            _context.SaveChanges();
            if (user.IsActive)
            {
                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "کاربر با موفقیت فعال شد"
                };
            }
            else
            {
                _context.SaveChanges();
                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "کاربر با موفقیت غیرفعال شد"
                };
            }
        }
    }


}

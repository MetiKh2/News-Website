using Microsoft.EntityFrameworkCore;
using MyCms.Application.Interfaces;
using MyCms.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCms.Application.Services.User.Query.UserLogin
{
   public interface IUserLoginService
    {
        ResultDto<UserLoginDto> Execute(string password,string email);
    }

    public class UserLoginService : IUserLoginService
    {
        private readonly IDatabaseContext _context;
        public UserLoginService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto<UserLoginDto> Execute(string password, string email)
        {
            if (string.IsNullOrWhiteSpace(password)||string.IsNullOrWhiteSpace(email))
            {
                return new ResultDto<UserLoginDto> {
                Data=new UserLoginDto { },
                IsSuccess=false
               ,Message="نام کاربری و رمز عبور را وارد کنید!"
                };
            }

            var user = _context.Users.Include(p => p.UserInRoles).ThenInclude(p => p.Role).Where(p => p.Email.Equals(email) && p.IsActive == true && p.IsRemoved == false).FirstOrDefault();
            if (user == null)
            {
                return new ResultDto<UserLoginDto> { 
                Data=new UserLoginDto { },
                IsSuccess=false,
                Message="کاربری با این مشخصات در سایت ثبت نام نکرده است"
                };
            }
            MyCms.Common.PasswordHasher PasswordHasher = new Common.PasswordHasher();
            bool verifyPassword = PasswordHasher.VerifyPassword(user.Password,password);
            if (!verifyPassword)
            {
                return new ResultDto<UserLoginDto> { 
                Data=new UserLoginDto { },
                IsSuccess=false,
                Message="رمز عبور اشتباه است"
                };
            }

            string roles = "";
            foreach (var item in user.UserInRoles)
            {
                roles += $"{item.Role.Role}";
            }

            return new ResultDto<UserLoginDto> {
                Data = new UserLoginDto { 
                Role=roles,
                Name=user.FullName,
                UserID=user.ID
                },
                 IsSuccess=true,
                 Message="تبریک با موفقیت وارد شدید"
            };
        }
    }

    public class UserLoginDto
    {
        public long UserID { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
    }
}

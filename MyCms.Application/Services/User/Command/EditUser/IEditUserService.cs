using MyCms.Application.Interfaces;
using MyCms.Common;
using MyCms.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCms.Application.Services.User.Command.EditUser
{
    public interface IEditUserService
    {
        ResultDto Execute(RequestEditUserDto request);
    }

    public class EditUserService : IEditUserService
    {
        private readonly IDatabaseContext _context;
        public EditUserService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestEditUserDto request)
        {
            var user = _context.Users.Find(request.ID);
            if (user==null)
            {
                return new ResultDto { IsSuccess=false,Message="کاربر یافت نشد"};
            }
            user.FullName = request.FullName;
            user.Email = request.Email;
            user.UpdateTime = DateTime.Now;
            user.Mobile = request.Mobile;

            PasswordHasher passwordHasher = new PasswordHasher();
            var Password = passwordHasher.HashPassword(request.Password);
            user.Password = Password;
            _context.SaveChanges();
            return new ResultDto { IsSuccess=true,Message="ویرایش کاربر انجام شد"};
            
        }
    }
    public class RequestEditUserDto
    {
        public long ID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
    }




}

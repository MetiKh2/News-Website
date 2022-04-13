using MyCms.Application.Interfaces;
using MyCms.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCms.Domain.Entities.Users;
using MyCms.Common;

namespace MyCms.Application.Services.User.Command.AddNewUser
{
   public interface IAddNewUserService
    {
        ResultDto<AddUserDto> Execute(RequestAddUserDto request);
    }

    public class AddNewUserService : IAddNewUserService
    {
      private readonly  IDatabaseContext _context;
        public AddNewUserService(IDatabaseContext context)
        {
            _context = context;
        }

        public ResultDto<AddUserDto> Execute(RequestAddUserDto request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.FullName))
                {
                    return new ResultDto<AddUserDto> {IsSuccess=false,Message="نام خود را کامل وارد کنید",Data=new AddUserDto { UserID=0} };
                }
                if (string.IsNullOrWhiteSpace(request.Email))
                {
                    return new ResultDto<AddUserDto> { IsSuccess = false, Message = "ایمیل خود را کامل وارد کنید", Data = new AddUserDto { UserID = 0 } };
                }
                if (string.IsNullOrWhiteSpace(request.Mobile))
                {
                    return new ResultDto<AddUserDto> { IsSuccess = false, Message = "موبایل خود را کامل وارد کنید", Data = new AddUserDto { UserID = 0 } };
                }
                if (string.IsNullOrWhiteSpace(request.Password))
                {
                    return new ResultDto<AddUserDto> { IsSuccess = false, Message = "رمز خود را  وارد کنید", Data = new AddUserDto { UserID = 0 } };
                }
                if (string.IsNullOrWhiteSpace(request.RePassword))
                {
                    return new ResultDto<AddUserDto> { IsSuccess = false, Message = "رمز خود را تکرار  کنید", Data = new AddUserDto { UserID = 0 } };
                }
                if (request.Password!=request.RePassword)
                {
                    return new ResultDto<AddUserDto> { IsSuccess = false, Message = "رمز ها یکسان نیستند", Data = new AddUserDto { UserID = 0 } };
                }
                PasswordHasher passwordHasher = new PasswordHasher();
                var resultPassword = passwordHasher.HashPassword(request.Password);
                MyCms.Domain.Entities.Users.User User = new Domain.Entities.Users.User 
                {
                FullName=request.FullName,
                IsActive=true,
                Email=request.Email,
                 Mobile=request.Mobile,
                 Password=resultPassword,
                //RoleID=request.RoleID
                };

                List<UserInRoles> userInRoles = new List<UserInRoles>();
                foreach (var item in request.Roles)
                {
                    var roles = _context.Roles.Find(item.ID);
                    _context.UserInRoles.Add(new UserInRoles { Role = roles, User = User, RoleID = roles.ID, UserID = User.ID, });
                }
                _context.SaveChanges();
                return new ResultDto<AddUserDto>
                {
                    Data=new AddUserDto { UserID=User.ID},
                    IsSuccess = true,
                    Message = "کاربر با موفقیت افزوده شد"
                };
            }
            catch (Exception)
            {

                return new ResultDto<AddUserDto>()
                {
                    Data=new AddUserDto { UserID=0},
                    IsSuccess = false,
                   
                    Message = "ثبت نام انجام نشد",
                };
            }
        }
    }

    public class RequestAddUserDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public bool IsActive { get; set; }
     //   public long RoleID { get; set; }
        public List<RolesInCreateUserDto> Roles { get; set; }

    }

    public class AddUserDto
    {
        public long UserID { get; set; }
    }

    public class RolesInCreateUserDto
    {
        public long ID { get; set; }
    }
}

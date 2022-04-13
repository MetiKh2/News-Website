using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyCms.Application.Services.Roles.Query.GetRoles;
using MyCms.Application.Services.User.Command.AddNewUser;
using MyCms.Application.Services.User.Command.ChangeUserStatus;
using MyCms.Application.Services.User.Command.EditUser;
using MyCms.Application.Services.User.Command.RemoveUser;
using MyCms.Application.Services.User.Query.GetUsers;
using MyCms.Application.Services.User.Query.GetUsersInRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Operator")]
    public class UserController : Controller
    {
        private readonly IGetRolesService _getRolesService;
        private readonly IAddNewUserService _addNewUserService;
        private readonly IGetUsersService _getUsersService;
        private readonly IGetUsersInRoleService _getUsersInRoleService;
        private readonly IEditUserService _editUserService;
        private readonly IRemoveUserService _removeUserService;
        private readonly IChangeUserStatusService _changeUserStatusService;
        public UserController(IGetRolesService getRolesService, IAddNewUserService addNewUserService, IGetUsersService getUsersService,
            IGetUsersInRoleService getUsersInRoleService,
            IEditUserService editUserService,
            IRemoveUserService removeUserService,
            IChangeUserStatusService changeUserStatusService)
        {
            _changeUserStatusService = changeUserStatusService;
            _removeUserService = removeUserService;
               _editUserService = editUserService;
            _getUsersInRoleService = getUsersInRoleService;
            _getUsersService = getUsersService;
            _getRolesService = getRolesService;
            _addNewUserService = addNewUserService;
        }
        public IActionResult Index(string searchKey)
        {
            return View(_getUsersService.Execute(new RequestGetUsers { SearchKey = searchKey }).Data);
        }
        public IActionResult GetUsers(long ID)
        {
            return View(_getUsersInRoleService.Execute(ID).Data);
        }
        [HttpGet]
        public IActionResult Add()
        {
            var roles = _getRolesService.Execute().Data;
            ViewBag.Roles = new SelectList(roles, "ID", "Role");
            return View();
        }

        [HttpPost]
        public IActionResult Add(string fullname, string email, string mobile, string Password, string RePassword, long RoleID)
        {
            return Json(_addNewUserService.Execute(new RequestAddUserDto
            {
                Email = email,
                FullName = fullname,
                IsActive = true,
                Mobile = mobile,
                Password = Password,
                RePassword = RePassword,
                Roles = new List<RolesInCreateUserDto> {
                new RolesInCreateUserDto{
                ID=RoleID} }
            }));
        }

        [HttpPost]
        public IActionResult Edit(long userID, string fullName, string email, string mobile, string password)
        {
            return Json(_editUserService.Execute(new RequestEditUserDto { ID = userID,
                Email = email,
                FullName = fullName,
                Mobile = mobile,
                Password = password
            }));
        }
        [HttpPost]
        public IActionResult Delete(long UserID)
        {
            return Json(_removeUserService.Execute(new RequestRemoveUserDto { UserID=UserID}));
        }

        [HttpPost]
        public IActionResult ChangeUserStatus(long UserID)
        {
            return Json(_changeUserStatusService.Execute(UserID));
        }
    }
}

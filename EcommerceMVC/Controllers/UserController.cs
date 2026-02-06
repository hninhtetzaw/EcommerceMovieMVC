using AspNetCoreGeneratedDocument;
using EcommerceMVC.Interfaces.IServices;
using EcommerceMVC.Models;
using EcommerceMVC.Models.CombinedViewDto;
using EcommerceMVC.Models.UserDtos;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceMVC.Controllers
{
    public class UserController:Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public UserController(IUserService service, IRoleService roleService)
        {
            _userService = service;     
            _roleService = roleService;
        }


        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            //return Ok(users);
            return View(users);
        }

        //old edit user without dropdown usertype
        //[HttpGet]
        //public IActionResult EditUser(string id)
        //{
        //    var user = _userService.GetUserById(id);

        //    var updateDto = new UpdateUserDto
        //    {
        //        Id = user.Data.Id,
        //        UserName = user.Data.UserName,
        //        Email = user.Data.Email,
        //        Role = user.Data.Role
        //        //Password = user.Data.Password
        //    };

        //    var response = new ApiResponseModel<UpdateUserDto>
        //    {
        //        success = true,
        //        Data = updateDto
        //    };

        //    //return Ok(users);
        //    return View(response);
        //}

        [HttpGet]
        public IActionResult EditUser(string id)
        {
            var response = new ApiResponseModel<UpdateUserViewDto>();
            var user = _userService.GetUserById(id);

            var updateUserDto = new UpdateUserDto
            {
                Id = user.Data.Id,
                UserName = user.Data.UserName,
                Email = user.Data.Email,
                RoleId = user.Data.RoleId
                //Password = user.Data.Password
            };
            var roleLists = _roleService.GetRoles();

            var combinedDto = new UpdateUserViewDto 
            { 
                UpdateUserDto = updateUserDto,
                RoleLists = roleLists.Data
            };


            response = new ApiResponseModel<UpdateUserViewDto>
            { 
                Data = combinedDto                 
            };


            //return Ok(users);
            return View(response);
        }
       
        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(RequestNewUserDto newUser)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var user = _userService.CreateUser(newUser);

            if (user is null)
            {
                return View();
            }
            //return Ok(user);
            return RedirectToAction("UserCreateView");
        }

        //for view only
        [HttpGet]
        public IActionResult UserCreateView()
        {
            return View();
        }
        //old
        //[HttpPost]
        //public IActionResult UpdateUser(string id, [Bind(Prefix = "Data")]  UpdateUserDto user)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View();
        //    }
        //    var updatedUser = _userService.UpdateUser(id, user);
        //    return RedirectToAction("UserUpdateView");
        //}

        [HttpPost]
        public IActionResult UpdateUser(string id, [Bind(Prefix = "Data")] UpdateUserViewDto request)
        {
            var user = request.UpdateUserDto;
            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}

            var updatedUser = _userService.UpdateUser(id, user);
            return RedirectToAction("UserUpdateView");
        }

        [HttpGet]
        public IActionResult UserUpdateView()
        {
            return View();
        }


    }
}

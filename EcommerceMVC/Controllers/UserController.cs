using AspNetCoreGeneratedDocument;
using EcommerceMVC.Interfaces.IServices;
using EcommerceMVC.Models.UserDtos;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceMVC.Controllers
{
    public class UserController:Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService service)
        {
            _userService = service;            
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            //return Ok(users);
            return View(users);
        }

        [HttpGet]
        public IActionResult EditUser(string id)
        {
            var user = _userService.GetUserById(id);
            //return Ok(users);
            return View(user);
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateUser(string id, UpdateUserDto user)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var updatedUser = _userService.UpdateUser(id, user);
            return RedirectToAction("UserUpdateView");
        }
        [HttpPost]
        public IActionResult CreateUser(RequestNewUserDto newUser)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var user = _userService.CreateUser(newUser);

            if(user is null)
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

        [HttpGet]
        public IActionResult UserUpdateView()
        {
            return View();
        }


    }
}

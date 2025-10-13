using EcommerceMVC.Interfaces.IServices;
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
            return Ok(users);   
        }
    }
}

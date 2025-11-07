using System.IdentityModel.Tokens.Jwt;
using EcommerceMVC.Interfaces.IServices;
using EcommerceMVC.JwtHelper;
using EcommerceMVC.Models.LoginDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using Org.BouncyCastle.Asn1.Ocsp;

namespace EcommerceMVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        private readonly TokenGenerate _tokenService;
        public AuthController(IUserService userService, TokenGenerate token) 
        { 
            _userService = userService;
            _tokenService = token;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(RequestLoginDto request)
        {

            //var user = _userService.VerifyUser(username, password);
            //var users = _userService.GetAllUsers();
            //var existingUser = users.Data.Where(u=>u.UserName == username ).FirstOrDefault();

            //if(existingUser is null)
            //{
            //    return null;
            //}

            var existingUser = _userService.VerifyUser(request.UserName, request.Password);

            if (existingUser is null)
            {
                return null;
            }

            var token = _tokenService.GenerateJwtToken(existingUser.UserName, existingUser.RoleName);

            //// Store token in session
            //HttpContext.Session.SetString("Token", token);

            Response.Cookies.Append("AuthToken", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict
            });

            return RedirectToAction("UserView");


            //return Ok(new ResponseLoginDto
            //{
            //    Token = token,
            //});
          

        }

        [HttpGet]
        public IActionResult UserView()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Login()
        //{
        //    return View();
        //}
    }

   
}

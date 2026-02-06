using EcommerceMVC.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceMVC.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleService _service;
        public RoleController(IRoleService service)
        {
            _service = service;
            
        }

        [HttpGet]
        public IActionResult GetRoles()
        {
            var roles = _service.GetRoles();
            return View(roles);
        }
    }
}

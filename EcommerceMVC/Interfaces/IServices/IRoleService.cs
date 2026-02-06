using EcommerceMVC.Models;
using EcommerceMVC.Models.RoleDtos;

namespace EcommerceMVC.Interfaces.IServices
{
    public interface IRoleService
    {
        ApiResponseModel<List<ResponseRoleDto>> GetRoles();
    }
}

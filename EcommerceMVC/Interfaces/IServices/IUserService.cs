using EcommerceMVC.Models;
using EcommerceMVC.Models.UserDtos;

namespace EcommerceMVC.Interfaces.IServices
{
    public interface IUserService
    {
        List<ResponseUserDto> GetAllUsers();
    }
}

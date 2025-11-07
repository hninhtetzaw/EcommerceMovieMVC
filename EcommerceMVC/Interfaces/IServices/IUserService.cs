using EcommerceMVC.Models;
using EcommerceMVC.Models.UserDtos;

namespace EcommerceMVC.Interfaces.IServices
{
    public interface IUserService
    {
        ApiResponseModel<List<ResponseUserDto>> GetAllUsers();
        ApiResponseModel<ResponseUserDto> CreateUser(RequestNewUserDto newUser);

        ApiResponseModel<ResponseUserDto> GetUserById(string id);

        ApiResponseModel<ResponseUserDto> UpdateUser(string id, UpdateUserDto newUser);

        ResponseUserDto VerifyUser(string username, string password);



    }
}

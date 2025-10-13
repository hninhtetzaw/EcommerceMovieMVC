using EcommerceMVC.Interfaces.IRepositories;
using EcommerceMVC.Interfaces.IServices;
using EcommerceMVC.Models.UserDtos;

namespace EcommerceMVC.Service
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepo;
        public UserService(IUserRepository repo)
        {
            _userRepo = repo;
            
        }
        public List<ResponseUserDto> GetAllUsers()
        {
            var users = _userRepo.GetAllUserAsync();

            //map domain to dto
            var userDto = new List<ResponseUserDto>();
            foreach (var user in users)
            {
                ResponseUserDto userList = new ResponseUserDto 
                { 
                    UserName = user.UserName,
                    UserEmail = user.Email,
                    CreatedDate = user.CreatedDate
                };
                userDto.Add(userList);

            }
            return userDto;
        }
    }
}

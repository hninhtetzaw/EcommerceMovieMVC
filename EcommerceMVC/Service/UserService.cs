using AutoMapper;
using EcommerceMVC.Data;
using EcommerceMVC.Interfaces.IRepositories;
using EcommerceMVC.Interfaces.IServices;
using EcommerceMVC.Models;
using EcommerceMVC.Models.UserDtos;
using Microsoft.AspNetCore.Identity;
using Org.BouncyCastle.Crypto.Paddings;

namespace EcommerceMVC.Service
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;
        public UserService(IUserRepository repo,IMapper mapper)
        {
            _userRepo = repo;
            _mapper = mapper;
            
        }
        public ApiResponseModel<List<ResponseUserDto>> GetAllUsers()
        {
            var response = new ApiResponseModel<List<ResponseUserDto>>();   
            var users = _userRepo.GetAllUserAsync();

            //map domain to dto
            //before auto mapper
            //var userDto = new List<ResponseUserDto>();
            //foreach (var user in users)
            //{
            //    ResponseUserDto userList = new ResponseUserDto 
            //    { 
            //        UserName = user.UserName,
            //        UserEmail = user.Email,
            //        CreatedDate = user.CreatedDate
            //    };
            //    userDto.Add(userList);

            //}
            
            var mappedUser = _mapper.Map<List<ResponseUserDto>>(users);

            response = new ApiResponseModel<List<ResponseUserDto>> {
                success = true,
                message = "User List Fetched Successfully",
                Data = mappedUser,
                Errors = null
            };

            return response;

        }

        public ApiResponseModel<ResponseUserDto> GetUserById(string id)
        {
            var response = new ApiResponseModel<ResponseUserDto>();
            var users = _userRepo.GetUserByIdAsync(id);

            response = new ApiResponseModel<ResponseUserDto>
            {
                success = true,
                message = "User Fetched Successfully",
                Data = _mapper.Map<ResponseUserDto>(users),
                Errors = null
            }; 

            return response;
      

        }
        public ApiResponseModel<ResponseUserDto> CreateUser(RequestNewUserDto newUser)
        {
            var response = new ApiResponseModel<ResponseUserDto>();

            if (newUser is null)
            {
                response = new ApiResponseModel<ResponseUserDto>
                {
                    success = false,
                    message = "",
                    Data = null,
                    Errors = ErrorClass.Invaild()
                };

                return response;
            }
            if(newUser.Password.Length < 6)
            {
                response = new ApiResponseModel<ResponseUserDto>
                {
                    success = false,
                    message = "",
                    Data = null,
                    Errors = ErrorClass.PasswordInvaild()
                };
            }


            //dto To domain
            var userDomain = new TblUser
            {
                Id = newUser.Id,
                UserName = newUser.UserName,
                Email = newUser.Email,
                CreatedDate = DateTime.Now

            };

            var passwordHasher = new PasswordHasher<TblUser>();
            var pwd = passwordHasher.HashPassword(userDomain,newUser.Password);

            userDomain.Pasword = pwd;

            
            var createdUser = _userRepo.CreateUserAsync(userDomain);

            if(createdUser is null)
            {
                response = new ApiResponseModel<ResponseUserDto>
                {
                    success = false,
                    message = "User Create Not Successful",
                    Data = null,
                    Errors = ErrorClass.SystemInvalid()
                };
                return response;
            }

            //domain to dto

            //var createdUserDto = new ResponseUserDto
            //{
            //    UserName = createdUser.UserName,
            //    UserEmail = createdUser.Email,
            //    CreatedDate = createdUser.CreatedDate
            //};

            var createdUserDto = _mapper.Map<ResponseUserDto>(createdUser);
            response = new ApiResponseModel<ResponseUserDto>
            {
                success = true,
                message = "User Created Successfully",
                Data = createdUserDto,
                Errors = null
            };
            return response;

        }
    
        public ApiResponseModel<ResponseUserDto> UpdateUser(string id, UpdateUserDto updateUser)
        {
            var userDomain = _mapper.Map<TblUser>(updateUser);
            var user = _userRepo.UpdateUserAsync(id, userDomain);
            if (user is null) 
            {
                return new ApiResponseModel<ResponseUserDto>
                {
                    success = false,
                    Data = null,
                    Errors = ErrorClass.NotFound()
                };
            }

            var userDto = _mapper.Map<ResponseUserDto>(user);

            return new ApiResponseModel<ResponseUserDto> { 
                success = true,
                Data = userDto,
                Errors = null
            };


        }
    }
}

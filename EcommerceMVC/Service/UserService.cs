using AutoMapper;
using EcommerceMVC.Data;
using EcommerceMVC.Interfaces.IRepositories;
using EcommerceMVC.Interfaces.IServices;
using EcommerceMVC.Models;
using EcommerceMVC.Models.UserDtos;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Ocsp;
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
            var userDto = new List<ResponseUserDto>();
            foreach (var user in users)
            {
                ResponseUserDto userList = new ResponseUserDto
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    RoleName = user.Role.RoleName,
                    Password = user.Password
                    //CreatedDate = user.CreatedDate
                };
                userDto.Add(userList);

            }

            //var mappedUser = _mapper.Map<List<ResponseUserDto>>(users);

            response = new ApiResponseModel<List<ResponseUserDto>> {
                success = true,
                message = "User List Fetched Successfully",
                Data = userDto,
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

            userDomain.Password = pwd;

            
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
            //var userDomain = _mapper.Map<TblUser>(updateUser);
            //var role = JsonConvert.DeserializeObject(updateUser.Role);

            //var userDomain = _mapper.Map<TblUser>(updateUser);

            var userDomain = new TblUser
            {
                UserName = updateUser.UserName,
                Email = updateUser.Email,
                //Role = updateUser.Role
                RoleId = updateUser.RoleId
            };


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
    
        public ResponseUserDto VerifyUser(string username, string password)
        {
          
            //var existingUser = GetAllUsers().Data.Where(u => u.UserName == username).FirstOrDefault();
            var existingUser = _userRepo.GetAllUserAsync().Where(u =>  u.UserName == username).FirstOrDefault();

            if(existingUser is null)
            {
                return null;
            }

            var passwordHasher = new PasswordHasher<TblUser>();
            var result = passwordHasher.VerifyHashedPassword(existingUser, existingUser.Password, password);

            if (result != Microsoft.AspNetCore.Identity.PasswordVerificationResult.Success)
            {
                return null;
            }

            var response = new ResponseUserDto 
            { 
                UserName = existingUser.UserName,
                Password = existingUser.Password,
                RoleName = existingUser.Role.RoleName
            };


            return response;
        }
    }
}

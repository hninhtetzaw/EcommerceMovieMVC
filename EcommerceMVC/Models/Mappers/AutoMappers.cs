using AutoMapper;
using EcommerceMVC.Data;
using EcommerceMVC.Models.UserDtos;


namespace EcommerceMVC.Models.Mappers
{
    public class AutoMappers:Profile
    {
        public AutoMappers()
        {
            CreateMap<TblUser, ResponseUserDto>().ReverseMap();
            CreateMap<TblUser, UpdateUserDto>().ReverseMap();


        }
    }
}

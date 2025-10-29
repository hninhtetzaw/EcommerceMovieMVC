using AutoMapper;
using EcommerceMVC.Interfaces.IRepositories;
using EcommerceMVC.Interfaces.IServices;
using EcommerceMVC.Models;
using EcommerceMVC.Models.RoleDtos;

namespace EcommerceMVC.Service
{
    public class RoleService:IRoleService
    {
        private readonly IRoleRepository _repo;
        private readonly IMapper _mapper;
        public RoleService(IRoleRepository repo, IMapper mapper)
        {
            _repo = repo;   
            _mapper = mapper;
        }
        public ApiResponseModel<List<ResponseRoleDto>> GetRoles()
        {
            var roles = _repo.GetRolesAsync();

            //tbl to dto
            var roleDto = _mapper.Map<List<ResponseRoleDto>>(roles);

            return new ApiResponseModel<List<ResponseRoleDto>>
            {
                Data = roleDto
            };

        }
    }
}

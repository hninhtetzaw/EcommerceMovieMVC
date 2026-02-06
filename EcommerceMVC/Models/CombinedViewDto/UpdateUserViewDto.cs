using EcommerceMVC.Models.RoleDtos;
using EcommerceMVC.Models.UserDtos;

namespace EcommerceMVC.Models.CombinedViewDto
{
    public class UpdateUserViewDto
    {
        public UpdateUserDto UpdateUserDto { get; set; } = new UpdateUserDto();

        public List<ResponseRoleDto> RoleLists = new List<ResponseRoleDto>();
    }
}

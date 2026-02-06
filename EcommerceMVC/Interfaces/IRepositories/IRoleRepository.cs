using EcommerceMVC.Data;

namespace EcommerceMVC.Interfaces.IRepositories
{
    public interface IRoleRepository
    {
        List<TblRole> GetRolesAsync();
    }
}

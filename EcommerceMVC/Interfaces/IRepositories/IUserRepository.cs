using EcommerceMVC.Data;

namespace EcommerceMVC.Interfaces.IRepositories
{
    public interface IUserRepository
    {
        List<TblUser> GetAllUserAsync();
        TblUser GetUserByIdAsync(string id);
        TblUser CreateUserAsync(TblUser user);
        TblUser UpdateUserAsync(string id, TblUser user);
        TblUser DeleteUserAsync(string id);
    }
}

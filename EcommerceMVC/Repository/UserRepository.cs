using EcommerceMVC.Data;
using EcommerceMVC.Interfaces.IRepositories;

namespace EcommerceMVC.Repository
{
    public class UserRepository : IUserRepository
    {
        public List<TblUser> GetAllUserAsync()
        {
            throw new NotImplementedException();
        }

        public TblUser GetUserByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
        public TblUser CreateUserAsync(TblUser user)
        {
            throw new NotImplementedException();
        }

        public TblUser DeleteUserAsync(string id)
        {
            throw new NotImplementedException();
        }

      

        public TblUser UpdateUserAsync(string id, TblUser user)
        {
            throw new NotImplementedException();
        }
    }
}

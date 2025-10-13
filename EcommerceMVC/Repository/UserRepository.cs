using EcommerceMVC.Data;
using EcommerceMVC.Interfaces.IRepositories;

namespace EcommerceMVC.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MoviedbContext _db;
        public UserRepository(MoviedbContext db)
        {
            _db = db;
        }
        public List<TblUser> GetAllUserAsync()
        {
           var userLists = _db.TblUsers.ToList();
            return userLists;
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

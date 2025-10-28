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
            var user = _db.TblUsers.Where(u => u.Id == id).FirstOrDefault();
            return user;
        }
        public TblUser CreateUserAsync(TblUser user)
        {
            var existUser = _db.TblUsers.Where(u=>u.Email == user.Email).FirstOrDefault();
           
            if(existUser is not null)
            {
                return null;
            }

            var userRole = _db.TblRoles.Where(r => r.RoleName == "User").FirstOrDefault();
            user.Role = userRole;

            _db.Add(user);
            _db.SaveChanges();

            return user;
        }

        public TblUser DeleteUserAsync(string id)
        {
            throw new NotImplementedException();
        }
        public TblUser UpdateUserAsync(string id, TblUser user)
        {
           var userExist = _db.TblUsers.Where(u => u.Id == id).FirstOrDefault();
           if(userExist is null)
            {
                return null;
            }
           
           userExist.UserName = user.UserName;
           userExist.Email = user.Email;
           userExist.Role = user.Role;
           userExist.Pasword = user.Pasword;
            _db.Add(userExist);
            _db.SaveChanges();

            return userExist;
        }
    }
}

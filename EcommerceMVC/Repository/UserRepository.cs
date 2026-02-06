using EcommerceMVC.Data;
using EcommerceMVC.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

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
            var userLists = _db.TblUsers.Include("Role").ToList();
            //var userLists = _db.TblUsers.Include("Role").Select(u => new
            //{
            //    u.UserName,
            //    u.Email,
            //    u.Role.RoleName
            //}).ToList();

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
            var userRoleId = "";
            var userExist = _db.TblUsers.Where(u => u.Id == id).FirstOrDefault();
           if(userExist is null)
            {
                return null;
            }

           if(user.RoleId == "Admin")
            {
                userRoleId = _db.TblRoles.Where(r=>r.RoleName == "Admin").Select(r => r.Id).FirstOrDefault();

            }
            else
            {
                userRoleId = _db.TblRoles.Where(r => r.RoleName == "User").Select(r => r.Id).FirstOrDefault();

            }

            userExist.UserName = user.UserName;
           userExist.Email = user.Email;
            //userExist.RoleId = user.RoleId;
            userExist.RoleId =userRoleId;
            //userExist.Password = userExist.Password;
            _db.TblUsers.Update(userExist);
            _db.SaveChanges();

            return userExist;
        }
    }
}

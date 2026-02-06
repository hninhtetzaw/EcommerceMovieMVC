using EcommerceMVC.Data;
using EcommerceMVC.Interfaces.IRepositories;

namespace EcommerceMVC.Repository
{
    public class RoleRepository:IRoleRepository
    {
        private readonly MoviedbContext _db;
        public RoleRepository(MoviedbContext db)
        {
            _db = db;
        }
        public List<TblRole> GetRolesAsync()
        {
            //var roleLists = _db.TblRoles.Select(r=>r.RoleName).ToList();
            var roles = _db.TblRoles.ToList();
            return roles;
        }
    }
}

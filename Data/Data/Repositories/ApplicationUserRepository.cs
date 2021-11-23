using Data.Interfaces;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ApplicationUserRepository : BaseRepository, IApplicationUserRepository
    {
        public ApplicationUserRepository(ReadLaterDataContext context) : base(context) { }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return _db.Users;
        }
        public ApplicationUser GetById(string id)
        {
            return _db.Users.SingleOrDefault(x => x.Id == id);
        }

        public ApplicationUser GetByUsername(string username)
        {
            return _db.Users.SingleOrDefault(x => x.UserName == username);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly ReadLaterDataContext _db;
        public BaseRepository(ReadLaterDataContext db)
        {
            _db = db;
        }
    }
}

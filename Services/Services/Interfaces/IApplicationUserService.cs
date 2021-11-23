using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IApplicationUserService
    {
        ApplicationUser GetCurrentUser(string username);
    }
}

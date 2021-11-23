using Data.Interfaces;
using Entity;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        protected readonly IApplicationUserRepository _userRepository;
        public ApplicationUser GetCurrentUser(string username)
        {
            try
            {
                ApplicationUser user = _userRepository.GetByUsername(username);
                return user;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw new Exception(message);
            }
        }
    }
}

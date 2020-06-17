using fandom.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fandom.WebAPI.Services
{
    public class UsersService : IUsersService
    {
        private readonly AppCtx _ctx;

        public UsersService(AppCtx context)
        {
            _ctx = context;
        }

        public List<User> Get() => _ctx.Users.ToList();
        
    }
}

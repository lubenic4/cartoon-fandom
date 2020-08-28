using AutoMapper;
using fandom.Model;
using fandom.Model.Models;
using fandom.Model.Requests;
using fandom.WebAPI.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fandom.WebAPI.Services
{
    public class UsersService : IUsersService
    {
        private readonly AppCtx _ctx;
        private readonly IMapper _mapper;

        public UsersService(AppCtx context, IMapper mapper)
        {
            _ctx = context;
            _mapper = mapper;
        }

        public List<MUser> Get() {

            var list = _ctx.Users.Select(x => new MUser {
                Id = x.Id,
                Email = x.Email,
                Username = x.Username,
                Roles = x.UsersRoles.Where(y => y.UserId==x.Id).Select(y => new MRole { Id = y.Role.Id, Name = y.Role.Name }).ToList()
            }).ToList();

            return list;
        }

        public MUser InsertUser(UserInsertRequest request)
        {
            var user = _mapper.Map<User>(request);

            _ctx.Users.Add(user);

            _ctx.SaveChanges();

            foreach(var items in request.RolesId)
            {
                var userRole = new UserRole { RoleId = items, UserId = user.Id };
                _ctx.UserRoles.Add(userRole);
            }

            _ctx.SaveChanges();

            return _mapper.Map<MUser>(user);
        }
    }
}

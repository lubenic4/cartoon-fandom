using fandom.Model;
using fandom.Model.Requests;
using fandom.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fandom.WebAPI.Services
{
    public interface IUsersService
    {
        List<MUser> Get();

        MUser GetById(int id);

        MUser Update(int id, UserUpdateRequest user);

        MUser InsertUser(UserInsertRequest request);

        MUser Authenticiraj(string username, string password);
    }
}

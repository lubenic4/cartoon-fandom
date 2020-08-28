using System;
using System.Collections.Generic;
using System.Text;

namespace fandom.Model.Requests
{
   public class UserInsertRequest
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PasswordConfirmation { get; set; }

        public List<int> RolesId { get; set; }

    }
}

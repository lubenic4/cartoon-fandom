using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fandom.WebAPI.Database
{
    public class Data
    {
        public static void Seed(AppCtx context)
        {
            context.Database.Migrate();
        }
    }
}

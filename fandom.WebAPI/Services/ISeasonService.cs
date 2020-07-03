using fandom.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fandom.WebAPI.Services
{
    public interface ISeasonService
    {
        List<MSeason> Get();
    }
}

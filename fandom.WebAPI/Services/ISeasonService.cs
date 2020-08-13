using fandom.Model.Models;
using fandom.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fandom.WebAPI.Services
{
    public interface ISeasonService
    {
        List<MSeason> Get(object search);

        MSeason GetById(int id);

        MSeason Insert(SeasonInsertRequest request);
    }
}

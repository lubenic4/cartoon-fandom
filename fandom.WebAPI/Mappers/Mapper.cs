using AutoMapper;
using fandom.Model;
using fandom.Model.Models;
using fandom.Model.Requests;
using fandom.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace fandom.WebAPI.Mappers
{
    public class Mapper : Profile
    {
      public Mapper()
        {
            CreateMap<User, MUser>();
            CreateMap<UserInsertRequest, User>();


            CreateMap<Character, MCharacter>();
            CreateMap<CharacterInsert, Character>();

            CreateMap<Episode, MEpisode>();

            CreateMap<Season, MSeason>();
                





        }
    }
}

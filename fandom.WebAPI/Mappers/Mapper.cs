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


            CreateMap<Character, MCharacter>().ReverseMap();
            CreateMap<CharacterInsert, Character>();

            CreateMap<Episode, MEpisode>().ReverseMap();
            CreateMap<EpisodeInsertRequest, Episode>().ReverseMap();


            CreateMap<Season, MSeason>();

            CreateMap<MediaFile, MMediaFile>().ReverseMap();
            CreateMap<CharacterMediaFile, MCharacterMediaFile>().ReverseMap();

            CreateMap<Family, MFamily>().ReverseMap();
            CreateMap<FamilyInsertRequest, Family>();

            CreateMap<Role, MRole>();

            CreateMap<Post, MPost>();
            CreateMap<Category, MCategory>();
            CreateMap<Tag, MTag>();
                





        }
    }
}

using AutoMapper;
using fandom.Model;
using fandom.Model.Models;
using fandom.Model.Requests;
using fandom.WebAPI.Database;
using fandom.WebAPI.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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


        public MUser Authenticiraj(string username, string pass)
        {
            var user = _ctx.Users.Include("UsersRoles.Role").FirstOrDefault(x => x.Username == username);

            if (user != null)
            {
                var hashedPass = HashHelper.GenerateHash(user.PasswordSalt, pass);

                if (hashedPass == user.PasswordHash)
                {

                    var muser = new MUser
                    {
                        Id = user.Id,
                        Email = user.Email,
                        Username = user.Username,
                        Roles = user.UsersRoles.Select(x => new MRole { Id = x.RoleId, Name = x.Role.Name }).ToList()
                    };

                    return muser;
                }
            }

            return null;
        }

        public List<MUser> Get() 
        {
            var list = _ctx.Users.Select(x => new MUser {
                Id = x.Id,
                Username=x.Username,
                Email = x.Email,
                FavouriteCharacters = x.UsersCharacters.Where(y => y.UserId == x.Id).Select(y =>
                 new MCharacter
                 {
                     Id = y.CharacterId,
                     Biography = y.Character.Biography,
                     BirthDate = y.Character.BirthDate,
                     FirstName = y.Character.FirstName,
                     LastName = y.Character.LastName,
                     CharacterMediaFile = _mapper.Map<MCharacterMediaFile>(y.Character.CharacterMediaFile),
                     Occupation = y.Character.Occupation,
                     FamilyId = (int)y.Character.FamilyId
                 }).ToList(),
                FavouriteEpisodes = x.UsersEpisodes.Where(y => y.UserId == x.Id).Select(y =>
                 new MEpisode
                 {
                     Id = y.EpisodeId,
                     MediaFile = _mapper.Map<MMediaFile>(y.Episode.MediaFile),
                     Title = y.Episode.Title,
                     AirDate = (DateTime)y.Episode.AirDate,
                     OverallNumberOfEpisode = (int)y.Episode.OverallNumberOfEpisode,
                     SeasonEpisodeNumber = y.Episode.SeasonEpisodeNumber,
                     Season = _mapper.Map<MSeason>(y.Episode.Season),
                     Summary = y.Episode.Summary,
                     Viewcount = y.Episode.Viewcount
                 }).ToList(),
                WatchedEpisodes = x.UserEpisodeActivities.Where(y => y.UserId==x.Id).Select(y => new MEpisode
                {
                    Id = y.EpisodeId,
                    MediaFile = _mapper.Map<MMediaFile>(y.Episode.MediaFile),
                    Title = y.Episode.Title,
                    AirDate = (DateTime)y.Episode.AirDate,
                    OverallNumberOfEpisode = (int)y.Episode.OverallNumberOfEpisode,
                    SeasonEpisodeNumber = y.Episode.SeasonEpisodeNumber,
                    Season = _mapper.Map<MSeason>(y.Episode.Season),
                    Summary = y.Episode.Summary,
                    Viewcount = y.Episode.Viewcount
                }).ToList(),
                Roles = x.UsersRoles.Where(y => y.UserId==x.Id).Select(y => new MRole { Id = y.Role.Id, Name = y.Role.Name }).ToList()
            }).ToList();

            return list;
        }

        public MUser InsertUser(UserInsertRequest request)
        {
            var user = _mapper.Map<User>(request);

            user.PasswordSalt = HashHelper.GenerateSalt();
            user.PasswordHash = HashHelper.GenerateHash(user.PasswordSalt, request.Password);

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

        public MUser GetById(int id)
        {
            var user = _ctx.Users.Where(x => x.Id == id).Select(x => new MUser
            {
                Id = x.Id,
                Email = x.Email,
                Username = x.Username,
                FavouriteCharacters = x.UsersCharacters.Where(y => y.UserId == x.Id).Select(y =>
                  new MCharacter
                  {
                      Id = y.CharacterId,
                      Biography = y.Character.Biography,
                      BirthDate = y.Character.BirthDate,
                      FirstName = y.Character.FirstName,
                      LastName = y.Character.LastName,
                      CharacterMediaFile = _mapper.Map<MCharacterMediaFile>(y.Character.CharacterMediaFile),
                      Occupation = y.Character.Occupation,
                      FamilyId = (int)y.Character.FamilyId
                  }).ToList()
            }).FirstOrDefault();

            return user;
        }

        public MUser Update(int id, UserUpdateRequest request)
        {
            var user = _ctx.Users.Find(id);
            var userToReturn = _mapper.Map<MUser>(user);

            userToReturn.FavouriteEpisodes = _ctx.UserEpisodes.Where(y => y.UserId == user.Id).Select(y => new
            MEpisode
            {
                Id = y.EpisodeId,
                MediaFile = _mapper.Map<MMediaFile>(y.Episode.MediaFile),
                Title = y.Episode.Title,
                AirDate = (DateTime)y.Episode.AirDate,
                OverallNumberOfEpisode = (int)y.Episode.OverallNumberOfEpisode,
                SeasonEpisodeNumber = y.Episode.SeasonEpisodeNumber,
                Season = _mapper.Map<MSeason>(y.Episode.Season),
                Summary = y.Episode.Summary,
                Viewcount = y.Episode.Viewcount
            }).ToList();

            userToReturn.FavouriteCharacters = _ctx.UserCharacters.Where(y => y.UserId == user.Id).Select(y => new
            MCharacter
            {
                Id = y.CharacterId,
                Biography = y.Character.Biography,
                BirthDate = y.Character.BirthDate,
                FirstName = y.Character.FirstName,
                LastName = y.Character.LastName,
                CharacterMediaFile = _mapper.Map<MCharacterMediaFile>(y.Character.CharacterMediaFile),
                Occupation = y.Character.Occupation,
                FamilyId = (int)y.Character.FamilyId

            }).ToList();

            userToReturn.WatchedEpisodes = _ctx.UserEpisodeActivities.Where(y => y.UserId == id).Select(y => new MEpisode
            {
                Id = y.EpisodeId,
                MediaFile = _mapper.Map<MMediaFile>(y.Episode.MediaFile),
                Title = y.Episode.Title,
                AirDate = (DateTime)y.Episode.AirDate,
                OverallNumberOfEpisode = (int)y.Episode.OverallNumberOfEpisode,
                SeasonEpisodeNumber = y.Episode.SeasonEpisodeNumber,
                Season = _mapper.Map<MSeason>(y.Episode.Season),
                Summary = y.Episode.Summary,
                Viewcount = y.Episode.Viewcount
            }).ToList();

            if (request.NewFavouriteCharacter != null)
            {
                UserCharacter uc = new UserCharacter { CharacterId = request.NewFavouriteCharacter.Id, UserId = user.Id };

                if (request.ToAdd)
                {
                    _ctx.UserCharacters.Add(uc);
                    _ctx.SaveChanges();

                    userToReturn.FavouriteCharacters.Add(new MCharacter 
                    { 
                        Id = request.NewFavouriteCharacter.Id, 
                        FirstName = request.NewFavouriteCharacter.FirstName, 
                        CharacterMediaFile = _mapper.Map<MCharacterMediaFile>(request.NewFavouriteCharacter.CharacterMediaFile),
                        FamilyId = request.NewFavouriteCharacter.FamilyId,
                        Biography = request.NewFavouriteCharacter.Biography,
                        BirthDate = request.NewFavouriteCharacter.BirthDate,
                        LastName = request.NewFavouriteCharacter.LastName,
                        Occupation = request.NewFavouriteCharacter.Occupation
                    });

                }
                else
                {
                    _ctx.UserCharacters.Remove(uc);
                    _ctx.SaveChanges();

                    var ch = userToReturn.FavouriteCharacters.Where(x => x.Id == request.NewFavouriteCharacter.Id).FirstOrDefault();
                    userToReturn.FavouriteCharacters.Remove(ch);
                }
            }
            
            if(request.NewFavouriteEpisode != null)
            {
                UserEpisode ue = new UserEpisode { EpisodeId = request.NewFavouriteEpisode.Id, UserId = user.Id };

                if (request.ToAdd)
                {
                    _ctx.UserEpisodes.Add(ue);
                    _ctx.SaveChanges();

                    userToReturn.FavouriteEpisodes.Add(new MEpisode 
                    { 
                        Id = request.NewFavouriteEpisode.Id, 
                        Title = request.NewFavouriteEpisode.Title, 
                        MediaFile = _mapper.Map<MMediaFile>(request.NewFavouriteEpisode.MediaFile),
                        AirDate = request.NewFavouriteEpisode.AirDate,
                        OverallNumberOfEpisode = request.NewFavouriteEpisode.OverallNumberOfEpisode,
                        SeasonEpisodeNumber = request.NewFavouriteEpisode.SeasonEpisodeNumber,
                        Summary = request.NewFavouriteEpisode.Summary,
                        Viewcount = request.NewFavouriteEpisode.Viewcount
                    });

                }
                else
                {
                    _ctx.UserEpisodes.Remove(ue);
                    _ctx.SaveChanges();


                    var ep = userToReturn.FavouriteEpisodes.Where(x => x.Id == request.NewFavouriteEpisode.Id).FirstOrDefault();
                    userToReturn.FavouriteEpisodes.Remove(ep);

                }
            }

            return userToReturn;
        }
    }
}

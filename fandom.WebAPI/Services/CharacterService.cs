using AutoMapper;
using fandom.Model;
using fandom.Model.Models;
using fandom.Model.Requests;
using fandom.Model.Requests.Character;
using fandom.WebAPI.Database;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace fandom.WebAPI.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly AppCtx _ctx;
        private readonly IMapper _mapper;

        public CharacterService(AppCtx context, IMapper mapper)
        {
            _ctx = context;
            _mapper = mapper;
        }

        public List<MCharacter> Get()
        {
            var characters = _ctx.Characters.Select(x => new MCharacter
            {
                Biography = x.Biography,
                BirthDate = x.BirthDate,
                CharacterMediaFile = _mapper.Map<MCharacterMediaFile>(x.CharacterMediaFile),
                FirstName = x.FirstName,
                LastName = x.LastName,
                Id = x.Id,
                Occupation = x.Occupation,
                FamilyId = (int)x.FamilyId
                
            }).ToList();

            return characters;
        }

        public MCharacter GetById(int id)
        {

            var character = _ctx.Characters.Where(x => x.Id == id).Select(x => new MCharacter
            {
                Biography = x.Biography,
                BirthDate = x.BirthDate,
                CharacterMediaFile = _mapper.Map<MCharacterMediaFile>(x.CharacterMediaFile),
                FirstName = x.FirstName,
                LastName = x.LastName,
                Id = x.Id,
                Occupation = x.Occupation,
                FamilyId = (int)x.FamilyId

            }).SingleOrDefault();

            var result = _mapper.Map<MCharacter>(character);
            
            return result;
        }

        public MCharacter Insert(CharacterInsert request)
        {
            var NewCharacter = new Character
            {
                Biography = request.Biography,
                BirthDate = request.BirthDate,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Occupation = request.Occupation
            };

            _ctx.Characters.Add(NewCharacter);

            NewCharacter.Family = _mapper.Map<Family>(request.Family);
            NewCharacter.CharacterMediaFile = _mapper.Map<CharacterMediaFile>(request.MediaFile);

            _ctx.SaveChanges();

            return _mapper.Map<MCharacter>(NewCharacter);
        }

        public MCharacter Update(int id, CharacterUpdateRequest request)
        {
            Character character = _ctx.Characters.Include(x => x.CharacterMediaFile).Where(x => x.Id == id).FirstOrDefault();
            if(character != null)
            {
                if(request.FirstName != "" && request.FirstName != character.FirstName)
                {
                    character.FirstName = request.FirstName;
                }

                if(request.LastName != "" && request.LastName != character.LastName)
                {
                    character.LastName = request.LastName;
                }

                if (request.Biography != "" && request.Biography != character.Biography)
                {
                    character.Biography = request.Biography;
                }

                if (request.Occupation != "" && request.Occupation != character.Occupation)
                {
                    character.Occupation = request.Occupation;
                }

                if(request.MediaFile.Thumbnail != null)
                {
                    character.CharacterMediaFile.Thumbnail = request.MediaFile.Thumbnail;
                }

                character.BirthDate = request.BirthDate;

                _ctx.SaveChanges();
            }

            return _mapper.Map<MCharacter>(character);
        }

        public MCharacter Delete(int id)
        {
            var result = _ctx.Characters.Include(x => x.Family).Include(x => x.Family.Members).Where(x => x.Id == id).FirstOrDefault();
            var characterFamily = result.Family;
          
            _ctx.Characters.Remove(result);
            _ctx.SaveChanges();

            if(characterFamily.Members.Count == 0)
            {
                var mediaFile = _ctx.MediaFiles.Where(x => x.FamilyId == characterFamily.Id).FirstOrDefault();
                _ctx.MediaFiles.Remove(mediaFile);
                _ctx.SaveChanges();

                _ctx.Families.Remove(characterFamily);
                _ctx.SaveChanges();

            }

            return _mapper.Map<MCharacter>(result);
        }
    }
}

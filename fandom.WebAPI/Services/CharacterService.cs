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

    }
}

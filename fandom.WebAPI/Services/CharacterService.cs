using AutoMapper;
using fandom.Model;
using fandom.Model.Requests;
using fandom.Model.Requests.Character;
using fandom.WebAPI.Database;
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
            var characters = _ctx.Characters.ToList();

            return _mapper.Map<List<MCharacter>>(characters);
        }

        public MCharacter GetById(int id)
        {
            var character = _ctx.Characters.Where(x => x.Id == id).SingleOrDefault();
            return _mapper.Map<MCharacter>(character);
        }

        public MCharacter Insert(CharacterInsert request)
        {
            var NewCharacter = _mapper.Map<Character>(request);

            _ctx.Characters.Add(NewCharacter);
            _ctx.SaveChanges();

            return _mapper.Map<MCharacter>(NewCharacter);
        }

        public List<MCharacter> SearchByName(CharacterSearchByName request)
        {
            var query = _ctx.Characters.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.FirstName))
                query = query.Where(x => x.FirstName.StartsWith(request.FirstName));

            if (!string.IsNullOrWhiteSpace(request?.LastName))
                query = query.Where(x => x.LastName.StartsWith(request.LastName));

            var list = query.ToList();

            return _mapper.Map<List<MCharacter>>(list);
        }
    }
}

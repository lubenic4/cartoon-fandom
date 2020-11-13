using fandom.Model;
using fandom.Model.Requests;
using fandom.Model.Requests.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace fandom.WebAPI.Services
{
   public interface ICharacterService
    {
        List<MCharacter> Get();

        MCharacter GetById(int id);

        MCharacter Insert(CharacterInsert request);

        MCharacter Update(int id, CharacterUpdateRequest request);

        MCharacter Delete(int id);
    }

}

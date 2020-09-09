using fandom.Mobile.ViewModels;
using fandom.Model;
using fandom.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace fandom.MobileApp.ViewModels
{
   public class CharacterDetailsViewModel : BaseViewModel
    {
        private readonly APIService _apiService = new APIService("User");
        public MCharacter Character { get; set; }

        public bool hasUserCharacterRelation { get; set; }
        public string ButtonPreferenceText { get; set; }

        public CharacterDetailsViewModel()
        {
            UpdateUserPreference = new Command(async () => await UpdateUserCharacter());

        }

        public ICommand UpdateUserPreference { get; set; }

        public async Task UpdateUserCharacter()
        {
            CheckRelation();
            bool toadd = !hasUserCharacterRelation;
            var request = new UserUpdateRequest { NewFavouriteCharacter = Character, ToAdd = toadd };
           APIService.LoggedUser = await _apiService.Update<MUser>(APIService.LoggedUser.Id, request);
        }

        public void CheckRelation()
        {
            var relation = APIService.LoggedUser.FavouriteCharacters.Where(x => x.Id == Character.Id).FirstOrDefault();
            if (relation == null)
            {
                ButtonPreferenceText = "Add as favourite";
                hasUserCharacterRelation = false;
            }
                
            else 
            {
                ButtonPreferenceText = "Remove from favourite";
                hasUserCharacterRelation = true;
            } 
        }
    }
}

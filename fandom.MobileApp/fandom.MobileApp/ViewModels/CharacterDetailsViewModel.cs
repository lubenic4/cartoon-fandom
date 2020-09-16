using fandom.Mobile.ViewModels;
using fandom.Model;
using fandom.Model.Models;
using fandom.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        private readonly APIService _episodeApiService = new APIService("Episode");
        private readonly APIService _familyApiService = new APIService("Family");

        public MCharacter Character { get; set; }
        public ObservableCollection<MEpisode> episodesCharacterAppearedOn { get; set; } = new ObservableCollection<MEpisode>();
        public ObservableCollection<MCharacter> characterRelatives { get; set; } = new ObservableCollection<MCharacter>();


        public bool hasUserCharacterRelation { get; set; }

        private string _ButtonPreferenceText { get; set; }
        public string ButtonPreferenceText
        {
            get { return _ButtonPreferenceText; }
            set
            {
                _ButtonPreferenceText = value;
                OnPropertyChanged(nameof(ButtonPreferenceText));
            }
        }

        private string _familyString { get; set; }
        public string familyString
        {
            get { return _familyString; }
            set
            {
                _familyString = value;
                OnPropertyChanged(nameof(familyString));
            }
        }


        public CharacterDetailsViewModel()
        {
            UpdateUserPreference = new Command(async () => await UpdateUserCharacter());
            LoadCharacterApperances = new Command(async () => await LoadCharacterEpisode());
        }

        public ICommand UpdateUserPreference { get; set; }
        public ICommand LoadCharacterApperances { get; set; }

        public async Task UpdateUserCharacter()
        {
            CheckRelation();

            bool toadd = !hasUserCharacterRelation;
            var request = new UserUpdateRequest { NewFavouriteCharacter = Character, ToAdd = toadd };
           APIService.LoggedUser = await _apiService.Update<MUser>(APIService.LoggedUser.Id, request);
            if (toadd)
            {
               await Application.Current.MainPage.DisplayAlert("Character", "Character added to your favourite list", "Ok");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Character", "Character removed from your favourite list", "Ok");
            }
        }

        public async Task LoadCharacterEpisode()
        {
            episodesCharacterAppearedOn.Clear();
            characterRelatives.Clear();

            var request = new EpisodesSeasonRequest { CharacterId = Character.Id };
            var episodes = await _episodeApiService.Get<List<MEpisode>>(request);
            if (episodes.Count > 0)
            {
                foreach (var episode in episodes)
                {
                    if(episode.Season!=null)
                    episodesCharacterAppearedOn.Add(episode);
                }
            }

            var family = await _familyApiService.GetById<MFamily>(Character.FamilyId);
            familyString = family.Name;
            foreach(var item in family.Members)
            {
                characterRelatives.Add(item);
            }
        }

        public void CheckRelation()
        {
            var relation = APIService.LoggedUser.FavouriteCharacters.Where(x => x.Id == Character.Id).FirstOrDefault();
            if (relation == null)
            {
                    this.ButtonPreferenceText = "Add to favourites";
                    hasUserCharacterRelation = false;
                
            } 
            else 
            {
                this.ButtonPreferenceText = "Remove from favourites";
                hasUserCharacterRelation = true;
            }

        }
    }
}

using fandom.Mobile.ViewModels;
using fandom.Model;
using fandom.Model.Models;
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
    class EpisodeDetailsViewModel : BaseViewModel
    {
        private readonly APIService _episodeApiService = new APIService("Episode");
        private readonly APIService _apiService = new APIService("User");


        public MEpisode Episode { get; set; }

        public EpisodeDetailsViewModel()
        {
            UpdateUserPreference = new Command(async () => await UpdateUserEpisode());
        }
        public ICommand UpdateUserPreference { get; set; }


        public bool hasUserEpisodeRelation { get; set; }

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

        public async Task UpdateUserEpisode()
        {
            CheckRelation();

            bool toadd = !hasUserEpisodeRelation;
            var request = new UserUpdateRequest { NewFavouriteEpisode = Episode, ToAdd = toadd };
            APIService.LoggedUser = await _apiService.Update<MUser>(APIService.LoggedUser.Id, request);
            if (toadd)
            {
                await Application.Current.MainPage.DisplayAlert("Episode", "Episode added to your favourite list", "Ok");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Episode", "Episode removed from your favourite list", "Ok");
            }
        }

        public async Task UpdateViewCount()
        {
            var request = new EpisodeUserActivityRequest { EpisodeId = Episode.Id, UserId = APIService.LoggedUser.Id };
            var episode = await _episodeApiService.Update<MEpisode>(Episode.Id, request);
            if(!APIService.LoggedUser.WatchedEpisodes.Select(x => x.Id).Contains(Episode.Id))
            {
                APIService.LoggedUser.WatchedEpisodes.Add(episode);
            }
        }

        public void CheckRelation()
        {
            var relation = APIService.LoggedUser.FavouriteEpisodes.Where(x => x.Id == Episode.Id).FirstOrDefault();
            if (relation == null)
            {
                this.ButtonPreferenceText = "Add to favourites";
                hasUserEpisodeRelation = false;
            }
            else
            {
                this.ButtonPreferenceText = "Remove from favourites";
                hasUserEpisodeRelation = true;
            }
        }
    }
}

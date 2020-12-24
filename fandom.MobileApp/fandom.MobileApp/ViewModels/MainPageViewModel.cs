using fandom.Mobile.ViewModels;
using fandom.MobileApp.Views;
using fandom.Model;
using fandom.Model.Models;
using fandom.Model.Requests;
using Flurl.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace fandom.MobileApp.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private readonly APIService _episodeApiService = new APIService("Episode");

        public INavigation NavigationProperty { get; set; }
        public ObservableCollection<MEpisode> FavouriteEpisodes { get; set; } = new ObservableCollection<MEpisode>();
        public ObservableCollection<MCharacter> FavouriteCharacters { get; set; } = new ObservableCollection<MCharacter>();
        public ObservableCollection<MEpisode> RecommendedEpisodes { get; set; } = new ObservableCollection<MEpisode>();

     

   

        public async Task Init()
        {
            RecommendedEpisodes.Clear();
            FavouriteCharacters.Clear();
            FavouriteEpisodes.Clear();


            IEnumerable<MCharacter> listCh = APIService.LoggedUser.FavouriteCharacters;
            IEnumerable<MEpisode> listEp = APIService.LoggedUser.FavouriteEpisodes;

            var rEp = await _episodeApiService.Get<IEnumerable<MEpisode>>();
            List<MEpisode> RecommendedEpisodesList = null;

            if (APIService.LoggedUser.WatchedEpisodes.Count > 0)
            {
                RecommendedEpisodesList = rEp
                       .Where(x => !APIService.LoggedUser.WatchedEpisodes.Select(y => y.Id)
                       .Contains(x.Id) && x.SeasonId != 0)
                       .OrderByDescending(x => x.Viewcount).ToList();

                if(RecommendedEpisodesList.Count == 0)
                {
                   foreach(var character in APIService.LoggedUser.FavouriteCharacters)
                    {
                        var episode = await _episodeApiService.Get<List<MEpisode>>(new EpisodesSeasonRequest { CharacterId = character.Id });

                        RecommendedEpisodesList.AddRange(episode);
                    }
                }
            }
            else
            {
                RecommendedEpisodesList = rEp.OrderByDescending(x => x.Viewcount).ToList();
            }

            foreach (var item in listCh)
            {
                FavouriteCharacters.Add(item);
            }

            foreach(var item in listEp)
            {
                FavouriteEpisodes.Add(item);
            }

            foreach(var item in RecommendedEpisodesList.Take(5))
            {
                if(item.Season != null)
                RecommendedEpisodes.Add(item);
            }
        }

        
    }
}

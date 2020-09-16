using fandom.Mobile.ViewModels;
using fandom.MobileApp.Views;
using fandom.Model;
using fandom.Model.Models;
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

        public MainPageViewModel()
        {
            SwitchToEpisode = new Command(() =>  PushEpisode());
        }

        public ICommand SwitchToEpisode;

        public void  PushEpisode()
        {
            Application.Current.MainPage.DisplayAlert("HA", "HU", "HE");
        }

        public async Task Init()
        {
            RecommendedEpisodes.Clear();
            FavouriteCharacters.Clear();
            FavouriteEpisodes.Clear();
            var rEp = await _episodeApiService.Get<IEnumerable<MEpisode>>();
            IEnumerable<MCharacter> listCh = APIService.LoggedUser.FavouriteCharacters;
            IEnumerable<MEpisode> listEp = APIService.LoggedUser.FavouriteEpisodes;
            List<MEpisode> rEpList = rEp.OrderByDescending(x => x.Viewcount).ToList();

            foreach (var item in listCh)
            {
                FavouriteCharacters.Add(item);
            }

            foreach(var item in listEp)
            {
                FavouriteEpisodes.Add(item);
            }

            foreach(var item in rEpList.Take(3))
            {
                if(item.Season != null)
                RecommendedEpisodes.Add(item);
            }
        }

        
    }
}

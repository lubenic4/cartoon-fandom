using fandom.Mobile.ViewModels;
using fandom.Model;
using fandom.Model.Models;
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

        public ObservableCollection<MEpisode> FavouriteEpisodes { get; set; } = new ObservableCollection<MEpisode>();
        public ObservableCollection<MCharacter> FavouriteCharacters { get; set; } = new ObservableCollection<MCharacter>();


        public void Init()
        {
            FavouriteCharacters.Clear();
            FavouriteEpisodes.Clear();
            IEnumerable<MCharacter> listCh = APIService.LoggedUser.FavouriteCharacters;
            IEnumerable<MEpisode> listEp = APIService.LoggedUser.FavouriteEpisodes;
            foreach (var item in listCh)
            {
                FavouriteCharacters.Add(item);
            }

            foreach(var item in listEp)
            {
                FavouriteEpisodes.Add(item);
            }
        }

        
    }
}

using fandom.Mobile.ViewModels;
using fandom.MobileApp.Views;
using fandom.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace fandom.MobileApp.ViewModels
{
   public class CharactersViewModel : BaseViewModel
    {
        private readonly APIService _apiService = new APIService("Character");
        public ObservableCollection<MCharacter> characters { get; set; } = new ObservableCollection<MCharacter>();


        public CharactersViewModel()
        {
            InitCommand = new Command(async () => await Init());
            testCommand = new Command(() => switchPage());
        }

        
        public ICommand InitCommand { get; set; }
        public ICommand testCommand { get; set; }

      public async Task Init()
      {
            var list = await _apiService.Get<IEnumerable<MCharacter>>();
            characters.Clear();
            foreach(var character in list)
            {
                characters.Add(character);
            }
       }

        public void switchPage()
        {
            // Application.Current.MainPage = new CharacterDetailPage(x);

            Application.Current.MainPage.DisplayAlert("Community", "Radi", "OKH");
        }

    }
}

using fandom.MobileApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace fandom.MobileApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

       async void OnCommunityTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CommunityPage());

        }

        void OnEpisodeTapped(object sender, EventArgs e)
        {
            Application.Current.MainPage.DisplayAlert("Episode", "Radi", "OKH");

        }

       async void OnCharacterTapped(object sender, EventArgs e)
        {
         //   Application.Current.MainPage = new CharactersPage();
            await Navigation.PushAsync(new CharactersPage());

        }


    }
}

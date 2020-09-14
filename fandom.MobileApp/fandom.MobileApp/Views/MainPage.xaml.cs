using fandom.MobileApp.ViewModels;
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
        public MainPageViewModel MainPageVM = null;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = MainPageVM = new MainPageViewModel();
        }

       async void OnCommunityTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CommunityPage());
        }

        async void OnEpisodeTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EpisodesPage());
        }

        async void OnCharacterTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CharactersPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MainPageVM.Init();
        }


    }
}

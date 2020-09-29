using fandom.MobileApp.ViewModels;
using fandom.MobileApp.Views;
using fandom.Model;
using fandom.Model.Models;
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
            BindingContext = MainPageVM = new MainPageViewModel { NavigationProperty = Navigation };
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

        protected async override void OnAppearing()
        {
            base.OnAppearing();
           await MainPageVM.Init();
        }

        private async void ListView_ItemTapped_ch(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as MCharacter;
            await Navigation.PushAsync(new CharacterDetailPage(item));
        }

        private async void ListView_ItemTapped_ep(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as MEpisode;
            await Navigation.PushAsync(new EpisodeDetailsPage(item));
        }

        async void collection1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count != 0)
            {
                var episode = e.CurrentSelection.FirstOrDefault() as MEpisode;
                await Navigation.PushAsync(new EpisodeDetailsPage(episode));

                ((CollectionView)sender).SelectedItem = null;
            }
            
        }
    }
}

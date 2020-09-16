using fandom.MobileApp.ViewModels;
using fandom.Model;
using fandom.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace fandom.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterDetailPage : ContentPage
    {
       private readonly CharacterDetailsViewModel CharacterDetailsVM = null;


        public CharacterDetailPage(MCharacter character)
        {
            InitializeComponent();
            
            BindingContext = CharacterDetailsVM = new CharacterDetailsViewModel { Character=character };
            CharacterDetailsVM.CheckRelation();

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await CharacterDetailsVM.LoadCharacterEpisode();

        }


        private async void ListView_ItemTapped_ch(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as MCharacter;
            await Navigation.PushAsync(new CharacterDetailPage(item));
        }

        

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as MEpisode;
            await Navigation.PushAsync(new EpisodeDetailsPage(item));
        }
    }
}
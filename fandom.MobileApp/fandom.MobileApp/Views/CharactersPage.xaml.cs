using fandom.MobileApp.ViewModels;
using fandom.Model;
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
    public partial class CharactersPage : ContentPage
    {
        public CharactersViewModel CharacterVM = null;
        public CharactersPage()
        {
            InitializeComponent();
            BindingContext = CharacterVM = new CharactersViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await CharacterVM.Init();

        }

        async void  OnTap(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as MCharacter;
            await Navigation.PushAsync(new CharacterDetailPage(item));

        }


    }
}
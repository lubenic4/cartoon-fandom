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

        void OnTap(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as MCharacter;
            // Application.Current.MainPage.DisplayAlert("Community", "Radi","OKH");
            Application.Current.MainPage = new CharacterDetailPage(item.Id);
        }


    }
}
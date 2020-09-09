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

        void OnCommunityTapped(object sender, EventArgs e)
        {
            Application.Current.MainPage.DisplayAlert("Community", "Radi","OKH");
            
        }

        void OnEpisodeTapped(object sender, EventArgs e)
        {
            Application.Current.MainPage.DisplayAlert("Episode", "Radi", "OKH");

        }

        void OnCharacterTapped(object sender, EventArgs e)
        {
            Application.Current.MainPage = new CharactersPage();

        }


    }
}

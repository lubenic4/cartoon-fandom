using fandom.MobileApp.ViewModels;
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


        public CharacterDetailPage(int id)
        {
            InitializeComponent();
           BindingContext = CharacterDetailsVM = new CharacterDetailsViewModel(id);

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await CharacterDetailsVM.Init();

        }
    }
}
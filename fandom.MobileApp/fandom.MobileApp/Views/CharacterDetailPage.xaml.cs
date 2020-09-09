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
    public partial class CharacterDetailPage : ContentPage
    {
       private readonly CharacterDetailsViewModel CharacterDetailsVM = null;


        public CharacterDetailPage(MCharacter character)
        {
            InitializeComponent();
           BindingContext = CharacterDetailsVM = new CharacterDetailsViewModel { Character=character };
            CharacterDetailsVM.CheckRelation();


        }
    }
}
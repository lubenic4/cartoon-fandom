using fandom.MobileApp.ViewModels;
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
    public partial class PostEditPage : ContentPage
    {
        public PostEditViewModel PostEditVM = null;
        public PostEditPage(MPost post)
        {
            InitializeComponent();
            BindingContext = PostEditVM = new PostEditViewModel { Post = post };
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await PostEditVM.LoadFields();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await PostEditVM.Update();
        }
    }
}
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
    public partial class PostHistory : ContentPage
    {
        public PostHistoryViewModel PostHistoryVM = null;

        public PostHistory()
        {
            InitializeComponent();

            BindingContext = PostHistoryVM = new PostHistoryViewModel();

        }


        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await PostHistoryVM.LoadPosts();
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as MPost;
            await Navigation.PushAsync(new PostEditPage(item));
        }
    }
}
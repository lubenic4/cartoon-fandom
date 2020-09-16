using fandom.Mobile.ViewModels;
using fandom.MobileApp.Views;
using fandom.Model.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace fandom.MobileApp.ViewModels
{
   public class CommunityViewModel : BaseViewModel
    {
        public ObservableCollection<MPost> AllPosts { get; set; } = new ObservableCollection<MPost>();

        private readonly APIService _postApiService = new APIService("Post");


        public ICommand InitPosts;


        public CommunityViewModel()
        {
            InitPosts = new Command(async () => await LoadPosts());
        }

        public async Task LoadPosts()
        {
            AllPosts.Clear();
            var posts = await _postApiService.Get<IEnumerable<MPost>>();
            foreach (var item in posts)
            {
                AllPosts.Add(item);
            }
        }

       

    }
}

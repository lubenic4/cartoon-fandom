using fandom.Mobile.ViewModels;
using fandom.Model.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace fandom.MobileApp.ViewModels
{
   public class PostHistoryViewModel : BaseViewModel
    {
        private readonly APIService _postApiService = new APIService("Post");

        public ObservableCollection<MPost> AllPosts { get; set; } = new ObservableCollection<MPost>();

        public PostHistoryViewModel()
        {
            InitCommand = new Command(async () => await LoadPosts());
        }

        public ICommand InitCommand { get; set; }

        public async Task LoadPosts()
        {
            AllPosts.Clear();
            var posts = await _postApiService.Get<IEnumerable<MPost>>();

            List<MPost> lists = posts.Where(x => x.User.Id == APIService.LoggedUser.Id).ToList();
                foreach (var item in lists)
                {
                    AllPosts.Add(item);
                }
        }

    }
}

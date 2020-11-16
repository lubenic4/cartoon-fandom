using fandom.Mobile.ViewModels;
using fandom.MobileApp.Views;
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
   public class CommunityViewModel : BaseViewModel
    {
        public ObservableCollection<MPost> AllPosts { get; set; } = new ObservableCollection<MPost>();


        private readonly APIService _postApiService = new APIService("Post");

        public CommunityViewModel()
        {
            InitCommand = new Command(async () => await LoadPosts());
        }

        public ICommand InitCommand { get; set; }


        string _selectedOption = null;

        public string SelectedOption
        {
            get { return _selectedOption; }
            set
            {
                SetProperty(ref _selectedOption, value);
                if (value != null)
                {
                    InitCommand.Execute(null);
                }

            }
        }

        public async Task LoadPosts()
        {
            AllPosts.Clear();
            var posts = await _postApiService.Get<IEnumerable<MPost>>();
           

            if(SelectedOption != null)
            {
                switch (SelectedOption)
                {
                    case "AtoZ":
                        List<MPost> listAtoZ = posts.OrderBy(x => x.Title).ToList();
                        foreach (var item in listAtoZ)
                        {
                            AllPosts.Add(item);
                        }
                        break;
                    case "Category":
                        List<MPost> listCategory = posts.OrderBy(x => x.Category.Id).ToList();
                        foreach (var item in listCategory)
                        {
                            AllPosts.Add(item);
                        }
                        break;
                    case "Date":
                        List<MPost> listDate = posts.OrderBy(x => x.CreationDate).ToList();
                        foreach (var item in listDate)
                        {
                            AllPosts.Add(item);
                        }
                        break;
                }
            }
            else
            {
                List<MPost> lists = posts.OrderByDescending(x => x.Id).ToList();
                foreach (var item in lists)
                {
                    AllPosts.Add(item);
                }
            }
        }

    }
}

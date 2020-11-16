using fandom.Mobile.ViewModels;
using fandom.Model.Models;
using fandom.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace fandom.MobileApp.ViewModels
{
   public class PostEditViewModel : BaseViewModel
    {
        private readonly APIService _categoryApiService = new APIService("Category");
        private readonly APIService _tagApiService = new APIService("Tag");
        private readonly APIService _postApiService = new APIService("Post");

        public ICommand InitFields;
        public ICommand CreatePost;

        public MPost Post { get; set; }

        public PostEditViewModel()
        {
            InitFields = new Command(async () => await LoadFields());
            CreatePost = new Command(async () => await Update());

        }

        private string _title = string.Empty;
        public string PostTitle
        {
            get { return _title; }
            set { 
                SetProperty(ref _title, value);
            }
        }

        private string _summary = string.Empty;
        public string PostSummary
        {
            get { return _summary; }
            set { 
                SetProperty(ref _summary, value);
            }
        }

        


        MCategory _selectedCategory = null;

        public MCategory selectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                SetProperty(ref _selectedCategory, value);


            }
        }


        public ObservableCollection<MCategory> Categories { get; set; } = new ObservableCollection<MCategory>();

        public ObservableCollection<MTag> Tags { get; set; } = new ObservableCollection<MTag>();


        public async Task Update()
        {
            try
            {
                if (selectedCategory != null && !string.IsNullOrWhiteSpace(PostSummary) && !string.IsNullOrWhiteSpace(PostTitle))
                {
                    var request = new PostUpdateRequest
                    {
                        Category = selectedCategory,
                        UpdatedDate = DateTime.Now,
                        Summary = PostSummary,
                        Title = PostTitle,
                        Tags = new List<MTag>()
                    };

                    foreach (var item in Tags)
                    {
                        if (item.isChecked)
                        {
                            request.Tags.Add(item);
                        }
                    }

                    await _postApiService.Update<MPost>(Post.Id,request);
                    await Application.Current.MainPage.DisplayAlert("Post", "Updated", "Ok");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Info", "Fill all info", "Ok");
                }
            }
            catch
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Server error", "Ok");
            }

        }

        public async Task LoadFields()
        {
            PostTitle = Post.Title;
            PostSummary = Post.Summary;

            if (Categories.Count == 0)
            {
                var categs = await _categoryApiService.Get<IEnumerable<MCategory>>();
                var tags = await _tagApiService.Get<IEnumerable<MTag>>();

                foreach (var item in categs)
                {
                    Categories.Add(item);
                }

                foreach (var item in tags)
                {
                    Tags.Add(item);
                }
            }
        }
    }
}

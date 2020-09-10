using fandom.Mobile.ViewModels;
using fandom.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace fandom.MobileApp.ViewModels
{
   public class PostPageViewModel : BaseViewModel
    {
        private readonly APIService _postApiService = new APIService("Post");

        public MPost Post { get; set; }

        public ICommand InitPost;

    }
}

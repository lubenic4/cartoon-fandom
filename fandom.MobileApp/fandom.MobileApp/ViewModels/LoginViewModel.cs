using fandom.Mobile.ViewModels;
using fandom.Model;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace fandom.MobileApp.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        private readonly APIService _apiService = new APIService("User");
        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await Login());
        }

        string _username = string.Empty;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public ICommand LoginCommand { get; set; }

        async Task Login()
        {
            IsBusy = true;
            APIService.Username = Username;
            APIService.Password = Password;
            var users = await _apiService.Get<List<MUser>>();
            if (users != null)
            {
                APIService.LoggedUser = users.Where(x => x.Username == Username).FirstOrDefault();
                Application.Current.MainPage = new NavigationPage(new MainPage());
            }


        }
    }
}

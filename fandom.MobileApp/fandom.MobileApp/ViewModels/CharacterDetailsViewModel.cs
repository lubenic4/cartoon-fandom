using fandom.Mobile.ViewModels;
using fandom.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace fandom.MobileApp.ViewModels
{
   public class CharacterDetailsViewModel : BaseViewModel
    {
        private readonly APIService _characterApiService = new APIService("Character");

        private readonly int CharacterId;
        public MCharacter Character { get; set; }

        public CharacterDetailsViewModel(int id)
        {
            CharacterId = id;

            InitCommand = new Command(async () => await Init());

        }

        public ICommand InitCommand { get; set; }


        public async Task Init()
        {
            Character = await _characterApiService.GetById<MCharacter>(CharacterId);
        }

    }
}

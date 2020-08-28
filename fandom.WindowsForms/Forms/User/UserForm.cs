using fandom.Model;
using fandom.WindowsForms.Forms.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fandom.WindowsForms.Forms
{
    public partial class UserForm : Form
    {
        private readonly APIService _userApiService = new APIService("User");

        public UserForm()
        {
            InitializeComponent();
        }

        private static UserForm userInstance;

        public static UserForm GetForm
        {
            get
            {
                if (userInstance == null || userInstance.IsDisposed)
                    userInstance = new UserForm();
                return userInstance;
            }
        }

        private void addEpisodeButton_Click(object sender, EventArgs e)
        {
            var form = new AddUser();
            form.Show();
        }

        private async void UserForm_Load(object sender, EventArgs e)
        {
           await PopulateListView();
        }

        public async Task PopulateListView()
        {
            this.listView1.Items.Clear();
            var result = await _userApiService.Get<List<MUser>>();
            foreach (var items in result)
            {
                var item = new ListViewItem(items.Username);
                item.SubItems.Add(items.Email);

                StringBuilder strBuilder = new StringBuilder();
                items.Roles.ForEach(x => strBuilder.Append($"{x.Name} "));

                item.SubItems.Add(strBuilder.ToString());

                this.listView1.Items.Add(item);
            }
        }
    }
}

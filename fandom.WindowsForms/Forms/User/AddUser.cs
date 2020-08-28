using fandom.Model;
using fandom.Model.Models;
using fandom.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fandom.WindowsForms.Forms.User
{
    public partial class AddUser : Form
    {
        private readonly APIService _roleApiService = new APIService("Role");
        private readonly APIService _userApiService = new APIService("User");

        private UserInsertRequest _request = new UserInsertRequest();

        public AddUser()
        {
            InitializeComponent();
        }

        private async void AddUser_Load(object sender, EventArgs e)
        {
            var roles = await _roleApiService.Get<List<MRole>>();

            foreach(var item in roles)
            {
                ListViewItem lvItem = new ListViewItem(item.Name.ToString());
                lvItem.SubItems.Add(item.Id.ToString());

                this.listView1.Items.Add(lvItem);
            }

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var items = this.listView1.CheckedItems;

            if (items.Count != 0)
            {
                _request.RolesId = new List<int>();

                foreach(ListViewItem item in items)
                {
                    var stringz = item.SubItems[1].Text.ToString();
                    int id = Int32.Parse(stringz);

                    _request.RolesId.Add(id);
                }
            }

            _request.Username = this.textBox1.Text;
            _request.Email = this.textBox2.Text;
            _request.Password = this.textBox3.Text;
            _request.PasswordConfirmation = this.textBox4.Text;

            if(_request.Password == _request.PasswordConfirmation)
            {
                await _userApiService.Insert<MUser>(_request);
                await UserForm.GetForm.PopulateListView();
            }
            else
            {
                MessageBox.Show("Password doesn't match");
            }
        }
    }
}

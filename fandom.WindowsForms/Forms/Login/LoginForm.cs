using fandom.Model;
using fandom.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fandom.WindowsForms.Forms.Login
{
    public partial class LoginForm : Form
    {
        APIService _service = new APIService("User");

        public LoginForm()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                APIService.Username = textBox1.Text;
                APIService.Password = textBox2.Text;

               await _service.Get<List<MUser>>();


                var form = new HomeMDI();
                form.Show();

                this.Hide();
            }
            catch
            {
                MessageBox.Show("Wrong username or password", "Autentification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

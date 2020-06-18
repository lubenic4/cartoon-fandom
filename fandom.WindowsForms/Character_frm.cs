using fandom.Model;
using fandom.Model.Requests.Character;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fandom.WindowsForms
{
    public partial class Character_frm : Form
    {
        private readonly APIService _apiService = new APIService("Character");

        public Character_frm()
        {
            InitializeComponent();
        }


        private async void button1_Click(object sender, EventArgs e)
        {
            var request = new CharacterSearchByName { FirstName = textBox1.Text };

            var result = await _apiService.Get<List<MCharacter>>(request);

            dataGridView1.DataSource = result;

        }
    }
}

using fandom.Model;
using fandom.WindowsForms.Custom_controls;
using fandom.WindowsForms.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fandom.WindowsForms.Forms.Family
{
    public partial class DetailsFamily : Form
    {
        private readonly APIService _familyService = new APIService("Family");
        private readonly int _familyId;
        public DetailsFamily(int id)
        {
            _familyId = id;
            InitializeComponent();
        }

        private async void DetailsFamily_Load(object sender, EventArgs e)
        {
            var data = await _familyService.GetById<MFamily>(_familyId);
            BindData(data);
        }

        private void BindData(MFamily family)
        {
            this.pictureBox1.Image = ImageWorker.ConvertFromByteArray(family.MediaFile.Thumbnail);
            this.label1.Text = family.Name;

            foreach (var item in family.Members)
            {
                var character = new CharacterFamilyControl
                {
                    Id = item.Id.ToString(),
                    Icon = ImageWorker.ConvertFromByteArray(item.CharacterMediaFile.Thumbnail),
                    CharacterLabel = $"{item.FirstName} {item.LastName}",
                    isCharacter = true
                };

                this.flowLayoutPanel1.Controls.Add(character);
            }
        }
    }
}

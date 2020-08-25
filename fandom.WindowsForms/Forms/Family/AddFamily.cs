using fandom.Model;
using fandom.Model.Requests;
using fandom.WindowsForms.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fandom.WindowsForms.Forms.Family
{
    public partial class AddFamily : Form
    {
        private readonly APIService _familyApiService = new APIService("Family");
        private FamilyInsertRequest _request = new FamilyInsertRequest
        {
            Name = " ",
            Thumbnail = null
        };

        public AddFamily()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UploadFamilyThumbnail();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            _request.Name = this.textBox1.Text;

            await _familyApiService.Insert<MFamily>(_request);
        }

        private void UploadFamilyThumbnail()
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FileInfo fi = new FileInfo(ofd.FileName);
                    var imagebytes = File.ReadAllBytes(fi.FullName);
                    _request.Thumbnail = imagebytes;
                    this.pictureBox1.Image = ImageWorker.ConvertFromByteArray(imagebytes);
                }
            }
        }
    }
}

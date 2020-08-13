using fandom.Model.Models;
using fandom.Model.Requests;
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

namespace fandom.WindowsForms.Forms.Episode
{
    public partial class AddEpisode : Form
    {

        private readonly APIService _episodeApiService = new APIService("Episode");

        private EpisodeInsertRequest _request = new EpisodeInsertRequest {
            Title = "",
            OverallNumberOfEpisode = 0,
            Summary = "",
            MediaFile = new MMediaFile()
        };

        public AddEpisode()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            using(OpenFileDialog ofd = new OpenFileDialog() {Multiselect = false })
            {
                if(ofd.ShowDialog() == DialogResult.OK)
                {

                    FileInfo fi = new FileInfo(ofd.FileName);

                    var imageByte = File.ReadAllBytes(fi.FullName);

                    _request.MediaFile.Thumbnail = imageByte;
                    
                    Image image = Image.FromFile(ofd.FileName);
                    pictureBox1.Image = image;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog ofd = new OpenFileDialog() {Multiselect=false})
            {

                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    FileInfo fi = new FileInfo(ofd.FileName);
                    _request.MediaFile.FileName = $"{fi.Name}";
                    _request.MediaFile.Path = fi.FullName;

                    label4.Text = $"{fi.Name}";
                }
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            _request.Title = textBox1.Text;
            _request.Summary = textBox2.Text;
            _request.AirDate = dateTimePicker1.Value;

           await _episodeApiService.Insert<MEpisode>(_request);
        }
    }
}

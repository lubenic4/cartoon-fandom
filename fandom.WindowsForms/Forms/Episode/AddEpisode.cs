using fandom.Model;
using fandom.Model.Models;
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

namespace fandom.WindowsForms.Forms.Episode
{
    public partial class AddEpisode : Form
    {

        private readonly APIService _episodeApiService = new APIService("Episode");
        private readonly APIService _characterApiService = new APIService("Character");

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




        private async void AddEpisode_Load(object sender, EventArgs e)
        {
            await InitializeCharacters();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UploadEpisodeThumbnail();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            await InsertEpisode();
        }





        private async Task InitializeCharacters()
        {
            try
            {
                var characters = await _characterApiService.Get<List<MCharacter>>();

                foreach (var item in characters)
                {
                    ListViewItem itemm = new ListViewItem(item.Id.ToString());
                    itemm.SubItems.Add($"{item.FirstName} {item.LastName}");

                    this.listView1.Items.Add(itemm);
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }

        }

        private void UploadEpisodeThumbnail()
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FileInfo fi = new FileInfo(ofd.FileName);

                    var imageByte = File.ReadAllBytes(fi.FullName);

                    _request.MediaFile.Thumbnail = imageByte;

                    pictureBox1.Image = ImageWorker.ConvertFromByteArray(imageByte);

                }
            }
        }



        private async Task InsertEpisode()
        {
            try
            {

                var selectedCharacters = this.listView1.SelectedItems;
                var characters = new List<MCharacter>();

                foreach (ListViewItem item in selectedCharacters)
                {
                    int id = Int32.Parse(item.Text);
                    var character = await _characterApiService.GetById<MCharacter>(id);
                    characters.Add(character);

                }

                _request.MediaFile.Path = videoUrlTextBox.Text;
                _request.MainCharacters = characters;
                _request.Title = textBox1.Text;
                _request.Summary = textBox2.Text;
                _request.AirDate = dateTimePicker1.Value;
                await _episodeApiService.Insert<MEpisode>(_request);
            }
            catch
            {
                MessageBox.Show("Error insert");
            }
        } 
    }
}

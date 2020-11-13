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
using System.Xml.Serialization;

namespace fandom.WindowsForms.Forms.Episode
{
    public partial class DetailsEpisode : Form
    {
        private readonly int _eId;
        private readonly APIService _episodeService = new APIService("Episode");
        private readonly APIService _characterApiService = new APIService("Character");

        private EpisodeUpdateRequest request = new EpisodeUpdateRequest
        {
            Summary = "",
            AirDate = DateTime.Now,
            MainCharacters = new List<MCharacter>(),
            Title = "",
            VideoUrl = ""
        };


        public DetailsEpisode(int id)
        {
            _eId = id;
            InitializeComponent();
        }

        private class DataHolder
        {
            public string Title { get; set; }
            public string Summary { get; set; }
        }

        private DataHolder Holder { get; set; }

        private async void DetailsEpisode_Load(object sender, EventArgs e)
        {
            var result = await _episodeService.GetById<MEpisode>(_eId);
            var characters = await _characterApiService.Get<List<MCharacter>>();


            BindData(result, characters);
        }

        private async void deleteButton_Click(object sender, EventArgs e)
        {
           await DeleteEpisode();
        }


        private void BindData(MEpisode episode, List<MCharacter> characters)
        {
            Holder = new DataHolder
            {
                Title = episode.Title,
                Summary = episode.Summary
            };

            foreach (var item in episode.Characters)
            {
                ListViewItem itemm = new ListViewItem(item.Id.ToString());
                itemm.SubItems.Add($"{item.FirstName} {item.LastName}");

                this.listView1.Items.Add(itemm);
            }

            textBox1.Text = $"{episode.Title}";
            label2.Text = $"(Overall episode:{episode.OverallNumberOfEpisode})";
            label3.Text = $"Air date {episode.AirDate:dd-MM-yyyy}";
            textBox2.Text = episode.Summary;
            if (episode.MediaFile != null)
            {
                axWindowsMediaPlayer1.URL = episode.MediaFile.Path;
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }

            if (episode.Season != null)
            {
                eSeasonNumber.Text = $"S{episode.Season.OrdinalNumber}E{episode.SeasonEpisodeNumber}";
            }

            foreach (var item in characters)
            {
                ListViewItem itemm = new ListViewItem(item.Id.ToString());
                itemm.SubItems.Add($"{item.FirstName} {item.LastName}");

                this.listView2.Items.Add(itemm);
            }
        }

        private async Task DeleteEpisode()
        {
            this.Close();

            var episodeInfo = await _episodeService.Delete<MEpisode>(_eId);

            var seasonForm = SeasonForm.GetForm;
            await seasonForm.LoadSeasons();

            MessageBox.Show($"Episode {episodeInfo.Title} is removed");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            changeVisibilty(true);
            this.textBox1.BackColor = Color.White;
            this.textBox2.BackColor = Color.White;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            changeVisibilty(false);
            this.textBox1.BackColor = Color.WhiteSmoke;
            this.textBox2.BackColor = Color.WhiteSmoke;

            this.textBox1.Text = Holder.Title;
            this.textBox2.Text = Holder.Summary;
        }

        private void changeVisibilty(bool flag)
        {
            this.textBox1.ReadOnly = !flag;
            this.eSeasonNumber.Visible = !flag;
            this.label2.Visible = !flag;
            this.label5.Visible = !flag;
            this.listView1.Visible = !flag;
            this.textBox2.ReadOnly = !flag;
            this.deleteButton.Visible = !flag;
            this.button1.Visible = !flag;

            this.label6.Visible = flag;
            this.listView2.Visible = flag;
            this.label1.Visible = flag;
            this.videoUrlTextBox.Visible = flag;
            this.dateTimePicker1.Visible = flag;
            this.button2.Visible = flag;
            this.button3.Visible = flag;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                request.Title = textBox1.Text;
                request.Summary = textBox2.Text;
                request.AirDate = dateTimePicker1.Value;
                request.VideoUrl = videoUrlTextBox.Text;

                var selectedCharacters = this.listView2.SelectedItems;
                foreach (ListViewItem item in selectedCharacters)
                {
                    int id = Int32.Parse(item.Text);
                    var character = new MCharacter { Id = id };
                    request.MainCharacters.Add(character);
                }

                await _episodeService.Update<MEpisode>(_eId, request);
                MessageBox.Show("Updated");
                DetailsEpisode.ActiveForm.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}

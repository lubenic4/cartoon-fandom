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

        public DetailsEpisode(int id)
        {
            _eId = id;
            InitializeComponent();
        }

        private async void DetailsEpisode_Load(object sender, EventArgs e)
        {
            var result = await _episodeService.GetById<MEpisode>(_eId);
            BindData(result);
        }

        private void BindData(MEpisode episode)
        {
            label1.Text = $"{episode.Title}";
            label2.Text = $"(Overall episode:{episode.OverallNumberOfEpisode})";
            label3.Text = $"Air date {episode.AirDate:dd-MM-yyyy}";
            label4.Text = episode.Summary;
            if (episode.MediaFile != null)
            {
                axWindowsMediaPlayer1.URL = episode.MediaFile.Path;
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }

            if(episode.Season != null)
            {
                eSeasonNumber.Text = $"S{episode.Season.OrdinalNumber}E{episode.SeasonEpisodeNumber}";
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            this.Close();
             var episodeInfo = await _episodeService.Delete<MEpisode>(_eId);
            MessageBox.Show($"Episode {episodeInfo.Title} is removed");
        }
    }
}

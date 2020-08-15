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

namespace fandom.WindowsForms.Forms.Season
{
    public partial class DetailsSeason : Form
    {
        private readonly int sId;
        private readonly APIService _apiService = new APIService("Season");
        private readonly APIService _episodeApiService = new APIService("Episode");



        public DetailsSeason(int id)
        {
            sId = id;
            InitializeComponent();
        }

        private async void DetailsSeason_Load(object sender, EventArgs e)
        {
            var result = await _apiService.GetById<MSeason>(sId);
            var episodesResult = await _episodeApiService.Get<List<MEpisode>>(new EpisodesSeasonRequest { SeasonId = sId });
            BindData(result,episodesResult);
        }

        private void BindData(MSeason season,List<MEpisode> episodes)
        {
            

            this.sOrdinalNumber.Text = $"SEASON {season.OrdinalNumber}";
            this.sPremiereDate.Text = $"Premiere date {season.PremiereDate.ToString("dd-MM-yy")}";
            this.sSummary.Text = season.Summary;
            this.sNoOfEpisodes.Text = $"({season.NoOfEpisodes} episodes)";

            foreach(var item in episodes)
            {
                ListViewItem lItem = new ListViewItem(item.Id.ToString());
                lItem.SubItems.Add(item.Title);
                lItem.SubItems.Add(item.AirDate.ToString("dd-MM-yyyy"));
                lItem.SubItems.Add(item.SeasonEpisodeNumber.ToString());
                lItem.SubItems.Add(item.OverallNumberOfEpisode.ToString());

                this.listView1.Items.Add(lItem);
            }
            
        }
    }
}

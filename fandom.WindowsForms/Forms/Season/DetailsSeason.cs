using fandom.Model.Models;
using fandom.Model.Requests;
using fandom.WindowsForms.Forms.Episode;
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
            var seasonById = await _apiService.GetById<MSeason>(sId);
            BindData(seasonById);
        }

        private void BindData(MSeason season)
        {
            this.listView1.Items.Clear();

            if (season != null)
            {
                this.sOrdinalNumber.Text = $"SEASON {season.OrdinalNumber}";
                this.sPremiereDate.Text = $"Premiere date {season.PremiereDate.ToString("dd-MM-yy")}";
                this.sSummary.Text = season.Summary;
                this.sNoOfEpisodes.Text = $"({season.NoOfEpisodes} episodes)";
            

                foreach(var item in season.SeasonEpisodes)
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

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
                var idStr = listView1.SelectedItems[0].Text;
                var id = Int32.Parse(idStr);

                var form = new DetailsEpisode(id);
                form.Show();
        }

        private async void DetailsSeason_Activated(object sender, EventArgs e)
        {
            var seasonById = await _apiService.GetById<MSeason>(sId);
            BindData(seasonById);
        }
    }
}

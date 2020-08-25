using fandom.Model.Models;
using fandom.Model.Requests;
using Flurl.Util;
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

namespace fandom.WindowsForms.Forms.Season
{
    public partial class AddSeason : Form
    {
        private readonly APIService _episodeApiService = new APIService("Episode");

        private readonly APIService _seasonApiService = new APIService("Season");

        private readonly SeasonForm sForm = SeasonForm.GetForm;


        public  SeasonInsertRequest _request = new SeasonInsertRequest();

        public AddSeason()
        {
            InitializeComponent();
        }

        private async void AddSeason_Load(object sender, EventArgs e)
        {
            await LoadUnassignedEpisodes();
        }

        private async Task LoadUnassignedEpisodes()
        {
            var result = await _episodeApiService.Get<List<MEpisode>>(new EpisodesSeasonRequest { isAssigned = false });
            PopulateListView(result);
           
        }

        private void PopulateListView(List<MEpisode> episodes)
        {
            foreach (var it in episodes)
            {
                ListViewItem item = new ListViewItem(it.Id.ToString());
                item.SubItems.Add(it.Title);
                item.SubItems.Add(it.OverallNumberOfEpisode.ToString());
                item.SubItems.Add(it.Summary);

                this.listView1.Items.Add(item);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var items = this.listView1.CheckedItems;

            if (items.Count != 0)
            {
               await InsertSeason(items);

               await RefreshSeasonList();

                HandleActiveForm();
            }
            else MessageBox.Show("Select episodes");
        }

        private async Task InsertSeason(ListView.CheckedListViewItemCollection checkedEpisodes)
        {
            var episodesRequest = new EpisodesSeasonRequest { EpisodesIds = new List<int>() };
            foreach (ListViewItem item in checkedEpisodes)
            {
                int id = Int32.Parse(item.Text);
                episodesRequest.EpisodesIds.Add(id);
            }

            var episodes = await _episodeApiService.Get<List<MEpisode>>(episodesRequest);

            _request.Episodes = episodes;

            await _seasonApiService.Insert<MSeason>(_request);
        }

        private async Task RefreshSeasonList()
        {
            var seasonListView = sForm.seasonListView;
            seasonListView.Items.Clear();
            await sForm.LoadSeasons();
        }

        private void HandleActiveForm()
        {
            AddSeason.ActiveForm.Close();
            MessageBox.Show("OK");
        }


    }
}

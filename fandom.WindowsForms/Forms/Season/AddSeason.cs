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


        public  SeasonInsertRequest _request = new SeasonInsertRequest();

        public AddSeason()
        {
            InitializeComponent();
        }

        private async void AddSeason_Load(object sender, EventArgs e)
        {
            //this.dataGridView1.DataSource = result;
            var result = await _episodeApiService.Get<List<MEpisode>>(new EpisodesSeasonRequest { isAssigned = false });
            foreach (var it in result)
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
            var episodes = new List<MEpisode>();
            foreach(ListViewItem item in items)
            {
                int id = Int32.Parse(item.Text);
                var episode = await _episodeApiService.GetById<MEpisode>(id);
                episodes.Add(episode);

            }

            _request.Episodes = episodes;

            await _seasonApiService.Insert<MSeason>(_request);


        
            MessageBox.Show("OK");

        }
    }
}

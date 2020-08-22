using fandom.Model.Models;
using fandom.Model.Requests;
using fandom.WindowsForms.Forms.Episode;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fandom.WindowsForms.Forms
{
    public partial class EpisodeForm : Form
    {
        public EpisodeForm()
        {
            InitializeComponent();
        }

        private static EpisodeForm seasonInstance;

        private readonly APIService _apiService = new APIService("Episode");

        public static EpisodeForm GetForm
        {
            get
            {
                if (seasonInstance == null || seasonInstance.IsDisposed)
                    seasonInstance = new EpisodeForm();
                return seasonInstance;
            }
        }

        private void addEpisodeButton_Click(object sender, EventArgs e)
        {
            var form = new AddEpisode();
            form.Show();
        }

        private async void EpisodeForm_Load(object sender, EventArgs e)
        {

            var result = await _apiService.Get<List<MEpisode>>(null);

            AddItems(result);

            this.button1.Enabled = true;
            this.button2.Enabled = true;
            this.button3.Enabled = true;

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            this.listView1.Items.Clear();
            await PopulateListView(false);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            this.listView1.Items.Clear();

            var result = await _apiService.Get<List<MEpisode>>(null);

            AddItems(result);
        }

        private async Task PopulateListView(bool option)
        {
            var result = await _apiService.Get<List<MEpisode>>(new EpisodesSeasonRequest { isAssigned = option });

            AddItems(result);
        }

        private void AddItems(List<MEpisode> result)
        {
            foreach (var it in result)
            {
                ListViewItem item = new ListViewItem(it.Id.ToString());
                item.SubItems.Add(it.Title);
                item.SubItems.Add(it.OverallNumberOfEpisode.ToString());
                item.SubItems.Add(it.AirDate.ToString("dd-MM-yyyy"));
                item.SubItems.Add(it.Season != null ? $"Season {it.Season.OrdinalNumber}" : "None");

                this.listView1.Items.Add(item);
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            var idStr = listView1.SelectedItems[0].Text;
            var id = Int32.Parse(idStr);

            var form = new DetailsEpisode(id);
            form.Show();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            this.listView1.Items.Clear();
            await PopulateListView(true);
        }
    }
}

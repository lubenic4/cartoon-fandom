using fandom.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
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

        }

        private async void EpisodeForm_Load(object sender, EventArgs e)
        {
            var result = await _apiService.GetAll<List<MEpisode>>();

            AddItems(result);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            this.listView1.Items.Clear();
            await PopulateListView(false);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            this.listView1.Items.Clear();
            await PopulateListView(true);
        }

        private async Task PopulateListView(bool option)
        {    
            var result = await _apiService.GetAll<List<MEpisode>>();

            if (!option)
            {
                result = result.Where(x => x.IsAssignedToSeason == false).ToList();
                AddItems(result);
            }
            else AddItems(result);
        }

        private void AddItems(List<MEpisode> result)
        {
            foreach (var it in result)
            {
                ListViewItem item = new ListViewItem(it.Id.ToString());
                item.SubItems.Add(it.Title);
                item.SubItems.Add(it.OverallNumberOfEpisode.ToString());
                item.SubItems.Add(it.AirDate.ToString("dd-MM-yyyy"));
                item.SubItems.Add(it.IsAssignedToSeason ? "Yes" : "No");

                this.listView1.Items.Add(item);
            }
        }
    }
}

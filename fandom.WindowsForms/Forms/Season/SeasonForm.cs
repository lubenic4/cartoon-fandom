using fandom.Model.Models;
using fandom.WindowsForms.Forms.Season;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.VisualStyles;

namespace fandom.WindowsForms.Forms
{
    public partial class SeasonForm : Form
    {
        private readonly APIService _apiService = new APIService("Season");

        private static SeasonForm seasonInstance;


        public SeasonForm()
        {
            InitializeComponent();
        }


        public static SeasonForm GetForm
        {
            get
            {
                if (seasonInstance == null || seasonInstance.IsDisposed)
                    seasonInstance = new SeasonForm();
                return seasonInstance;
            }
        }



        private async void SeasonForm_Load(object sender, EventArgs e)
        {
           await LoadSeasons();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new AddSeason();
            form.Show();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            var idStr = listView1.SelectedItems[0].Text;
            var id = Int32.Parse(idStr);
            

            var form = new DetailsSeason(id);
            form.Show();

        }

        public ListView seasonListView
        {
            get { return this.listView1; }
        }

        public async Task LoadSeasons()
        {
            var result = await _apiService.GetAll<List<MSeason>>();

            foreach (var it in result)
            {
                ListViewItem item = new ListViewItem(it.Id.ToString());
                item.SubItems.Add(it.OrdinalNumber.ToString());
                item.SubItems.Add(it.PremiereDate.ToString("dd-MM-yyyy"));
                item.SubItems.Add(it.NoOfEpisodes.ToString());

                this.listView1.Items.Add(item);
            }
        } 
    }
}

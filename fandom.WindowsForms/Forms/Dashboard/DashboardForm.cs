using fandom.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fandom.WindowsForms.Forms.Dashboard
{
    public partial class DashboardForm : Form
    {
        private readonly APIService _episodeApiService = new APIService("Episode");

        public DashboardForm()
        {
            InitializeComponent();
        }

        private static DashboardForm dashboardInstance;

        public static DashboardForm GetForm
        {
            get
            {
                if (dashboardInstance == null || dashboardInstance.IsDisposed)
                    dashboardInstance = new DashboardForm();
                return dashboardInstance;
            }
        }

        private async void DashboardForm_Load(object sender, EventArgs e)
        {
            var episodes = await _episodeApiService.Get<List<MEpisode>>();

            var totalViewCount = episodes.Sum(x => x.Viewcount);
            label3.Text = totalViewCount.ToString();

            var MostWathedEpisode = episodes.OrderByDescending(x => x.Viewcount).FirstOrDefault();
            label1.Text = MostWathedEpisode.Title;

            var MostRecentReleasedEpisode = episodes.Where(x => x.Season != null).OrderByDescending(x => x.Id).FirstOrDefault();
            label2.Text = MostRecentReleasedEpisode.Title;

            var chartEpisodes = episodes.Where(x => x.Season != null).OrderByDescending(x => x.Viewcount).Take(5).ToList();

            foreach (var item in chartEpisodes)
            {
                this.chart1.Series["Viewcount"].Points.AddXY(item.Title, item.Viewcount);
            }
        }
    }
}

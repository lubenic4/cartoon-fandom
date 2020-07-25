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

namespace fandom.WindowsForms.Forms.Season
{
    public partial class DetailsSeason : Form
    {
        private readonly int sId;
        private readonly APIService _apiService = new APIService("Season");


        public DetailsSeason(int id)
        {
            sId = id;
            InitializeComponent();
        }

        private async void DetailsSeason_Load(object sender, EventArgs e)
        {
            var result = await _apiService.GetById<MSeason>(sId);
            BindData(result);
        }

        private void BindData(MSeason season)
        {

            this.sOrdinalNumber.Text = $"SEASON {season.OrdinalNumber}";
            this.sPremiereDate.Text = $"Premiere date {season.PremiereDate.ToString("dd-MM-yy")}";
            this.sSummary.Text = season.Summary;
            this.sNoOfEpisodes.Text = $"({season.NoOfEpisodes} episodes)";
        }
    }
}

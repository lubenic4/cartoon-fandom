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
        public string sId { get;  }

        public DetailsSeason(string id)
        {
            sId = id;
            InitializeComponent();
        }

        private void DetailsSeason_Load(object sender, EventArgs e)
        {
            this.sName.Text = sId;
        }
    }
}

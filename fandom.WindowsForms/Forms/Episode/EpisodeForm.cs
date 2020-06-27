using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        public static EpisodeForm GetForm
        {
            get
            {
                if (seasonInstance == null || seasonInstance.IsDisposed)
                    seasonInstance = new EpisodeForm();
                return seasonInstance;
            }
        }
    }
}

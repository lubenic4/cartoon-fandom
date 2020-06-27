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
    public partial class SeasonForm : Form
    {
        public SeasonForm()
        {
            InitializeComponent();
        }

        private static SeasonForm seasonInstance;

        public static SeasonForm GetForm
        {
            get
            {
                if (seasonInstance == null || seasonInstance.IsDisposed)
                    seasonInstance = new SeasonForm();
                return seasonInstance;
            }
        }
    }
}

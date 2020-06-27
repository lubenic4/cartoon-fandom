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
    }
}

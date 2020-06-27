using fandom.WindowsForms.Forms.Dashboard;
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
    public partial class HomeMDI : Form
    {
        private int childFormNumber = 0;

        public HomeMDI()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }



        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void episodeLabel_Click(object sender, EventArgs e)
        {
            var form = EpisodeForm.GetForm;
            form.TopLevel = false;

            this.formPanel.Controls.Add(form);
            form.Show();
            form.BringToFront();

        }

        private void characterLabel_Click(object sender, EventArgs e)
        {
            var form = CharacterForm.GetForm;
            form.TopLevel = false;

            this.formPanel.Controls.Add(form);
            form.Show();
            form.BringToFront();
        }

        private void userLabel_Click(object sender, EventArgs e)
        {
            var form = UserForm.GetForm;
            form.TopLevel = false;

            this.formPanel.Controls.Add(form);
            form.Show();
            form.BringToFront();
        }

        private void seasonLabel_Click(object sender, EventArgs e)
        {
            var form = SeasonForm.GetForm;
            form.TopLevel = false;

            this.formPanel.Controls.Add(form);
            form.Show();
            form.BringToFront();
        }

        private void dashboardLabel_Click(object sender, EventArgs e)
        {
            var form = DashboardForm.GetForm;
            form.TopLevel = false;

            this.formPanel.Controls.Add(form);
            form.Show();
            form.BringToFront();
        }

        private void HomeMDI_Load(object sender, EventArgs e)
        {
            var form = DashboardForm.GetForm;
            form.TopLevel = false;

            this.formPanel.Controls.Add(form);
            form.Show();
            form.BringToFront();
        }
    }
}

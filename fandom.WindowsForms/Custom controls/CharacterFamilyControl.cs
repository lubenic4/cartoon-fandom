using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fandom.WindowsForms.Custom_controls
{
    public partial class CharacterFamilyControl : UserControl
    {
        public CharacterFamilyControl()
        {
            InitializeComponent();
        }

        #region Properties
        private string _Id;
        private string _CharacterLabel;
        private Image _Icon;

        [Category("Custom Properties")]
        public string CharacterLabel 
        {
            get { return _CharacterLabel; }
            set { _CharacterLabel = value; label1.Text = value; }
        }

        [Category("Custom Properties")]
        public Image Icon
        {
            get { return _Icon; }
            set { _Icon = value; pictureBox1.Image = value; }
        }

        [Category("Custom Properties")]
        public string Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        #endregion
    }
}

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
    public partial class CharacterForm : Form
    {
        public CharacterForm()
        {
            InitializeComponent();
        }

        private static CharacterForm characterInstance;

        public static CharacterForm GetForm
        {
            get
            {
                if (characterInstance == null || characterInstance.IsDisposed)
                    characterInstance = new CharacterForm();
                return characterInstance;
            }
        }
    }
}

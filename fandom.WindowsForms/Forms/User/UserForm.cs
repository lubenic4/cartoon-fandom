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
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
        }

        private static UserForm userInstance;

        public static UserForm GetForm
        {
            get
            {
                if (userInstance == null || userInstance.IsDisposed)
                    userInstance = new UserForm();
                return userInstance;
            }
        }
    }
}

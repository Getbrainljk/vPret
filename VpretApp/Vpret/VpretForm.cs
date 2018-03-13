using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Vpret
{
    public partial class VpretForm : UserControl//Telerik.WinControls.UI.RadForm
    {
        public VpretForm mainFormVpret { get; set; }
        protected UserManager currentUser = new UserManager();

        public VpretForm()
        {
            InitializeComponent();
            userLabel.Text = "Logged in as " +  currentUser.Username;
            userLabel.ForeColor = System.Drawing.Color.Black;
            
        }

        public void VpretForm_Load(object sender, EventArgs e)
        {
          
          
        }   
    }
}

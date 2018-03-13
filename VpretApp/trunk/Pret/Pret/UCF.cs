using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vpret;
using vPret;
using Telerik.WinControls.UI;
using System.Diagnostics;
using System.Data.SqlClient;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI.Export;
using System.Net.Mail;
using Microsoft.Reporting.WinForms;
using System.IO;
using System.Configuration;
using System.Collections;

namespace Pret
{
    // User Control Reception file
    public partial class UCF : UserControl
    {
        UCTechControl uctControl = new UCTechControl();
        UCTechReception uctReception = new UCTechReception();

        public UCF()
        {
            Log.UCF.Debug("UCF()");
            InitializeComponent();
            panel1.Controls.Add(uctReception);
            ReceptionBtn.BackColor = Color.Bisque;
            this.Dock = DockStyle.Fill;
        }

        private void ReceptionBtn_Click(object sender = null, EventArgs e = null)
        {
            ReceptionBtn.BackColor = Color.Bisque;
            ControlBtn.BackColor = Color.White;
            uctControl.Visible = false;
            uctReception.Visible = true;
            this.Dock = DockStyle.Fill;
        }

        private void ControlBtn_Click(object sender, EventArgs e)
        {
            panel1.Controls.Add(uctControl);
            uctReception.Visible = false;
            uctControl.Visible = true;
            ReceptionBtn.BackColor = Color.White;
            ControlBtn.BackColor = Color.Bisque;
            this.Dock = DockStyle.Fill;

        }
    }
}
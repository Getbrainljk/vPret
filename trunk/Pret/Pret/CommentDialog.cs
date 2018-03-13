using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using vPret;

namespace Pret
{
    /// <summary>
    /// ControlDialog to comment the loan
    /// </summary>
    public partial class CommentDialog : Telerik.WinControls.UI.RadForm
    {
        public string Comment = "";
        public int okPressed = 0;

        public CommentDialog()
        {
            InitializeComponent();
            okPressed = 0;
            Log.UCRP.Debug("DialogCommentaire() : STATUT : PASSED");
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Comment = TxtBoxCom.Text;
            okPressed = 1;
            this.Close();
            Log.UCRP.Debug("buttonOk() : STATUT : PASSED");
        }

        private void buttonAnnulate_Click(object sender, EventArgs e)
        {
            this.Close();
            Log.UCRP.Debug("buttonAnnulate() : STATUT : PASSED");
        }
    }
}

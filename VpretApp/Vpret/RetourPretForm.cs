using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vpret
{
    public class RetourPretForm : VpretForm
    {
        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // RetourPretForm
            // 
            this.AccessibleName = "RetourPretForm";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.Firebrick;
            this.ClientSize = new System.Drawing.Size(1014, 544);
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Name = "RetourPretForm";
            // 
            // 
            // 
            //this.RootElement.ApplyShapeToControl = true;
            this.Load += new System.EventHandler(this.RetourPretForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public  void RetourPretForm_Load(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Linq;
using System.Text;

namespace Pret
{
    /// <summary>
    ///  Basic button with some properties overrided
    /// </summary>
    public class RoundButton : Button
    {
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            GraphicsPath grPath = new GraphicsPath();
            grPath.AddEllipse(4, 4, this.Width - 8, this.Height -8);
            this.Region = new System.Drawing.Region(grPath);
            base.OnPaint(e);
        }
    }
}

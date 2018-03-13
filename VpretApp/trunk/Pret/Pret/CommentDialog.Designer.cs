namespace Pret
{
    partial class CommentDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommentDialog));
            this.labelCom = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonAnnulate = new System.Windows.Forms.Button();
            this.TxtBoxCom = new Telerik.WinControls.UI.RadTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBoxCom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // labelCom
            // 
            this.labelCom.AutoSize = true;
            this.labelCom.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCom.Location = new System.Drawing.Point(36, 9);
            this.labelCom.Name = "labelCom";
            this.labelCom.Size = new System.Drawing.Size(112, 21);
            this.labelCom.TabIndex = 0;
            this.labelCom.Text = "Commentaire :";
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(40, 96);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(201, 27);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonAnnulate
            // 
            this.buttonAnnulate.Location = new System.Drawing.Point(297, 96);
            this.buttonAnnulate.Name = "buttonAnnulate";
            this.buttonAnnulate.Size = new System.Drawing.Size(201, 27);
            this.buttonAnnulate.TabIndex = 3;
            this.buttonAnnulate.Text = "Annuler";
            this.buttonAnnulate.UseVisualStyleBackColor = true;
            this.buttonAnnulate.Click += new System.EventHandler(this.buttonAnnulate_Click);
            // 
            // TxtBoxCom
            // 
            this.TxtBoxCom.AutoSize = false;
            this.TxtBoxCom.Location = new System.Drawing.Point(40, 33);
            this.TxtBoxCom.Multiline = true;
            this.TxtBoxCom.Name = "TxtBoxCom";
            this.TxtBoxCom.Size = new System.Drawing.Size(458, 44);
            this.TxtBoxCom.TabIndex = 4;
            // 
            // DialogCommentaire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 135);
            this.Controls.Add(this.TxtBoxCom);
            this.Controls.Add(this.buttonAnnulate);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.labelCom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DialogCommentaire";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "    Ajout de commentaire";
            this.ThemeName = "Windows8";
            ((System.ComponentModel.ISupportInitialize)(this.TxtBoxCom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCom;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonAnnulate;
        private Telerik.WinControls.UI.RadTextBox TxtBoxCom;
    }
}

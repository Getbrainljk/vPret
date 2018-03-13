namespace Pret
{
    partial class UCTechReception
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewRelation gridViewRelation1 = new Telerik.WinControls.UI.GridViewRelation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCTechReception));
            this.gridViewTemplate1 = new Telerik.WinControls.UI.GridViewTemplate();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.radListControl2 = new Telerik.WinControls.UI.RadListControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.radListControl1 = new Telerik.WinControls.UI.RadListControl();
            this.LblObservation = new System.Windows.Forms.Label();
            this.tBoxObservation = new System.Windows.Forms.RichTextBox();
            this.BtnValidate = new Telerik.WinControls.UI.RadButton();
            this.radDropDownListProvider = new Telerik.WinControls.UI.RadDropDownList();
            this.LblDate = new System.Windows.Forms.Label();
            this.LblProvider = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.BtnPhoto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTemplate1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radListControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radListControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnValidate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDropDownListProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // gridViewTemplate1
            // 
            this.gridViewTemplate1.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom;
            this.gridViewTemplate1.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "Accessoire";
            gridViewTextBoxColumn1.HeaderText = "Accessoire";
            gridViewTextBoxColumn1.Name = "Accessoire";
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "PN";
            gridViewTextBoxColumn2.HeaderText = "P/N";
            gridViewTextBoxColumn2.Name = "PN";
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "CommentaireA";
            gridViewTextBoxColumn3.HeaderText = "Commentaire Accessoire";
            gridViewTextBoxColumn3.Name = "CommentaireA";
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "Produit";
            gridViewTextBoxColumn4.HeaderText = "Produit";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Name = "Produit";
            this.gridViewTemplate1.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            // 
            // radGridView1
            // 
            this.radGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGridView1.AutoScroll = true;
            this.radGridView1.BackColor = System.Drawing.Color.Orange;
            this.radGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.radGridView1.EnableHotTracking = false;
            this.radGridView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGridView1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radGridView1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radGridView1.Location = new System.Drawing.Point(38, 43);
            // 
            // 
            // 
            this.radGridView1.MasterTemplate.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom;
            this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "Produit";
            gridViewTextBoxColumn5.HeaderText = "Produit";
            gridViewTextBoxColumn5.Name = "Produit";
            gridViewTextBoxColumn5.Width = 234;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "SN";
            gridViewTextBoxColumn6.HeaderText = "Numéro de série";
            gridViewTextBoxColumn6.Name = "SN";
            gridViewTextBoxColumn6.Width = 234;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "CommentaireP";
            gridViewTextBoxColumn7.HeaderText = "Commentaire Produit";
            gridViewTextBoxColumn7.Name = "CommentaireP";
            gridViewTextBoxColumn7.Width = 236;
            this.radGridView1.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7});
            this.radGridView1.MasterTemplate.EnableGrouping = false;
            this.radGridView1.MasterTemplate.Templates.AddRange(new Telerik.WinControls.UI.GridViewTemplate[] {
            this.gridViewTemplate1});
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.Padding = new System.Windows.Forms.Padding(1);
            gridViewRelation1.ChildColumnNames = ((System.Collections.Specialized.StringCollection)(resources.GetObject("gridViewRelation1.ChildColumnNames")));
            gridViewRelation1.ChildTemplate = this.gridViewTemplate1;
            gridViewRelation1.ParentColumnNames = ((System.Collections.Specialized.StringCollection)(resources.GetObject("gridViewRelation1.ParentColumnNames")));
            gridViewRelation1.ParentTemplate = this.radGridView1.MasterTemplate;
            gridViewRelation1.RelationName = "P/A relation";
            this.radGridView1.Relations.AddRange(new Telerik.WinControls.UI.GridViewRelation[] {
            gridViewRelation1});
            this.radGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radGridView1.ShowGroupPanel = false;
            this.radGridView1.Size = new System.Drawing.Size(745, 291);
            this.radGridView1.TabIndex = 38;
            this.radGridView1.Text = "radGridView1";
            // 
            // radListControl2
            // 
            this.radListControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radListControl2.Location = new System.Drawing.Point(813, 252);
            this.radListControl2.Name = "radListControl2";
            this.radListControl2.Size = new System.Drawing.Size(187, 53);
            this.radListControl2.TabIndex = 41;
            this.radListControl2.Text = "radListControl2";
            this.radListControl2.ThemeName = "Office2007Black";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(881, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 24);
            this.label1.TabIndex = 39;
            this.label1.Text = "Ajouter  BL ";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(881, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 24);
            this.label5.TabIndex = 28;
            this.label5.Text = "Ajouter fichier";
            // 
            // radListControl1
            // 
            this.radListControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radListControl1.Location = new System.Drawing.Point(813, 85);
            this.radListControl1.Name = "radListControl1";
            this.radListControl1.Size = new System.Drawing.Size(187, 53);
            this.radListControl1.TabIndex = 37;
            this.radListControl1.Text = "radListControl1";
            this.radListControl1.ThemeName = "Office2007Black";
            // 
            // LblObservation
            // 
            this.LblObservation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LblObservation.AutoSize = true;
            this.LblObservation.Font = new System.Drawing.Font("Maiandra GD", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblObservation.Location = new System.Drawing.Point(32, 375);
            this.LblObservation.Name = "LblObservation";
            this.LblObservation.Size = new System.Drawing.Size(187, 35);
            this.LblObservation.TabIndex = 35;
            this.LblObservation.Text = "Observation :";
            // 
            // tBoxObservation
            // 
            this.tBoxObservation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tBoxObservation.EnableAutoDragDrop = true;
            this.tBoxObservation.Font = new System.Drawing.Font("Maiandra GD", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBoxObservation.Location = new System.Drawing.Point(229, 373);
            this.tBoxObservation.Name = "tBoxObservation";
            this.tBoxObservation.Size = new System.Drawing.Size(554, 53);
            this.tBoxObservation.TabIndex = 30;
            this.tBoxObservation.Text = "";
            // 
            // BtnValidate
            // 
            this.BtnValidate.AccessibleDescription = "buttonValidate";
            this.BtnValidate.AccessibleName = "buttonValidate";
            this.BtnValidate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnValidate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BtnValidate.Location = new System.Drawing.Point(813, 373);
            this.BtnValidate.Name = "BtnValidate";
            this.BtnValidate.Size = new System.Drawing.Size(208, 53);
            this.BtnValidate.TabIndex = 29;
            this.BtnValidate.Text = "Valider";
            this.BtnValidate.Click += new System.EventHandler(this.buttonValidate_Click);
            // 
            // radDropDownListProvider
            // 
            this.radDropDownListProvider.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.radDropDownListProvider.Location = new System.Drawing.Point(159, 1);
            this.radDropDownListProvider.Name = "radDropDownListProvider";
            this.radDropDownListProvider.Size = new System.Drawing.Size(217, 20);
            this.radDropDownListProvider.TabIndex = 34;
            // 
            // LblDate
            // 
            this.LblDate.AutoSize = true;
            this.LblDate.Font = new System.Drawing.Font("Maiandra GD", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDate.Location = new System.Drawing.Point(450, -1);
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(60, 22);
            this.LblDate.TabIndex = 33;
            this.LblDate.Text = "Date :";
            // 
            // LblProvider
            // 
            this.LblProvider.AutoSize = true;
            this.LblProvider.Font = new System.Drawing.Font("Maiandra GD", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblProvider.Location = new System.Drawing.Point(34, 1);
            this.LblProvider.Name = "LblProvider";
            this.LblProvider.Size = new System.Drawing.Size(116, 22);
            this.LblProvider.TabIndex = 32;
            this.LblProvider.Text = "Fournisseur :";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(516, 1);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(219, 20);
            this.dateTimePicker1.TabIndex = 31;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(813, 183);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 42);
            this.button1.TabIndex = 40;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonBL);
            // 
            // BtnPhoto
            // 
            this.BtnPhoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnPhoto.Image = ((System.Drawing.Image)(resources.GetObject("BtnPhoto.Image")));
            this.BtnPhoto.Location = new System.Drawing.Point(813, 23);
            this.BtnPhoto.Name = "BtnPhoto";
            this.BtnPhoto.Size = new System.Drawing.Size(62, 44);
            this.BtnPhoto.TabIndex = 36;
            this.BtnPhoto.UseVisualStyleBackColor = true;
            this.BtnPhoto.Click += new System.EventHandler(this.buttonPhoto);
            // 
            // UCTechReception
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.radListControl2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.radGridView1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.radListControl1);
            this.Controls.Add(this.BtnPhoto);
            this.Controls.Add(this.LblObservation);
            this.Controls.Add(this.tBoxObservation);
            this.Controls.Add(this.BtnValidate);
            this.Controls.Add(this.radDropDownListProvider);
            this.Controls.Add(this.LblDate);
            this.Controls.Add(this.LblProvider);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "UCTechReception";
            this.Size = new System.Drawing.Size(1053, 445);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTemplate1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radListControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radListControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnValidate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDropDownListProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadListControl radListControl2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private Telerik.WinControls.UI.GridViewTemplate gridViewTemplate1;
        private System.Windows.Forms.Label label5;
        private Telerik.WinControls.UI.RadListControl radListControl1;
        private System.Windows.Forms.Button BtnPhoto;
        private System.Windows.Forms.Label LblObservation;
        private System.Windows.Forms.RichTextBox tBoxObservation;
        private Telerik.WinControls.UI.RadButton BtnValidate;
        private Telerik.WinControls.UI.RadDropDownList radDropDownListProvider;
        private System.Windows.Forms.Label LblDate;
        private System.Windows.Forms.Label LblProvider;
        public System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}

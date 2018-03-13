using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vPret;
using Telerik.WinControls.UI;
using System.Data.SqlClient;
using Vpret;

namespace Pret
{
    /// <summary>
    /// Tech control 
    /// </summary>
    public partial class UCTechControl : UserControl
    {
        string bQuery = @"SELECT     LOAN.LOA_ID as 'LOAID',
                                     LOAN.LOA_CP as 'N°CP',
                                     LOAN.LOA_NUM_CLIENT as 'N°Client',
                                     LOAN.LOA_DATE_RETOUR as 'Date retour prévue',
                                     LOAN.LOA_PROVIDER as 'Fournisseur',
                                     LOAN.LOA_COMM_G as 'Commentaire Prêt' ,
			                         LOAN.LOA_DATE AS 'Date de contrôle'
                                     FROM        LOAN 
                                     ;
                        SELECT      PRODUCT.PRO_ID as 'PROID',
                                    PRODUCT.PRO_LOA_ID_FK AS 'PROLOAIDFK',
			                        PRODUCT.PRO_NAME as 'Nom Produit', 
			                        PRODUCT.PRO_SN as 'N°Série Produit', 
			                        PRODUCT.PRO_COM as 'Commentaire Produit' 

                        FROM        PRODUCT

                    ;
                		SELECT      ACCESSORIES.ACC_NAME as 'Nom Accessoire', 
			                        ACCESSORIES.ACC_PN as 'PN Accessoire',
                                    ACCESSORIES.ACC_COM as 'Commentaire Accessoire',
                                    ACCESSORIES.ACC_PRO_ID_FK AS 'ACCPROIDFK'
                        FROM        ACCESSORIES;";

        public UCTechControl()
        {
            InitializeComponent();
            FillDataLoanToControl(bQuery);
            this.Dock = DockStyle.Fill;
            this.radGridViewControlTech.Visible = false;
            this.Controls.Add(label1);
            label1.Text = "EN CONSTRUCTION";
        }
        
        private void IterateChildRowsAndAddProduct(GridViewHierarchyRowInfo rowInfo)
        {
            GridViewInfo currentView = rowInfo.ActiveView;
            foreach (GridViewInfo view in rowInfo.Views)
            {
                rowInfo.ActiveView = view;
                foreach (GridViewRowInfo row in rowInfo.ChildRows)
                {
                     IQueryable<PRODUCT> products = (from PRODUCT in VpretContext.Instance.vPretContext.PRODUCT
                                                    where PRODUCT.PRO_LOA_ID_FK.Equals(row.Cells["PROLOAIDFK"].Value.ToString())
                                                    select PRODUCT);
                if (products != null)
                {
                    foreach (PRODUCT product in products)
                    {
                        if (product.PRO_STATE == 1)
                        {
                            // not working
                            row.Cells["Nom Produit"].Style.BackColor = Color.Green;
                            row.Cells["N°Série Produit"].Style.BackColor = Color.Green;
                            row.Cells["Commentaire Produit"].Style.BackColor = Color.Green;
                        }
                        else
                        {
                            row.Cells["Nom Produit"].Style.BackColor = Color.Red;
                            row.Cells["N°Série Produit"].Style.BackColor = Color.Red;
                            row.Cells["Commentaire Produit"].Style.BackColor = Color.Green;
                        }
                    }
                }
                VpretContext.Instance.vPretContext.SubmitChanges();
                }
            }
            rowInfo.ActiveView = currentView;
            Log.UCRP.Debug("IterateChildRowsAndAddProduct(GridViewHierarchyRowInfo rowInfo, int idLoan) : STATUT : PASSED");
        }
    
        private void IterateProduct(GridViewRowInfo rowInfo, int idLoan)
        {
           
            
            Log.UCRP.Debug("IterateChildRowsAndAddProduct(GridViewHierarchyRowInfo rowInfo, int idLoan) : STATUT : PASSED");
        }

        private void FillDataLoanToControl(string query, Dictionary<string, string> param = null)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Properties.Settings.Default.vPretConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        if (param != null)
                            foreach (KeyValuePair<string, string> sqlparam in param)
                                cmd.Parameters.Add(new SqlParameter(sqlparam.Key, sqlparam.Value));
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            using (DataSet ds = new DataSet())
                            {
                                cmd.ExecuteNonQuery();
                                sda.Fill(ds);
                                radGridViewControlTech.DataSource = ds.Tables[0];

                                GridViewCheckBoxColumn checkbox = new GridViewCheckBoxColumn();
                                checkbox.Name = "ValiderControle";
                                checkbox.FieldName = "ValiderControle";
                                checkbox.HeaderText = "Valider Contrôle";
                                checkbox.DataType = typeof(int);
                                checkbox.EditMode = EditMode.OnValueChange;
                                radGridViewControlTech.MasterTemplate.Columns.Add(checkbox);
                                radGridViewControlTech.MasterTemplate.Columns["LOAID"].IsVisible = false;
                                radGridViewControlTech.MasterTemplate.BestFitColumns();
                                radGridViewControlTech.AllowAddNewRow = false;
                                radGridViewControlTech.AllowColumnResize = true;
                                radGridViewControlTech.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;

                                /*
                                 * Here the relation between Loan & product
                                 * */

                                GridViewTemplate template1 = new GridViewTemplate();
                                template1.AllowAddNewRow = false;
                                template1.DataSource = ds.Tables[1];
                                radGridViewControlTech.MasterTemplate.Templates.Add(template1);
                                GridViewRelation relation1 = new GridViewRelation(radGridViewControlTech.MasterTemplate);
                                relation1.ChildTemplate = template1;
                                relation1.RelationName = "Produit / Pret";
                                relation1.ParentColumnNames.Add("LOAID");
                                relation1.ChildColumnNames.Add("PROLOAIDFK");
                                radGridViewControlTech.Templates[0].Columns["PROLOAIDFK"].IsVisible = false;
                                radGridViewControlTech.Templates[0].Columns["PROID"].IsVisible = false;
                                radGridViewControlTech.Templates[0].AllowAutoSizeColumns = true;
                                radGridViewControlTech.Templates[0].AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                                radGridViewControlTech.Templates[0].BestFitColumns();
                                radGridViewControlTech.Relations.Add(relation1);

                                /**
                                 *   Here the relation between Product & accessories
                                 **/

                                // Can't use radgridview.MasterTemplates.template for some reasons

                                GridViewTemplate template2 = new GridViewTemplate();
                                template2.AllowAddNewRow = false;
                                template2.DataSource = ds.Tables[2];
                                template1.Templates.Add(template2);
                                GridViewRelation relation2 = new GridViewRelation(template1);
                                relation2.ChildTemplate = template2;
                                relation2.RelationName = "Produit / Accessoire";
                                relation2.ParentColumnNames.Add("PROID");
                                relation2.ChildColumnNames.Add("ACCPROIDFK");
                                template2.Columns["ACCPROIDFK"].IsVisible = false;
                                template2.AllowAutoSizeColumns = true;
                                template2.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                                template2.BestFitColumns();
                                radGridViewControlTech.Relations.Add(relation2);

                                template2.Columns["Nom Accessoire"].ReadOnly = true;
                                template2.Columns["PN Accessoire"].ReadOnly = true;
                                template2.Columns["Commentaire Accessoire"].ReadOnly = true;
                                template1.Columns["Nom Produit"].ReadOnly = true;
                                template1.Columns["N°Série Produit"].ReadOnly = true;
                                template1.Columns["Commentaire Produit"].ReadOnly = true;

                                template1.AllowDeleteRow = false;
                                template2.AllowDeleteRow = false;

                                radGridViewControlTech.MasterTemplate.AllowDeleteRow = false;

                                foreach (GridViewColumn row in radGridViewControlTech.Columns)
                                {
                                    if (row.FieldName.Equals("ValiderControle") == false)
                                        row.ReadOnly = true;
                                }
                                foreach (GridViewRowInfo rowInfo in radGridViewControlTech.Rows)
                                {
                                    IQueryable<LOAN> loans = (from LOAN in VpretContext.Instance.vPretContext.LOAN
                                                              where LOAN.LOA_ID.Equals(rowInfo.Cells["LOAID"].Value.ToString())
                                                              select LOAN);
                                    if (loans != null)
                                    {
                                        foreach (LOAN loan in loans)
                                        {
                                            GridViewDataRowInfo row = rowInfo as GridViewDataRowInfo;
                                            GridViewHierarchyRowInfo hierarchyRow = row as GridViewHierarchyRowInfo;
                                            if (hierarchyRow != null)
                                                IterateChildRowsAndAddProduct(hierarchyRow);
                                            if (loan.LOA_STATE == 1)
                                            {
                                                rowInfo.Cells["ValiderControle"].Value = CheckState.Checked;
                                            }
                                        }
                                    }
                                    
                                }
                            }
                        }
                    }
                }
                radGridViewControlTech.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                radGridViewControlTech.Templates[0].AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                this.Dock = DockStyle.Fill;
            }
            catch (Exception ex)
            {
                Log.UCTechControle.Error("FillDataLoanToControl - Exception: " + ex.ToString());
            }
            finally
            {
                Log.UCTechControle.Debug("FillDataLoanToControl : STATUT : PASSED");
            }
        }

        private void radGridView1_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            DataRowView cRow = this.radGridViewControlTech.CurrentRow.DataBoundItem as DataRowView;
            DataRow currentRow = cRow.Row;
            GridViewDataRowInfo rrow = this.radGridViewControlTech.CurrentRow as GridViewDataRowInfo;

            if (radGridViewControlTech.CurrentCell != null)
            {
                if (radGridViewControlTech.CurrentCell.Value.Equals(0))
                {
                    try
                    {
                        IQueryable<LOAN> loans = (from LOAN in VpretContext.Instance.vPretContext.LOAN
                                                  where LOAN.LOA_ID.Equals(currentRow["LOAID"].ToString())
                                                  select LOAN);
                        if (loans != null)
                        {
                            foreach (LOAN loan in loans)
                                loan.LOA_STATE = 0;
                            VpretContext.Instance.vPretContext.SubmitChanges();
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.UCRP.Error("Exception SQl radGridView1_CellValueChanged : " + ex.ToString());
                    }
                    finally
                    {
                        Log.UCRP.Debug("radGridViewRecepProduit_ValueChanged() - Loans deleted");
                    }
                }
                else if (radGridViewControlTech.CurrentCell.Value.Equals(1))
                {
                    try
                    {
                        IQueryable<LOAN> loans = (from LOAN in VpretContext.Instance.vPretContext.LOAN
                                                  where LOAN.LOA_ID.Equals(currentRow["LOAID"].ToString())
                                                  select LOAN);

                        if (loans != null)
                        {
                            foreach (LOAN loan in loans)
                                loan.LOA_STATE = 1;
                            VpretContext.Instance.vPretContext.SubmitChanges();
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.UCRP.Error("Exception SQl radGridViewRecepProduit_ValueChanged() : " + ex.ToString());
                    }
                    finally
                    {
                        Log.UCRP.Debug("radGridViewRecepProduit_ValueChanged() : STATUT : PASSED");
                    }
                }
            }
        }

        private void radGridViewControlTech_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
        {
           GridDataCellElement cell = e.ContextMenuProvider as GridDataCellElement;

            // deny custom contextmenu for non cell elements clicked 
           if (cell == null) 
               return;

            RadMenuItem customMenuItemValidateArrival = new RadMenuItem();
            customMenuItemValidateArrival.Text = "Valider arrivée de cette objet";
            customMenuItemValidateArrival.ForeColor = Color.Green;            
            RadMenuSeparatorItem separator = new RadMenuSeparatorItem();
            e.ContextMenu.Items.Add(separator);
            e.ContextMenu.Items.Add(customMenuItemValidateArrival);

            customMenuItemValidateArrival.Click += new EventHandler(customMenuItemValidateArrival_Click);
           
            RadMenuItem customMenuItemAnnulateArrival = new RadMenuItem();
            customMenuItemAnnulateArrival.Text = "Annuler arrivée de cette objet";
            customMenuItemAnnulateArrival.ForeColor = Color.Red;
            e.ContextMenu.Items.Add(customMenuItemAnnulateArrival);

            customMenuItemAnnulateArrival.Click += new EventHandler(customMenuItemAnnulateArrival_Click);
        }

        private void customMenuItemValidateArrival_Click(object sender, EventArgs e)
        {
  
        }

        private void customMenuItemAnnulateArrival_Click(object sender, EventArgs e)
        {

        }

        private void radGridViewControlTech_ViewCellFormatting(object sender, CellFormattingEventArgs e)
        {

        }
    }
}
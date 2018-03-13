using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using vPret;
using Pret;
using System.Data.SqlClient;
using Telerik.WinControls.Data;
using Vpret;
using System.Globalization;
using Telerik.WinControls.Primitives;

namespace Pret
{
    // User Control Reception Pret
    public partial class UCRP : UserControl
    {
        public UCRP()
        {
            Log.UCRP.Debug("UCRP()");

            InitializeComponent();
            radGridViewCutomerReturn.EnableGrouping = false;
            radGridViewProductReturn.EnableGrouping = false;

            Log.UCRP.Debug("UCRP Init component passed");
        }


        /// <summary>
        ///  This function create & set all values for Reception of Products
        /// </summary>
        /// <param name="query"></param>
        /// <param name="param"></param>
        private void FillDataReceptionProduct(string query, Dictionary<string, string> param = null)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Properties.Settings.Default.x3v5sConnectionString))
                {
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
                                sda.Fill(ds);
                                radGridViewProductReturn.DataSource = ds.Tables[0];
                                GridViewCheckBoxColumn checkbox = new GridViewCheckBoxColumn();
                                checkbox.DataType = typeof(int);
                                checkbox.EditMode = EditMode.OnValueChange;
                                checkbox.Name = "ValiderArrivee1";
                                checkbox.FieldName = "ValiderArrivee";
                                checkbox.HeaderText = "Valider l'arrivée";
                                radGridViewProductReturn.MasterTemplate.Columns.Add(checkbox);
                                radGridViewProductReturn.MasterTemplate.BestFitColumns();
                                radGridViewProductReturn.AllowAddNewRow = false;
                                radGridViewProductReturn.AllowColumnResize = true;


                                GridViewTemplate template = new GridViewTemplate();
                                template.AllowAddNewRow = false;
                                template.DataSource = ds.Tables[1];
                                radGridViewProductReturn.MasterTemplate.Templates.Add(template);
                                GridViewRelation relation = new GridViewRelation(radGridViewProductReturn.MasterTemplate);
                                relation.ChildTemplate = template;
                                relation.RelationName = "Produit / Pret";
                                relation.ParentColumnNames.Add("N° CP");
                                relation.ChildColumnNames.Add("N° CP");

                                //  radGridViewRecepFournisseur.MasterTemplate.Columns["N° CP"].IsVisible = false;
                                radGridViewProductReturn.Templates[0].Columns["N° CP"].IsVisible = false;
                                radGridViewProductReturn.Templates[0].AllowAutoSizeColumns = true;
                                radGridViewProductReturn.Templates[0].BestFitColumns();
                                radGridViewProductReturn.Relations.Add(relation);

                                template.Columns["Produit"].ReadOnly = true;
                                template.Columns["Détail"].ReadOnly = true;
                                template.Columns["N°Série"].ReadOnly = true;

                                template.AllowDeleteRow = false;
                                radGridViewProductReturn.MasterTemplate.AllowDeleteRow = false;
                                
                                foreach (GridViewColumn row in radGridViewProductReturn.Columns)
                                {
                                    if (row.FieldName.Equals("ValiderArrivee") == false)
                                        row.ReadOnly = true;
                                }

                                foreach (GridViewRowInfo rowInfo in radGridViewProductReturn.Rows)
                                {
                                    IQueryable<LOAN> loans = (from LOAN in VpretContext.Instance.vPretContext.LOAN
                                                              where LOAN.LOA_CP.Equals(rowInfo.Cells["N° CP"].Value.ToString())
                                                              select LOAN);
                                    if (loans != null)
                                    {
                                        foreach (LOAN loan in loans)
                                        {
                                            if (loan.LOA_STATE != null)
                                                if (loan.LOA_STATE == 1)
                                                {
                                                    rowInfo.Cells["ValiderArrivee1"].Value = CheckState.Checked;
                                                }
                                        }
                                    }
                                }
                                radGridViewProductReturn.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                                radGridViewProductReturn.Templates[0].AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.None;

                                radGridViewProductReturn.AutoScroll = true;
                                radGridViewProductReturn.MasterTemplate.HorizontalScrollState = ScrollState.AlwaysShow;
                                radGridViewProductReturn.MasterTemplate.Templates[0].HorizontalScrollState = ScrollState.AlwaysShow;
                                radGridViewProductReturn.MasterTemplate.AutoGenerateColumns = true;
                                radGridViewProductReturn.MasterTemplate.Templates[0].AutoGenerateColumns = true;
                                radGridViewProductReturn.Templates[0].BestFitColumns();
                                
                                this.Dock = DockStyle.Fill;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.UCRP.Error("FillDataRadGridRecepProduit() - Exception: " + ex.ToString());
            }
            finally
            {
                Log.UCRP.Debug("FillDataRadGridRecepProduit() : STATUT : PASSED");
            }
        }

        /// <summary>
        ///  This function create & set all values for Retour Client
        /// </summary>
        /// <param name="query"></param>
        /// <param name="param"></param>
        private void FillDataCustomerReturn(string query, Dictionary<string, string> param = null)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Properties.Settings.Default.x3v5sConnectionString))
                {
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
                                sda.Fill(ds);
                                radGridViewCutomerReturn.DataSource = ds.Tables[0];
                                GridViewCheckBoxColumn checkbox = new GridViewCheckBoxColumn();
                                checkbox.DataType = typeof(int);
                                checkbox.EditMode = EditMode.OnValueChange;
                                checkbox.Name = "ValiderArrivee2";
                                checkbox.FieldName = "ValiderArrivee";
                                checkbox.HeaderText = "Valider l'arrivée";
                                radGridViewCutomerReturn.MasterTemplate.Columns.Add(checkbox);
                                radGridViewCutomerReturn.AllowAddNewRow = false;
                                radGridViewCutomerReturn.AllowColumnResize = true;
                                GridViewTemplate template = new GridViewTemplate();
                                template.AllowAddNewRow = false;
                                template.DataSource = ds.Tables[1];
                                radGridViewCutomerReturn.MasterTemplate.Templates.Add(template);
                                GridViewRelation relation = new GridViewRelation(radGridViewCutomerReturn.MasterTemplate);
                                relation.ChildTemplate = template;
                                relation.RelationName = "Produit / Pret";
                                relation.ParentColumnNames.Add("N° CP");
                                relation.ChildColumnNames.Add("N° CP");

                                radGridViewCutomerReturn.Templates[0].Columns["N° CP"].IsVisible = false;
                                radGridViewCutomerReturn.Templates[0].AllowAutoSizeColumns = true;
                                radGridViewCutomerReturn.Relations.Add(relation);

                                template.Columns["Produit"].ReadOnly = true;
                                template.Columns["Détail"].ReadOnly = true;
                                template.AllowDeleteRow = false;
                                radGridViewCutomerReturn.MasterTemplate.AllowDeleteRow = false;
                                
                                foreach (GridViewColumn row in radGridViewCutomerReturn.Columns)
                                {
                                    if (row.FieldName.Equals("ValiderArrivee") == false)
                                        row.ReadOnly = true;
                                }
                                
                                foreach (GridViewRowInfo rowInfo in radGridViewCutomerReturn.Rows)
                                {
                                    IQueryable<LOAN> loans = (from LOAN in VpretContext.Instance.vPretContext.LOAN
                                                              where LOAN.LOA_CP.Equals(rowInfo.Cells["N° CP"].Value.ToString())
                                                              select LOAN);
                                    if (loans != null)
                                    {
                                        foreach (LOAN loan in loans)
                                        {
                                            if (loan.LOA_STATE != null)
                                                if (loan.LOA_STATE == 1)
                                                {
                                                    rowInfo.Cells["ValiderArrivee2"].Value = CheckState.Checked;
                                                }
                                        }
                                    }
                                }
                                
                                radGridViewCutomerReturn.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
                                radGridViewCutomerReturn.Templates[0].AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.None;
                                
                                radGridViewCutomerReturn.AutoScroll = true;
                                radGridViewCutomerReturn.MasterTemplate.HorizontalScrollState = ScrollState.AlwaysShow;
                                radGridViewCutomerReturn.MasterTemplate.Templates[0].HorizontalScrollState = ScrollState.AlwaysShow;
                                radGridViewCutomerReturn.MasterTemplate.AutoGenerateColumns = true;
                                radGridViewCutomerReturn.MasterTemplate.Templates[0].AutoGenerateColumns = true;
                                radGridViewCutomerReturn.Templates[0].BestFitColumns();

                                this.Dock = DockStyle.Fill;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.UCRP.Error("FillDataRadGridRecepProduit() - Exception: " + ex.ToString());
            }
            finally
            {
                Log.UCRP.Debug("FillDataRadGridRecepProduit() : STATUT : PASSED");
            }
        }

        private void UCRP_Load(object sender, EventArgs e)
        {
            string queryProductReturn = @"SELECT VINGENIERI.SORDER.[SOHNUM_0] AS 'N° CP', VINGENIERI.SORDER.[BPCINV_0] AS 'N° de Client', VINGENIERI.SORDER.[BPINAM_0] AS 'Client', VINGENIERI.SORDER.[ORDDAT_0] AS 'Date CP', VINGENIERI.SORDER.[LNDRTNDAT_0] AS 'Date retour prévue'	
                                        FROM VINGENIERI.SORDER
                                        Inner join VINGENIERI.[SORDERQ] on VINGENIERI.SORDER.[SOHNUM_0] = VINGENIERI.[SORDERQ].[SOHNUM_0]
                                        inner join [VINGENIERI].[ITMMASTER] on [VINGENIERI].[SORDERQ].[ITMREF_0]=[VINGENIERI].[ITMMASTER].[ITMREF_0]
                                        left join [VINGENIERI].[TEXCLOB] on [VINGENIERI].[TEXCLOB].[CODE_0]=[VINGENIERI].[SORDERQ].[SOQTEX_0]
                                        WHERE VINGENIERI.SORDER.SOHCAT_0 = 2 AND VINGENIERI.SORDER.DLVSTA_0 = 1  
                                        group by VINGENIERI.SORDER.[SOHNUM_0], VINGENIERI.SORDER.[BPCINV_0], VINGENIERI.SORDER.[BPINAM_0], VINGENIERI.SORDER.[ORDDAT_0], VINGENIERI.SORDER.[LNDRTNDAT_0]
                                        order by VINGENIERI.SORDER.[LNDRTNDAT_0] asc
                                        ;
                                        SELECT VINGENIERI.SORDER.[SOHNUM_0] AS 'N° CP', VINGENIERI.ITMMASTER.ITMDES1_0 as 'Produit', [VINGENIERI].[TEXCLOB].[TEXTE_0] as 'Détail', VINGENIERI.[SORDERQ].DEMNUM_0 as 'N°Série'
                                        FROM VINGENIERI.SORDER
                                        Inner join VINGENIERI.[SORDERQ] on VINGENIERI.SORDER.[SOHNUM_0] = VINGENIERI.[SORDERQ].[SOHNUM_0]
                                        inner join [VINGENIERI].[ITMMASTER] on [VINGENIERI].[SORDERQ].[ITMREF_0]=[VINGENIERI].[ITMMASTER].[ITMREF_0]
                                        left join [VINGENIERI].[TEXCLOB] on [VINGENIERI].[TEXCLOB].[CODE_0]=[VINGENIERI].[SORDERQ].[SOQTEX_0]
                                        WHERE VINGENIERI.SORDER.[SOHNUM_0] IN (												
	                                        SELECT VINGENIERI.SORDER.[SOHNUM_0]
	                                        FROM VINGENIERI.SORDER
	                                        Inner join VINGENIERI.[SORDERQ] on VINGENIERI.SORDER.[SOHNUM_0] = VINGENIERI.[SORDERQ].[SOHNUM_0]
	                                        inner join [VINGENIERI].[ITMMASTER] on [VINGENIERI].[SORDERQ].[ITMREF_0]=[VINGENIERI].[ITMMASTER].[ITMREF_0]
	                                        left join [VINGENIERI].[TEXCLOB] on [VINGENIERI].[TEXCLOB].[CODE_0]=[VINGENIERI].[SORDERQ].[SOQTEX_0]
	                                        WHERE VINGENIERI.SORDER.SOHCAT_0 = 2 AND VINGENIERI.SORDER.DLVSTA_0 = 1 AND [VINGENIERI].[TEXCLOB].[TEXTE_0] LIKE '%'  AND VINGENIERI.ITMMASTER.ITMDES1_0 LIKE '%' 
	                                        group by VINGENIERI.SORDER.[SOHNUM_0], VINGENIERI.SORDER.[BPCINV_0], VINGENIERI.SORDER.[BPINAM_0], VINGENIERI.SORDER.[ORDDAT_0], VINGENIERI.SORDER.[LNDRTNDAT_0]
                                        )
                                        order by VINGENIERI.SORDER.[SOHNUM_0]";

            
            FillDataReceptionProduct(queryProductReturn);
            
            string queryCustomerReturn = @"SELECT VINGENIERI.SDELIVERY.SOHNUM_0 AS 'N° CP', VINGENIERI.SDELIVERY.[BPCINV_0] AS 'N° de Client', VINGENIERI.SDELIVERY.[BPINAM_0] AS 'Client', VINGENIERI.SDELIVERY.[SDHNUM_0] AS 'N° LP', VINGENIERI.SDELIVERY.[SHIDAT_0] AS 'Date LP ', VINGENIERI.SDELIVERY.[LNDRTNDAT_0] AS 'Date retour prévue'
                                        FROM VINGENIERI.SDELIVERY
                                        Inner join VINGENIERI.SDELIVERYD ON VINGENIERI.SDELIVERY.[SDHNUM_0] = VINGENIERI.SDELIVERYD.[SDHNUM_0]
                                        inner join [VINGENIERI].[ITMMASTER] on [VINGENIERI].[SDELIVERYD].[ITMREF_0]=[VINGENIERI].[ITMMASTER].[ITMREF_0]
                                        left join [VINGENIERI].[TEXCLOB] on [VINGENIERI].[TEXCLOB].[CODE_0]=[VINGENIERI].[SDELIVERYD].[SDDTEX_0]
                                        WHERE VINGENIERI.SDELIVERY.LND_0 = 2 and VINGENIERI.SDELIVERY.RTNSTA_0 = 1 and VINGENIERI.SDELIVERY.CFMFLG_0 = 2
                                       
                                        group by VINGENIERI.SDELIVERY.SOHNUM_0, VINGENIERI.SDELIVERY.[BPCINV_0], VINGENIERI.SDELIVERY.[BPINAM_0], VINGENIERI.SDELIVERY.[SDHNUM_0], VINGENIERI.SDELIVERY.[SHIDAT_0], VINGENIERI.SDELIVERY.[LNDRTNDAT_0] 
                                        order by VINGENIERI.SDELIVERY.[SDHNUM_0] desc
                                        ;
                                        SELECT VINGENIERI.SDELIVERY.SOHNUM_0 AS 'N° CP', VINGENIERI.ITMMASTER.ITMDES1_0 as 'Produit', [VINGENIERI].[TEXCLOB].[TEXTE_0] as 'Détail', VINGENIERI.STOSER.SERNUM_0 as 'N° Série'
                                        FROM VINGENIERI.SDELIVERY
                                        Inner join VINGENIERI.SDELIVERYD ON VINGENIERI.SDELIVERY.[SDHNUM_0] = VINGENIERI.SDELIVERYD.[SDHNUM_0]
                                        inner join [VINGENIERI].[ITMMASTER] on [VINGENIERI].[SDELIVERYD].[ITMREF_0]=[VINGENIERI].[ITMMASTER].[ITMREF_0] and [VINGENIERI].[ITMMASTER].CLSTYP_0=1 and [VINGENIERI].[ITMMASTER].STDFLG_0=3
                                        left join [VINGENIERI].[TEXCLOB] on [VINGENIERI].[TEXCLOB].[CODE_0]=[VINGENIERI].[SDELIVERYD].[SDDTEX_0]
                                        Left Join  VINGENIERI.STOSER ON  VINGENIERI.STOSER.ITMREF_0 = VINGENIERI.SDELIVERYD.ITMREF_0 and VINGENIERI.STOSER.SDHNUM_0 = VINGENIERI.SDELIVERYD.[SDHNUM_0]
                                        where VINGENIERI.SDELIVERY.SOHNUM_0 IN (											
	                                        SELECT VINGENIERI.SDELIVERY.SOHNUM_0
	                                        FROM VINGENIERI.SDELIVERY
	                                        Inner join VINGENIERI.SDELIVERYD ON VINGENIERI.SDELIVERY.[SDHNUM_0] = VINGENIERI.SDELIVERYD.[SDHNUM_0]
	                                        inner join [VINGENIERI].[ITMMASTER] on [VINGENIERI].[SDELIVERYD].[ITMREF_0]=[VINGENIERI].[ITMMASTER].[ITMREF_0]
	                                        left join [VINGENIERI].[TEXCLOB] on [VINGENIERI].[TEXCLOB].[CODE_0]=[VINGENIERI].[SDELIVERYD].[SDDTEX_0]
	                                        WHERE VINGENIERI.SDELIVERY.LND_0 = 2 and VINGENIERI.SDELIVERY.RTNSTA_0 = 1 and VINGENIERI.SDELIVERY.CFMFLG_0 = 2 and [VINGENIERI].[TEXCLOB].[TEXTE_0] LIKE '%' and VINGENIERI.ITMMASTER.ITMDES1_0 LIKE '%'
	                                        group by VINGENIERI.SDELIVERY.SOHNUM_0, VINGENIERI.SDELIVERY.[BPCINV_0], VINGENIERI.SDELIVERY.[BPINAM_0], VINGENIERI.SDELIVERY.[SDHNUM_0], VINGENIERI.SDELIVERY.[SHIDAT_0], VINGENIERI.SDELIVERY.[LNDRTNDAT_0] 
                                        )
                                        order by  VINGENIERI.SDELIVERY.SOHNUM_0";
            
            FillDataCustomerReturn(queryCustomerReturn);
            Log.UCRP.Debug("UCRP_Load() : STATUT : PASSED");
        }


        /// <summary>
        ///  refresh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == RecepProduitTabPage)
            {
                string queryCustomerReturn = @"SELECT VINGENIERI.SORDER.[SOHNUM_0] AS 'N° CP', VINGENIERI.SORDER.[BPCINV_0] AS 'N° de Client', VINGENIERI.SORDER.[BPINAM_0] AS 'Client', VINGENIERI.SORDER.[ORDDAT_0] AS 'Date CP', VINGENIERI.SORDER.[LNDRTNDAT_0] AS 'Date retour prévue'	
                                            FROM VINGENIERI.SORDER
                                            Inner join VINGENIERI.[SORDERQ] on VINGENIERI.SORDER.[SOHNUM_0] = VINGENIERI.[SORDERQ].[SOHNUM_0]
                                            inner join [VINGENIERI].[ITMMASTER] on [VINGENIERI].[SORDERQ].[ITMREF_0]=[VINGENIERI].[ITMMASTER].[ITMREF_0]
                                            left join [VINGENIERI].[TEXCLOB] on [VINGENIERI].[TEXCLOB].[CODE_0]=[VINGENIERI].[SORDERQ].[SOQTEX_0]
                                            WHERE VINGENIERI.SORDER.SOHCAT_0 = 2 AND VINGENIERI.SORDER.DLVSTA_0 = 1 
                                            group by VINGENIERI.SORDER.[SOHNUM_0], VINGENIERI.SORDER.[BPCINV_0], VINGENIERI.SORDER.[BPINAM_0], VINGENIERI.SORDER.[ORDDAT_0], VINGENIERI.SORDER.[LNDRTNDAT_0]
                                            order by VINGENIERI.SORDER.[LNDRTNDAT_0] asc
                                            ;
                                            SELECT VINGENIERI.SORDER.[SOHNUM_0] AS 'N° CP', VINGENIERI.ITMMASTER.ITMDES1_0 as 'Produit', [VINGENIERI].[TEXCLOB].[TEXTE_0] as 'Détail', VINGENIERI.[SORDERQ].DEMNUM_0 as 'N°Série'
                                            FROM VINGENIERI.SORDER
                                            Inner join VINGENIERI.[SORDERQ] on VINGENIERI.SORDER.[SOHNUM_0] = VINGENIERI.[SORDERQ].[SOHNUM_0]
                                            inner join [VINGENIERI].[ITMMASTER] on [VINGENIERI].[SORDERQ].[ITMREF_0]=[VINGENIERI].[ITMMASTER].[ITMREF_0]
                                            left join [VINGENIERI].[TEXCLOB] on [VINGENIERI].[TEXCLOB].[CODE_0]=[VINGENIERI].[SORDERQ].[SOQTEX_0]
                                            WHERE VINGENIERI.SORDER.[SOHNUM_0] IN (												
	                                            SELECT VINGENIERI.SORDER.[SOHNUM_0]
	                                            FROM VINGENIERI.SORDER
	                                            Inner join VINGENIERI.[SORDERQ] on VINGENIERI.SORDER.[SOHNUM_0] = VINGENIERI.[SORDERQ].[SOHNUM_0]
	                                            inner join [VINGENIERI].[ITMMASTER] on [VINGENIERI].[SORDERQ].[ITMREF_0]=[VINGENIERI].[ITMMASTER].[ITMREF_0]
	                                            left join [VINGENIERI].[TEXCLOB] on [VINGENIERI].[TEXCLOB].[CODE_0]=[VINGENIERI].[SORDERQ].[SOQTEX_0]
	                                            WHERE VINGENIERI.SORDER.SOHCAT_0 = 2 AND VINGENIERI.SORDER.DLVSTA_0 = 1 AND [VINGENIERI].[TEXCLOB].[TEXTE_0] LIKE '%'  AND VINGENIERI.ITMMASTER.ITMDES1_0 LIKE '%' 
	                                            group by VINGENIERI.SORDER.[SOHNUM_0], VINGENIERI.SORDER.[BPCINV_0], VINGENIERI.SORDER.[BPINAM_0], VINGENIERI.SORDER.[ORDDAT_0], VINGENIERI.SORDER.[LNDRTNDAT_0]
                                            )
                                            order by VINGENIERI.SORDER.[SOHNUM_0]";
                FillDataReceptionProduct(queryCustomerReturn);
            }
            else
            {
                string queryCustomerReturn = @"SELECT VINGENIERI.SDELIVERY.SOHNUM_0 AS 'N° CP', VINGENIERI.SDELIVERY.[BPCINV_0] AS 'N° de Client', VINGENIERI.SDELIVERY.[BPINAM_0] AS 'Client', VINGENIERI.SDELIVERY.[SDHNUM_0] AS 'N° LP', VINGENIERI.SDELIVERY.[SHIDAT_0] AS 'Date LP ', VINGENIERI.SDELIVERY.[LNDRTNDAT_0] AS 'Date retour prévue'
                                            FROM VINGENIERI.SDELIVERY
                                            Inner join VINGENIERI.SDELIVERYD ON VINGENIERI.SDELIVERY.[SDHNUM_0] = VINGENIERI.SDELIVERYD.[SDHNUM_0]
                                            inner join [VINGENIERI].[ITMMASTER] on [VINGENIERI].[SDELIVERYD].[ITMREF_0]=[VINGENIERI].[ITMMASTER].[ITMREF_0]
                                            left join [VINGENIERI].[TEXCLOB] on [VINGENIERI].[TEXCLOB].[CODE_0]=[VINGENIERI].[SDELIVERYD].[SDDTEX_0]
                                            WHERE VINGENIERI.SDELIVERY.LND_0 = 2 and VINGENIERI.SDELIVERY.RTNSTA_0 = 1 and VINGENIERI.SDELIVERY.CFMFLG_0 = 2
                                            and [VINGENIERI].[TEXCLOB].[TEXTE_0] LIKE '%' and VINGENIERI.ITMMASTER.ITMDES1_0 LIKE '%'
                                            group by VINGENIERI.SDELIVERY.SOHNUM_0, VINGENIERI.SDELIVERY.[BPCINV_0], VINGENIERI.SDELIVERY.[BPINAM_0], VINGENIERI.SDELIVERY.[SDHNUM_0], VINGENIERI.SDELIVERY.[SHIDAT_0], VINGENIERI.SDELIVERY.[LNDRTNDAT_0] 
                                            order by VINGENIERI.SDELIVERY.[SDHNUM_0] desc
                                            ;
                                            SELECT VINGENIERI.SDELIVERY.SOHNUM_0 AS 'N° CP', VINGENIERI.ITMMASTER.ITMDES1_0 as 'Produit', [VINGENIERI].[TEXCLOB].[TEXTE_0] as 'Détail', VINGENIERI.STOSER.SERNUM_0 as 'N° Série'
                                            FROM VINGENIERI.SDELIVERY
                                            Inner join VINGENIERI.SDELIVERYD ON VINGENIERI.SDELIVERY.[SDHNUM_0] = VINGENIERI.SDELIVERYD.[SDHNUM_0]
                                            inner join [VINGENIERI].[ITMMASTER] on [VINGENIERI].[SDELIVERYD].[ITMREF_0]=[VINGENIERI].[ITMMASTER].[ITMREF_0] and [VINGENIERI].[ITMMASTER].CLSTYP_0=1 and [VINGENIERI].[ITMMASTER].STDFLG_0=3
                                            left join [VINGENIERI].[TEXCLOB] on [VINGENIERI].[TEXCLOB].[CODE_0]=[VINGENIERI].[SDELIVERYD].[SDDTEX_0]
                                            Left Join  VINGENIERI.STOSER ON  VINGENIERI.STOSER.ITMREF_0 = VINGENIERI.SDELIVERYD.ITMREF_0 and VINGENIERI.STOSER.SDHNUM_0 = VINGENIERI.SDELIVERYD.[SDHNUM_0]
                                            where VINGENIERI.SDELIVERY.SOHNUM_0 IN (											
	                                            SELECT VINGENIERI.SDELIVERY.SOHNUM_0
	                                            FROM VINGENIERI.SDELIVERY
	                                            Inner join VINGENIERI.SDELIVERYD ON VINGENIERI.SDELIVERY.[SDHNUM_0] = VINGENIERI.SDELIVERYD.[SDHNUM_0]
	                                            inner join [VINGENIERI].[ITMMASTER] on [VINGENIERI].[SDELIVERYD].[ITMREF_0]=[VINGENIERI].[ITMMASTER].[ITMREF_0]
	                                            left join [VINGENIERI].[TEXCLOB] on [VINGENIERI].[TEXCLOB].[CODE_0]=[VINGENIERI].[SDELIVERYD].[SDDTEX_0]
	                                            WHERE VINGENIERI.SDELIVERY.LND_0 = 2 and VINGENIERI.SDELIVERY.RTNSTA_0 = 1 and VINGENIERI.SDELIVERY.CFMFLG_0 = 2 and [VINGENIERI].[TEXCLOB].[TEXTE_0] LIKE '%' and VINGENIERI.ITMMASTER.ITMDES1_0 LIKE '%'
	                                            group by VINGENIERI.SDELIVERY.SOHNUM_0, VINGENIERI.SDELIVERY.[BPCINV_0], VINGENIERI.SDELIVERY.[BPINAM_0], VINGENIERI.SDELIVERY.[SDHNUM_0], VINGENIERI.SDELIVERY.[SHIDAT_0], VINGENIERI.SDELIVERY.[LNDRTNDAT_0] 
                                            )
                                            order by  VINGENIERI.SDELIVERY.SOHNUM_0";
                FillDataCustomerReturn(queryCustomerReturn);
            }
            Log.UCRP.Debug("roundButton1_Click() : STATUT : PASSED");
        }

        private void IterateChildRowsAndAddProduct(GridViewHierarchyRowInfo rowInfo, int idLoan)
        {
            GridViewInfo currentView = rowInfo.ActiveView;
            foreach (GridViewInfo view in rowInfo.Views)
            {
                rowInfo.ActiveView = view;
                foreach (GridViewRowInfo row in rowInfo.ChildRows)
                {
                    PRODUCT newProduct = new PRODUCT
                    {
                        PRO_LOA_ID_FK = idLoan,
                        PRO_NAME = row.Cells["Produit"].Value.ToString(),
                        PRO_COM = row.Cells["Détail"].Value.ToString()
                    };
                    VpretContext.Instance.vPretContext.PRODUCT.InsertOnSubmit(newProduct);
                    VpretContext.Instance.vPretContext.SubmitChanges();
                }
            }
            rowInfo.ActiveView = currentView;
            Log.UCRP.Debug("IterateChildRowsAndAddProduct(GridViewHierarchyRowInfo rowInfo, int idLoan) : STATUT : PASSED");
        }

        /// <summary>
        ///  button refresh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == RecepProduitTabPage)
            {
                string queryCustomerReturn = @"SELECT VINGENIERI.SORDER.[SOHNUM_0] AS 'N° CP', VINGENIERI.SORDER.[BPCINV_0] AS 'N° de Client', VINGENIERI.SORDER.[BPINAM_0] AS 'Client', VINGENIERI.SORDER.[ORDDAT_0] AS 'Date CP', VINGENIERI.SORDER.[LNDRTNDAT_0] AS 'Date retour prévue'	
                                            FROM VINGENIERI.SORDER
                                            Inner join VINGENIERI.[SORDERQ] on VINGENIERI.SORDER.[SOHNUM_0] = VINGENIERI.[SORDERQ].[SOHNUM_0]
                                            inner join [VINGENIERI].[ITMMASTER] on [VINGENIERI].[SORDERQ].[ITMREF_0]=[VINGENIERI].[ITMMASTER].[ITMREF_0]
                                            left join [VINGENIERI].[TEXCLOB] on [VINGENIERI].[TEXCLOB].[CODE_0]=[VINGENIERI].[SORDERQ].[SOQTEX_0]
                                            WHERE VINGENIERI.SORDER.SOHCAT_0 = 2 AND VINGENIERI.SORDER.DLVSTA_0 = 1 AND [VINGENIERI].[TEXCLOB].[TEXTE_0] LIKE '%' + @SN + '%' OR VINGENIERI.ITMMASTER.ITMDES1_0 LIKE '%' + @SN + '%' OR VINGENIERI.[SORDERQ].DEMNUM_0 LIKE '%' + @SN + '%'
                                            group by VINGENIERI.SORDER.[SOHNUM_0], VINGENIERI.SORDER.[BPCINV_0], VINGENIERI.SORDER.[BPINAM_0], VINGENIERI.SORDER.[ORDDAT_0], VINGENIERI.SORDER.[LNDRTNDAT_0]
                                            order by VINGENIERI.SORDER.[LNDRTNDAT_0] asc
                                            ;
                                            SELECT VINGENIERI.SORDER.[SOHNUM_0] AS 'N° CP', VINGENIERI.ITMMASTER.ITMDES1_0 as 'Produit', [VINGENIERI].[TEXCLOB].[TEXTE_0] as 'Détail', VINGENIERI.[SORDERQ].DEMNUM_0 as 'N°Série'
                                            FROM VINGENIERI.SORDER
                                            Inner join VINGENIERI.[SORDERQ] on VINGENIERI.SORDER.[SOHNUM_0] = VINGENIERI.[SORDERQ].[SOHNUM_0]
                                            inner join [VINGENIERI].[ITMMASTER] on [VINGENIERI].[SORDERQ].[ITMREF_0]=[VINGENIERI].[ITMMASTER].[ITMREF_0]
                                            left join [VINGENIERI].[TEXCLOB] on [VINGENIERI].[TEXCLOB].[CODE_0]=[VINGENIERI].[SORDERQ].[SOQTEX_0]
                                            WHERE VINGENIERI.SORDER.[SOHNUM_0] IN (												
	                                            SELECT VINGENIERI.SORDER.[SOHNUM_0]
	                                            FROM VINGENIERI.SORDER
	                                            Inner join VINGENIERI.[SORDERQ] on VINGENIERI.SORDER.[SOHNUM_0] = VINGENIERI.[SORDERQ].[SOHNUM_0]
	                                            inner join [VINGENIERI].[ITMMASTER] on [VINGENIERI].[SORDERQ].[ITMREF_0]=[VINGENIERI].[ITMMASTER].[ITMREF_0]
	                                            left join [VINGENIERI].[TEXCLOB] on [VINGENIERI].[TEXCLOB].[CODE_0]=[VINGENIERI].[SORDERQ].[SOQTEX_0]
	                                            WHERE VINGENIERI.SORDER.SOHCAT_0 = 2 AND VINGENIERI.SORDER.DLVSTA_0 = 1 
	                                            group by VINGENIERI.SORDER.[SOHNUM_0], VINGENIERI.SORDER.[BPCINV_0], VINGENIERI.SORDER.[BPINAM_0], VINGENIERI.SORDER.[ORDDAT_0], VINGENIERI.SORDER.[LNDRTNDAT_0]
                                            )
                                            order by VINGENIERI.SORDER.[SOHNUM_0]";

                Dictionary<string, string> param = new Dictionary<string, string>();
                param.Add("SN", SnTextBox.Text);

                FillDataReceptionProduct(queryCustomerReturn, param);
            }
            else
            {
                string queryCustomerReturn = @"SELECT VINGENIERI.SDELIVERY.SOHNUM_0 AS 'N° CP', VINGENIERI.SDELIVERY.[BPCINV_0] AS 'N° de Client', VINGENIERI.SDELIVERY.[BPINAM_0] AS 'Client', VINGENIERI.SDELIVERY.[SDHNUM_0] AS 'N° LP', VINGENIERI.SDELIVERY.[SHIDAT_0] AS 'Date LP ', VINGENIERI.SDELIVERY.[LNDRTNDAT_0] AS 'Date retour prévue'
                                        FROM VINGENIERI.SDELIVERY
                                        Inner join VINGENIERI.SDELIVERYD ON VINGENIERI.SDELIVERY.[SDHNUM_0] = VINGENIERI.SDELIVERYD.[SDHNUM_0]
                                        inner join [VINGENIERI].[ITMMASTER] on [VINGENIERI].[SDELIVERYD].[ITMREF_0]=[VINGENIERI].[ITMMASTER].[ITMREF_0]
                                        left join [VINGENIERI].[TEXCLOB] on [VINGENIERI].[TEXCLOB].[CODE_0]=[VINGENIERI].[SDELIVERYD].[SDDTEX_0]
                                        WHERE VINGENIERI.SDELIVERY.LND_0 = 2 and VINGENIERI.SDELIVERY.RTNSTA_0 = 1 and VINGENIERI.SDELIVERY.CFMFLG_0 = 2 
                                        and [VINGENIERI].[TEXCLOB].[TEXTE_0] LIKE '%' + @SN + '%' OR VINGENIERI.ITMMASTER.ITMDES1_0 LIKE '%' + @SN + '%' OR VINGENIERI.STOSER.SERNUM_0 LIKE '%' + @SN + '%'
                                        group by VINGENIERI.SDELIVERY.SOHNUM_0, VINGENIERI.SDELIVERY.[BPCINV_0], VINGENIERI.SDELIVERY.[BPINAM_0], VINGENIERI.SDELIVERY.[SDHNUM_0], VINGENIERI.SDELIVERY.[SHIDAT_0], VINGENIERI.SDELIVERY.[LNDRTNDAT_0] 
                                        order by VINGENIERI.SDELIVERY.[SDHNUM_0] desc
                                        ;
                                        SELECT VINGENIERI.SDELIVERY.SOHNUM_0 AS 'N° CP', VINGENIERI.ITMMASTER.ITMDES1_0 as 'Produit', [VINGENIERI].[TEXCLOB].[TEXTE_0] as 'Détail', VINGENIERI.STOSER.SERNUM_0 as 'N° Série'
                                        FROM VINGENIERI.SDELIVERY
                                        Inner join VINGENIERI.SDELIVERYD ON VINGENIERI.SDELIVERY.[SDHNUM_0] = VINGENIERI.SDELIVERYD.[SDHNUM_0]
                                        inner join [VINGENIERI].[ITMMASTER] on [VINGENIERI].[SDELIVERYD].[ITMREF_0]=[VINGENIERI].[ITMMASTER].[ITMREF_0] and [VINGENIERI].[ITMMASTER].CLSTYP_0=1 and [VINGENIERI].[ITMMASTER].STDFLG_0=3
                                        left join [VINGENIERI].[TEXCLOB] on [VINGENIERI].[TEXCLOB].[CODE_0]=[VINGENIERI].[SDELIVERYD].[SDDTEX_0]
                                        Left Join  VINGENIERI.STOSER ON  VINGENIERI.STOSER.ITMREF_0 = VINGENIERI.SDELIVERYD.ITMREF_0 and VINGENIERI.STOSER.SDHNUM_0 = VINGENIERI.SDELIVERYD.[SDHNUM_0]
                                        where VINGENIERI.SDELIVERY.SOHNUM_0 IN (											
	                                        SELECT VINGENIERI.SDELIVERY.SOHNUM_0
	                                        FROM VINGENIERI.SDELIVERY
	                                        Inner join VINGENIERI.SDELIVERYD ON VINGENIERI.SDELIVERY.[SDHNUM_0] = VINGENIERI.SDELIVERYD.[SDHNUM_0]
	                                        inner join [VINGENIERI].[ITMMASTER] on [VINGENIERI].[SDELIVERYD].[ITMREF_0]=[VINGENIERI].[ITMMASTER].[ITMREF_0]
	                                        left join [VINGENIERI].[TEXCLOB] on [VINGENIERI].[TEXCLOB].[CODE_0]=[VINGENIERI].[SDELIVERYD].[SDDTEX_0]
	                                        WHERE VINGENIERI.SDELIVERY.LND_0 = 2 and VINGENIERI.SDELIVERY.RTNSTA_0 = 1 and VINGENIERI.SDELIVERY.CFMFLG_0 = 2 and [VINGENIERI].[TEXCLOB].[TEXTE_0] LIKE '%' and VINGENIERI.ITMMASTER.ITMDES1_0 LIKE '%'
	                                        group by VINGENIERI.SDELIVERY.SOHNUM_0, VINGENIERI.SDELIVERY.[BPCINV_0], VINGENIERI.SDELIVERY.[BPINAM_0], VINGENIERI.SDELIVERY.[SDHNUM_0], VINGENIERI.SDELIVERY.[SHIDAT_0], VINGENIERI.SDELIVERY.[LNDRTNDAT_0] 
                                        )
                                        order by  VINGENIERI.SDELIVERY.SOHNUM_0";
                Dictionary<string, string> param = new Dictionary<string, string>();
                param.Add("SN", SnTextBox.Text);
                FillDataCustomerReturn(queryCustomerReturn, param);
            }
            this.Dock = DockStyle.Fill;
        }


        private void radGridViewRecepProduit_ValueChanged(object sender, EventArgs e)
        {
            DataRowView cRow = this.radGridViewProductReturn.CurrentRow.DataBoundItem as DataRowView;
            DataRow currentRow = cRow.Row;
            GridViewDataRowInfo rrow = this.radGridViewProductReturn.CurrentRow as GridViewDataRowInfo;

            if (radGridViewProductReturn.CurrentCell != null)
            {
                if (radGridViewProductReturn.CurrentCell.Value.Equals(0))
                {
                    try
                    {
                        IQueryable<LOAN> loans = (from LOAN in VpretContext.Instance.vPretContext.LOAN
                                                  where LOAN.LOA_CP.Equals(currentRow["N° CP"].ToString())
                                                  select LOAN);
                        if (loans != null)
                        {
                            foreach (LOAN loan in loans)
                            {
                                VpretContext.Instance.vPretContext.LOAN.DeleteOnSubmit(loan);
                                VpretContext.Instance.vPretContext.SubmitChanges();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.UCRP.Error("Exception SQl radGridViewRecepProduit_ValueChanged() : " + ex.ToString());
                    }
                    finally
                    {
                        Log.UCRP.Debug("radGridViewRecepProduit_ValueChanged() - Loans deleted");
                    }
                }
                else if (radGridViewProductReturn.CurrentCell.Value.Equals(1))
                {
                    CommentDialog dialog = new CommentDialog();
                    dialog.StartPosition = FormStartPosition.CenterScreen;
                    dialog.ShowDialog();

                    DateTime loaDate = Convert.ToDateTime(currentRow["Date CP"].ToString());
                    DateTime loaDateRetour = Convert.ToDateTime(currentRow["Date retour prévue"].ToString());

                    try
                    {
                        List<LOAN> loans = (from LOAN in VpretContext.Instance.vPretContext.LOAN
                                            where LOAN.LOA_CP == currentRow["N° CP"].ToString()
                                            select LOAN).ToList();
                        if (loans.Count() > 0)
                        {
                            foreach (LOAN loan in loans)
                                if (loan.LOA_STATE > 1)
                                    loan.LOA_STATE = 1;
                            VpretContext.Instance.vPretContext.SubmitChanges();
                        }
                        else
                        {
                            string commG = " ";
                            if (dialog.Comment != "")
                                commG = dialog.Comment;
                            LOAN newLoan = new LOAN
                            {
                                LOA_CLIENT = currentRow["Client"].ToString(),
                                LOA_CP = currentRow["N° CP"].ToString(),
                                LOA_DATE = loaDate,
                                LOA_DATE_RETOUR = loaDateRetour,
                                LOA_NUM_CLIENT = Int32.Parse(currentRow["N° de Client"].ToString()),
                                LOA_STATE = 1, // 0 en cours 1 à controler 2 terminé
                                LOA_COMM_G = commG
                            };
                            VpretContext.Instance.vPretContext.LOAN.InsertOnSubmit(newLoan);
                            VpretContext.Instance.vPretContext.SubmitChanges();

                            int idLoan = newLoan.LOA_ID;
                            GridViewDataRowInfo row = this.radGridViewProductReturn.CurrentRow as GridViewDataRowInfo;
                            GridViewHierarchyRowInfo hierarchyRow = row as GridViewHierarchyRowInfo;
                            if (hierarchyRow != null)
                                IterateChildRowsAndAddProduct(hierarchyRow, idLoan);
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

        private void radGridViewCustmerReturn_ValueChanged(object sender, EventArgs e)
        {
            DataRowView cRow = this.radGridViewCutomerReturn.CurrentRow.DataBoundItem as DataRowView;
            DataRow currentRow = cRow.Row;
            GridViewDataRowInfo rrow = this.radGridViewCutomerReturn.CurrentRow as GridViewDataRowInfo;

            if (radGridViewCutomerReturn.CurrentCell != null)
            {
                if (radGridViewCutomerReturn.CurrentCell.Value.Equals(0))
                {
                    try
                    {
                        IQueryable<LOAN> loans = (from LOAN in VpretContext.Instance.vPretContext.LOAN
                                                  where LOAN.LOA_CP.Equals(currentRow["N° CP"].ToString())
                                                  select LOAN);
                        if (loans != null)
                        {
                            foreach (LOAN loan in loans)
                            {
                                VpretContext.Instance.vPretContext.LOAN.DeleteOnSubmit(loan);
                                VpretContext.Instance.vPretContext.SubmitChanges();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.UCRP.Error("Exception SQl radGridViewRetourClient_ValueChanged : " + ex.ToString());
                    }
                    finally
                    {
                        Log.UCRP.Debug("radGridViewRetourClient_ValueChanged - Loans deleted");
                    }
                }

                else if (radGridViewCutomerReturn.CurrentCell.Value.Equals(1))
                {
                    CommentDialog dialog = new CommentDialog();
                    dialog.StartPosition = FormStartPosition.CenterScreen;
                    dialog.ShowDialog();

                    //   DateTime loaDate = Convert.ToDateTime(currentRow["Date LP"].ToString());
                    DateTime loaDateRetour = Convert.ToDateTime(currentRow["Date retour prévue"].ToString());

                    try
                    {
                        List<LOAN> loans = (from LOAN in VpretContext.Instance.vPretContext.LOAN
                                            where LOAN.LOA_CP == currentRow["N° CP"].ToString()
                                            select LOAN).ToList();
                        if (loans.Count() > 0)
                        {
                            foreach (LOAN loan in loans)
                                if (loan.LOA_STATE > 1)
                                    loan.LOA_STATE = 1;
                            VpretContext.Instance.vPretContext.SubmitChanges();
                        }
                        else
                        {
                            string commG = " ";
                            if (dialog.Comment != "")
                                commG = dialog.Comment;
                            LOAN newLoan = new LOAN
                            {
                                LOA_CLIENT = currentRow["Client"].ToString(),
                                LOA_CP = currentRow["N° CP"].ToString(),
                                // LOA_DATE = loaDate,
                                LOA_DATE_RETOUR = loaDateRetour,
                                LOA_NUM_CLIENT = Int32.Parse(currentRow["N° de Client"].ToString()),
                                LOA_STATE = 1, // 0 en cours 1 à controler 2 terminé
                                LOA_COMM_G = commG
                            };
                            VpretContext.Instance.vPretContext.LOAN.InsertOnSubmit(newLoan);
                            VpretContext.Instance.vPretContext.SubmitChanges();

                            int idLoan = newLoan.LOA_ID;
                            GridViewDataRowInfo row = this.radGridViewCutomerReturn.CurrentRow as GridViewDataRowInfo;
                            GridViewHierarchyRowInfo hierarchyRow = row as GridViewHierarchyRowInfo;
                            if (hierarchyRow != null)
                                IterateChildRowsAndAddProduct(hierarchyRow, idLoan);
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.UCRP.Error("radGridViewRetourClient_ValueChanged() : " + ex.ToString());
                    }
                    finally
                    {
                        Log.UCRP.Debug("radGridViewRetourClient_ValueChanged() : STATUT : PASSED");
                    }
                }
            }
        }
    }

}
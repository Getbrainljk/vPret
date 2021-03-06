﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using vPret;
using Telerik.WinControls.UI;
using System.Collections;
using Vpret;

namespace Pret
{
    /// <summary>
    ///  Reception for Tech
    /// </summary>
    public partial class UCTechReception : UserControl
    {
        List<VisualisationPret> detail = new List<VisualisationPret>();
        public UCTechReception()
        {
            InitializeComponent();
            getSuppliers();
            this.Dock = DockStyle.Fill;
        }
        private void getSuppliers()
        {
            Log.UCTechReception.Debug("getProviders()");

            foreach (string supplier in populateDropdownList())
                radDropDownListProvider.Items.Add(supplier);
        }

        private void buttonValidate_Click(object sender, EventArgs e)
        {
            Log.UCTechReception.Debug("buttonValidate_Click()");

            if (radDropDownListProvider.Text == "")
            {
                MessageBox.Show("Fournisseur manquant.",
                                "Attention",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1);
                return;
            }
            if (dateTimePicker1.Value == null)
            {
                MessageBox.Show("Date manquante.",
                                "Attention",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Confirmer l'ajout ?",
                                                        "Question",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question,
                                                        MessageBoxDefaultButton.Button1);
            if (dialogResult == DialogResult.Yes)
            {
                getDataFromGrid();
                bool existence = false;
                if (detail.ElementAt(0).listProducts.Count != 0)
                    existence = true;
                if (existence == false)
                {
                    MessageBox.Show("Il faut inclure des produits.",
                                    "Attention",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation,
                                    MessageBoxDefaultButton.Button1);
                    return;
                }
                int idLoan = populateDb();
                doLoanReport(idLoan);
                // there the process to save photos for each loan
                string filename = dateTimePicker1.ToString();
                string targetPath = "" + Properties.Settings.Default.vPretImagePath;
                List<string> lPhotos = new List<string>();
                foreach (RadListDataItem photo in radListControl1.Items)
                    lPhotos.Add(photo.ToString());
                foreach (string item in lPhotos)
                {
                    string imageName = item.Substring(item.LastIndexOf("\\"));
                    System.IO.File.Copy(item, targetPath + imageName, true);
                }
                List<string> lBl= new List<string>();
                foreach (RadListDataItem bl in radListControl2.Items)
                    lBl.Add(bl.ToString());
                foreach (string item in lBl)
                {
                    string imageName = item.Substring(item.LastIndexOf("\\"));
                    System.IO.File.Copy(item, targetPath + imageName, true);
                }

                MessageBox.Show("Réception validée.",
                              "Information",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information,
                              MessageBoxDefaultButton.Button1);

                // clearing everything
                detail.Clear();
                radListControl1.Items.Clear();
                radListControl1.DataSource = null;
                radListControl1.Text = "";
                radListControl2.Items.Clear();
                radListControl2.DataSource = null;
                radListControl2.Text = "";
                detail.Clear();
                radGridView1.Rows.Clear();
                radGridView1.DataSource = null;
                tBoxObservation.Text = "";
                radDropDownListProvider.Text = "";
            }
        }

        private ReportViewer doLoanReport(int idLoan)
        {
            Log.UCTechReception.Debug("doLoanReport()");

            List<ReportParameter> param = new List<ReportParameter>();

            // setting all Report Parameters  
            string observation = (tBoxObservation.Text.ToString() == "") ? Properties.Settings.Default.EmptyObservation : tBoxObservation.Text;
         
            param.Add(new ReportParameter("ObservationParam", "Observation : " + observation, false));
            param.Add(new ReportParameter("fournisseurParam", "Fournisseur : " + radDropDownListProvider.Text, false));
            param.Add(new ReportParameter("dateRecParam", "Date de réception : " + dateTimePicker1.Text, false));
            param.Add(new ReportParameter("TechParam", "Technicien en charge : " + UserManager.currentUser.Username));
            param.Add(new ReportParameter("heureReceParam", "Heure de réception : " + DateTime.Now.ToString("HH:mm:ss tt")));
            param.Add(new ReportParameter("RefClient", "Référence client : " + idLoan.ToString()));

            ReportLoanView e = new ReportLoanView();
            e.getStaticMember(param, detail);
            ReportViewer rep = new ReportViewer();
            rep.LocalReport.DataSources.Clear();
            rep.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            rep.LocalReport.ReportPath = @"" + Properties.Settings.Default.RDLPath;

            List<string> mailAttachments = new List<string>();

            // if someday ADV wants to receive photos of the equipment
            /*
            foreach (RadListDataItem Photos in radListControl1.Items)
                mailAttachments.Add(Photos.ToString());
             */

            foreach (RadListDataItem BL in radListControl2.Items)
                mailAttachments.Add(BL.ToString());
            e.sendReportByMail(mailAttachments);
            return rep;
        }

        private void resetGrid()
        {
            Log.UCTechReception.Debug("resetGrid()");
            radGridView1.DataSource = null;
        }

        private int populateDb()
        {
            Log.UCTechReception.Debug("populateDb()");

            int idLoan = 0;
            // creating a loan associated with product, accessories, doc
            try
            {
                // using elementAt(0) because the list is empty after creating another one
                VisualisationPret loan = detail.ElementAt(0);
                LOAN newLoan = new LOAN
                {
                    LOA_USER_ID_FK = UserManager.currentUser.Id,
                    LOA_PROVIDER = radDropDownListProvider.Text,
                    LOA_COMM_G = tBoxObservation.Text,
                    LOA_DATE = dateTimePicker1.Value,
                    LOA_STATE = 0
                };
                VpretContext.Instance.vPretContext.LOAN.InsertOnSubmit(newLoan);
                VpretContext.Instance.vPretContext.SubmitChanges();
                idLoan = newLoan.LOA_ID;
                foreach (string item in loan.l_Photo)
                {
                    DOCUMENT photo = new DOCUMENT
                    {
                        DOC_LOA_ID_FK = idLoan,
                        DOC_NAME = item.ToString(),
                    };
                    VpretContext.Instance.vPretContext.DOCUMENT.InsertOnSubmit(photo);
                    VpretContext.Instance.vPretContext.SubmitChanges();
                }
                foreach (VisualisationProduct product in loan.listProducts)
                {
                    PRODUCT newProduct = new PRODUCT
                    {
                        PRO_LOA_ID_FK = idLoan,
                        PRO_SN = product.Sn,
                        PRO_NAME = product.Name,
                        PRO_COM = product.Com,
                        PRO_STATE = 0
                    };
                    VpretContext.Instance.vPretContext.PRODUCT.InsertOnSubmit(newProduct);
                    VpretContext.Instance.vPretContext.SubmitChanges();
                    foreach (VisualitationAccesories accessorie in product.listAccessories)
                    {
                        ACCESSORIES naccessorie = new ACCESSORIES
                        {
                            ACC_LOA_ID_FK = idLoan,
                            ACC_PRO_ID_FK = newProduct.PRO_ID,
                            ACC_NAME = accessorie.Name,
                            ACC_PN = accessorie.Pn,
                            ACC_COM = accessorie.Com,
                            ACC_STATE = 0
                        };
                        VpretContext.Instance.vPretContext.ACCESSORIES.InsertOnSubmit(naccessorie);
                        VpretContext.Instance.vPretContext.SubmitChanges();
                    }
                }
            }
            catch (Exception e)
            {
                Log.UCTechReception.Error("Population failed with exception: " + e.ToString());
            }
            finally
            {
                Log.UCTechReception.Debug("Population completed.");
            }
            return idLoan;
        }

        private void getDataFromGrid()
        {
            Log.UCTechReception.Debug("getDataFromGrid()");

            VisualisationPret currentPret = new VisualisationPret();
            currentPret.Photo = dateTimePicker1.Text;
            List<VisualisationProduct> plist = new List<VisualisationProduct>();
            foreach (GridViewRowInfo row in radGridView1.Rows)
            {
                VisualisationProduct p = new VisualisationProduct();
                foreach (GridViewCellInfo cellInfo in row.Cells)
                {
                    if (cellInfo.Value == null)
                        cellInfo.Value = "";
                    switch (cellInfo.ColumnInfo.Name)
                    {
                        case "Produit":
                            p.Name = cellInfo.Value.ToString();
                            break;
                        case "SN":
                            p.Sn = cellInfo.Value.ToString();
                            break;
                        case "CommentaireP":
                            p.Com = cellInfo.Value.ToString();
                            break;
                        default:
                            break;
                    }
                }
                // data from Child Rows 
                GridViewHierarchyRowInfo hierarchyRow = row as GridViewHierarchyRowInfo;
                if (hierarchyRow != null)
                {
                    GridViewInfo currentView = hierarchyRow.ActiveView;
                    foreach (GridViewInfo view in hierarchyRow.Views)
                    {
                        hierarchyRow.ActiveView = view;
                        List<VisualitationAccesories> alist = new List<VisualitationAccesories>();
                        foreach (GridViewRowInfo crow in view.ChildRows)
                        {
                            VisualitationAccesories a = new VisualitationAccesories();
                            foreach (GridViewCellInfo ccellInfo in crow.Cells)
                            {
                                if (ccellInfo.Value == null)
                                    ccellInfo.Value = "";
                                switch (ccellInfo.ColumnInfo.Name)
                                {
                                    case "Accessoire":
                                        a.Name = ccellInfo.Value.ToString();
                                        break;
                                    case "PN":
                                        a.Pn = ccellInfo.Value.ToString();
                                        break;
                                    case "CommentaireA":
                                        a.Com = ccellInfo.Value.ToString();
                                        break;
                                    default:
                                        break;
                                }
                            }
                            alist.Add(a);
                        }
                        p.listAccessories = alist;
                        hierarchyRow.ActiveView = currentView;
                    }
                }
                plist.Add(p);
            }
            List<string> l_Photo = new List<string>();
            foreach (RadListDataItem item in radListControl1.Items)
                l_Photo.Add(item.ToString());
            currentPret.l_Photo = l_Photo;
            currentPret.listProducts = plist;
            detail.Add(currentPret);
        }

        private void newFileButton_Click(object sender, EventArgs e)
        {
            Log.UCTechReception.Debug("newFicheButton_Click()");

            DialogResult dialogResult = MessageBox.Show("Confirmer la supression ?",
                                                        "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.Yes)
            {
                foreach (RadListDataItem eachItem in radListControl1.SelectedItems.ToList())
                    radListControl1.Items.Remove(eachItem);
                foreach (RadListDataItem eachItem in radListControl2.SelectedItems.ToList())
                    radListControl2.Items.Remove(eachItem);
                radListControl1.Items.Clear();
                radListControl1.DataSource = null;
                radListControl1.Text = "";
                radListControl2.Items.Clear();
                radListControl2.DataSource = null;
                radListControl2.Text = "";
                detail.Clear();
                radGridView1.Rows.Clear();
                radGridView1.DataSource = null;
                tBoxObservation.Text = "";
                radDropDownListProvider.Text = "";
            }
        }

        private void buttonPhoto(object sender, EventArgs e)
        {
            Log.UCTechReception.Debug("button1_Click()");

            // Add photos
            ArrayList photos = new ArrayList();
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Ajouter une photo au Prêt";
            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
                radListControl1.Items.Add(fdlg.FileName);
        }

        public List<string> populateDropdownList()
        {
            Log.UCF.Debug("populateDropdownList()");

            // Fournisseur Actifs 
            List<string> listOfProvider = (from BPSUPPLIER in X3Context.Instance.x3context.BPSUPPLIER
                                           where BPSUPPLIER.ENAFLG_0 == 2
                                           select BPSUPPLIER.BPSNAM_0).Distinct().ToList();
            return listOfProvider;
        }

        private void buttonBL(object sender, EventArgs e)
        {
            //  Add BL file
            ArrayList photos = new ArrayList();
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Ajouter Bon de livraison";
            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
                radListControl2.Items.Add(fdlg.FileName);
        }



    }
}

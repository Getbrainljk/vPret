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
using Telerik.Windows.Controls;
using Telerik.WinForms.RichTextEditor;
using Telerik.WinControls.UI.Localization;
using Telerik.WinControls.UI;

namespace Pret
{
    // user control fiche manuelle
    public partial class UCFM : UserControl
    {
        public UCFM()
        {
            InitializeComponent();
            getProviders();
        }

        private void UCFM_Load(object sender, EventArgs e)
        {
        }

        private void getProviders()
        {
            foreach (string provider in populateDropdownList())
                radDropDownList1.Items.Add(provider);
        }

        private List<string> populateDropdownList()
        {
            var listOfProvider = (from SORDER in X3Context.Instance.x3context.SORDER
                                  orderby SORDER.SOHNUM_0 descending
                                  select SORDER.REP_0).Distinct().ToList();
            return listOfProvider;
        }

        private void buttonAnnulate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Etes vous sûr de vouloir refaire la fiche ?",
                                                        "Attention", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show("La fiche manuelle a été annulé !");
                tBoxObservation.Text = "";
                radDropDownList1.Text = "";
            }
            else if (dialogResult == DialogResult.No)
                return;
        }

        private void buttonValidate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Confirmer l'ajout de la fiche",
                                            "Confirmation de l'ajout", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                for (int i = 0; i < radGridView1.Rows.Count(); ++i)
                {
               //     MessageBox.Show(radGridView1.Rows[i].Cells[0].Value.ToString());
                 //   MessageBox.Show(radGridView1.Rows[""].Cells[0].ToString());
            
             //       radGridView1.Rows[i].Cells[0].
                    for (int j = 0; j < radGridView1.Rows[i].ChildRows.Count(); ++j)
                    {
                        //radGridView1.Rows[i].Cells[j].Text
                    }
                }
                foreach (GridViewRowInfo rowInfo in radGridView1.Rows)
                {
                    foreach (GridViewCellInfo cellInfo in rowInfo.Cells)
                    {
                        if ((cellInfo.ColumnInfo.Name == "Provider")
                            || (cellInfo.ColumnInfo.Name == "Produit")
                            || (cellInfo.ColumnInfo.Name == "SN"))
                        {
                            cellInfo.Value = "Test Value";
                        }
                    }
                }
                MessageBox.Show("La fiche manuelle a été validé !");
            }
        }

        private void radDropDownList1_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            MessageBox.Show("user change provider");
        }

        private void radGridView1_CellValidated(object sender, Telerik.WinControls.UI.CellValidatedEventArgs e)
        {
        }
    }
}

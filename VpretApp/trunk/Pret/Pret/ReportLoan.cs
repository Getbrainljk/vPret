﻿using Microsoft.Reporting.WinForms;
using Pret.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pret;
using Vpret;

namespace vPret
{
    /// <summary>
    ///  rdlc for a loan created
    /// </summary>
    public partial class ReportLoanView : Form
    {
        private string dateCreated = DateTime.Now.ToString("yyyy-dd-M--HH-mm");
        
        public ReportLoanView()
        {
            Log.ReportLoan.Debug("ReportLoanView()");
        
            InitializeComponent();
        }

        private void ReportLoanView_Load(object sender, EventArgs e)
        {
            Log.ReportLoan.Debug("ReportLoan_Load()");

            this.reportViewer1.RefreshReport();
        }

        /// <summary>
        ///  Assignation of a new object DetailsReport to bind the object with the ReportViewer
        /// </summary>
        /// <param name="param"></param>
        /// <param name="lp"></param>
        public void getStaticMember(List<ReportParameter> param, List<VisualisationPret> lp)
        {
            Log.ReportLoan.Debug("getStaticMember()");

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.ProcessingMode = ProcessingMode.Local;
            this.reportViewer1.LocalReport.ReportPath = @"" + Pret.Properties.Settings.Default.RDLPath;
            this.reportViewer1.LocalReport.SetParameters(param);

            ReportDataSource reportDataSource = new ReportDataSource();
            List<DetailsReport> vp = new List<DetailsReport>();
            VizualisationReport vrep = new VizualisationReport();
            foreach (VisualisationPret elem in lp)
            {
                foreach (VisualisationProduct subelem in elem.listProducts)
                {
                    DetailsReport drp = new DetailsReport();
                    
                    drp.NameProduit = subelem.Name;
                    drp.Sn = subelem.Sn;
                    drp.CommentProduit = subelem.Com;
                    if (subelem.listAccessories.Count() == 0)
                        vp.Add(drp);
                    else
                    {
                        foreach (VisualitationAccesories susubelem in subelem.listAccessories)
                        {
                            DetailsReport drp2 = new DetailsReport();
                                drp2.NameProduit = subelem.Name;
                                drp2.Sn = subelem.Sn;
                                drp2.CommentProduit = subelem.Com;
                            drp2.NameAcessorie = susubelem.Name;
                            drp2.CommentAccessorie = susubelem.Com;
                            drp2.Pn = susubelem.Pn;
                            vp.Add(drp2);
                        }
                    }
                }
            }
            // Must match the DataSource in the RDLC
            reportDataSource.Name = "ReportDataSet";
            reportDataSource.Value = vp;

            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.LocalReport.DisplayName = "Loan Report" + dateCreated;
       } 

        public void sendReportByMail(List<string> mailAttachments)
        {
            Log.ReportLoan.Debug("sendReportByMail()");

            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;
            string ReportName = "PDF\\Loan Report " + dateCreated + Pret.Properties.Settings.Default.AttachmentExtentionMail;

            byte[] bytes = this.reportViewer1.LocalReport.Render(
                "PDF", null, out mimeType, out encoding, out filenameExtension,
                out streamids, out warnings);
            System.IO.Directory.CreateDirectory("PDF");
            using (FileStream fs = new FileStream("PDF\\Loan Report" + dateCreated + ".pdf"
                                                    , FileMode.Create, FileAccess.ReadWrite))
            {
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();
            }
            try
            {
                // Settings / properties are both the same path
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(Settings.Default.smtpHost);
                mail.From = new MailAddress(Settings.Default.smtpAddr);
                mail.To.Add(Settings.Default.emailDest);

                mail.Subject = Pret.Properties.Settings.Default.MailSubjetReport;
                mail.Body =  Pret.Properties.Settings.Default.BodyReportLoanMail;

                System.Net.Mail.Attachment reportAttach;
                reportAttach = new System.Net.Mail.Attachment(@"PDF\Loan Report" + dateCreated + ".pdf");
                mail.Attachments.Add(reportAttach);
              
                foreach (string attachment in mailAttachments)
                {
                    System.Net.Mail.Attachment tempAttachment = new System.Net.Mail.Attachment(@"" + attachment);
                    mail.Attachments.Add(tempAttachment);
                }      

                SmtpServer.Port = Settings.Default.smtpPort;
                SmtpServer.Credentials = new System.Net.NetworkCredential(Settings.Default.smtpUser, Settings.Default.smtpPass);
                SmtpServer.EnableSsl = Settings.Default.enableSsl;
                SmtpServer.Send(mail);
                SmtpServer.Dispose();
            }
            catch (Exception ex)
            {
                Debug.Write("Exception: " + ex);
            }
            Log.ReportLoan.Info("++Fin sendReportByMail()");
        }
    }
}

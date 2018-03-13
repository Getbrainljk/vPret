using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using Vpret;
using Telerik.WinControls.UI.Localization;
using System.Reflection;
using vPret;
using System.Diagnostics;
using System.Configuration;
using System.Threading;
using System.Runtime.InteropServices;

namespace Pret
{
    public partial class Vpret : Telerik.WinControls.UI.RadForm
    {
        private static readonly Lazy<Vpret> lazyInstance = new Lazy<Vpret>(() => new Vpret());
        private UCRP ucrp = new UCRP();
        private UCF ucf = new UCF();
        int right = UserManager.currentUser.checkRight(UserManager.currentUser.Username);

        public Vpret()
        {
            Log.Program.Debug("Vpret()");
            removeLog();

            if (right == 0)
            {
                MessageBox.Show("Demandez à l'administrateur d'ajouter vos droits",
                "Echec de l'execution",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button1);
                System.Environment.Exit(1);
            }
            InitializeComponent();
            this.Text = "vPret " + Application.ProductVersion + " - " + UserManager.currentUser.Username;
            Log.Program.Debug("AdaptUserControlView passed");
        }

        private void removeLog()
        {
            Log.Program.Debug("removeLog()");
            Log.Program.Info("Suppression des fichiers de log de plus de " + Properties.Settings.Default.ResetLogDays + " jours");
            DateTime date = DateTime.Now.AddDays(-Properties.Settings.Default.ResetLogDays);
            LogFileCleanupTask task = new LogFileCleanupTask();
            task.CleanUp(date);
            Log.Program.Info("Fin de la suppression des logs");
        }



        private void Vpret_Load(object sender, EventArgs e)
        {
            UserButtonClick();
        }

        private void UserButtonClick(object sender = null, EventArgs e = null)
        {
            Button thisButton = new Button();
            if (sender != null)
                 thisButton = (Button)sender;
            switch (right)
            {
                // admin case right = 1
                case 1:
                    if (thisButton.Name == "TechButton")
                    {
                        radLabel1.Visible = false;
                        TechButton.BackColor = Color.Bisque;
                        MagasinierButton.BackColor = Color.White;
                        ucrp.Visible = false;
                        radLabel1.Visible = false;
                        this.BackColor = SystemColors.ActiveCaption;
                        panelVpret.Controls.Add(ucf);
                        ucf.Visible = true;
                        break;
                    }
                    MagasinierButton.BackColor = Color.Bisque;
                    TechButton.BackColor = Color.White;
                    ucf.Visible = false;
                    radLabel1.Visible = false;
                    this.BackColor = Color.DarkRed;
                    panelVpret.Controls.Add(ucrp);
                    ucrp.Visible = true;
                    break;
                case 2:
                    if (thisButton.Name == "MagasinierButton")
                    {
                        MessageBox.Show("Demandez à l'administrateur d'ajouter vos droits",
                        "Echec de l'execution",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1);
                        break;
                    }
                    radLabel1.Visible = false;
                    TechButton.BackColor = Color.Bisque;
                    MagasinierButton.BackColor = Color.White;
                    ucrp.Visible = false;
                    radLabel1.Visible = false;
                    this.BackColor = SystemColors.ActiveCaption;
                    panelVpret.Controls.Add(ucf);
                    break;
                case 3:
                    if (thisButton.Name == "TechButton")
                    {
                        MessageBox.Show("Demandez à l'administrateur d'ajouter vos droits",
                        "Echec de l'execution",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1);
                        break;
                    }
                    MagasinierButton.BackColor = Color.Bisque;
                    TechButton.BackColor = Color.White;
                    ucf.Visible = false;
                    radLabel1.Visible = false;
                    this.BackColor = Color.DarkRed;
                    panelVpret.Controls.Add(ucrp);
                    ucrp.Visible = true;
                break;
                default:
                    MessageBox.Show("Demandez à l'administrateur d'ajouter vos droits",
                    "Echec de l'execution",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1);
                    if (right == 0)
                        System.Environment.Exit(1);
                    break;
            }
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {
            Log.Vpret.Debug("roundButton1_Clic()");

            bool started = true;
            Process[] procList = Process.GetProcesses();

            foreach (Process p in procList)
                if (p.ProcessName.Equals("VplanningIhm"))
                    started = false;
            if (started)
            {
                Log.Vpret.Debug("Process VplanningIhm starting.....");
                ProcessStartInfo process = new ProcessStartInfo();
                process.FileName = @"" + Properties.Settings.Default.VplanningPath;
                Process.Start(process);
            }
            else
                MessageBox.Show("VPlanning est déjà en cours d'éxecution.",
                                "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Diagnostics;
using System.Reflection;

namespace BilancioFenealgest.UI
{
    public partial class SplashForm : DevExpress.XtraEditors.XtraForm
    {
        public SplashForm()
        {
            InitializeComponent();
            label5.Text = "Versione:" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            lblHeader.Text = Properties.Settings.Default.Header;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.tecnoesis.it");
        }
    }
}
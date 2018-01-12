using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BilancioFenealgest.DomainLayer;

namespace BilancioFenealgest.UI.UIComponents
{
    public partial class FrmCambiaNomeBanca : DevExpress.XtraEditors.XtraForm
    {
        FrmBilancio _main;

        public FrmCambiaNomeBanca(FrmBilancio main)
        {
            InitializeComponent();
            _main = main;

            string banca1 = "";
            string banca2 = ""; 
            string banca3 = "";

            string banca4 = "";
            string banca5 = "";
            string banca6 = "";


            _main.Presenter.FillNomiBanca(ref banca1, ref banca2, ref banca3, ref banca4, ref banca5, ref banca6);

            txtB1.Text = banca1;//TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca1Nome : Properties.Settings.Default.Banca1NomeRegionale;
            txtB2.Text = banca2;//TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca2Nome : Properties.Settings.Default.Banca2NomeRegionale;
            txtB3.Text = banca3;// TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca3Nome : Properties.Settings.Default.Banca3NomeRegionale;


            txtB4.Text = banca4;//TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca1Nome : Properties.Settings.Default.Banca1NomeRegionale;
            txtB5.Text = banca5;//TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca2Nome : Properties.Settings.Default.Banca2NomeRegionale;
            txtB6.Text = banca6;// TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca3Nome : Properties.Settings.Default.Banca3NomeRegionale;


        }

        private void cmdAnnulla_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtB1.Text))
                txtB1.Text = "Banca1";
            if (string.IsNullOrEmpty(txtB2.Text))
                txtB2.Text = "Banca2";
            if (string.IsNullOrEmpty(txtB3.Text))
                txtB3.Text = "Banca3";


            if (string.IsNullOrEmpty(txtB4.Text))
                txtB4.Text = "Banca4";
            if (string.IsNullOrEmpty(txtB5.Text))
                txtB5.Text = "Banca5";
            if (string.IsNullOrEmpty(txtB6.Text))
                txtB6.Text = "Banca6";
            //if (TipoBilanco.IsProvinciale)
            //    Properties.Settings.Default.Banca1Nome = txtB1.Text;
            //else
            //    Properties.Settings.Default.Banca1NomeRegionale = txtB1.Text;
            //    //
            //if (TipoBilanco.IsProvinciale)
            //    Properties.Settings.Default.Banca2Nome = txtB2.Text;
            //else
            //    Properties.Settings.Default.Banca2NomeRegionale = txtB2.Text;

            //if (TipoBilanco.IsProvinciale)
            //    Properties.Settings.Default.Banca3Nome = txtB3.Text;
            //else
            //    Properties.Settings.Default.Banca3NomeRegionale = txtB3.Text;

            
            

            //Properties.Settings.Default.Save();
            _main.Presenter.SetNomiBanca(txtB1.Text, txtB2.Text, txtB3.Text, txtB4.Text, txtB5.Text, txtB6.Text);


            string banca1 = "";
            string banca2 = "";
            string banca3 = "";

            string banca4 = "";
            string banca5 = "";
            string banca6 = "";

            _main.Presenter.FillNomiBanca(ref banca1, ref banca2, ref banca3, ref banca4, ref banca5, ref banca6);
            _main.Presenter.Save();



            _main.navBarItem2.Caption = banca1;//TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca1Nome : Properties.Settings.Default.Banca1NomeRegionale;
            _main.navBarItem3.Caption = banca2;//TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca2Nome : Properties.Settings.Default.Banca2NomeRegionale;
            _main.navBarItem11.Caption = banca3;// TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca3Nome : Properties.Settings.Default.Banca3NomeRegionale;


            _main.label34.Text = banca1 + ":";//TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca1Nome : Properties.Settings.Default.Banca1NomeRegionale + ":";
            _main.label33.Text = banca2 + ":";//TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca2Nome : Properties.Settings.Default.Banca2NomeRegionale + ":";

            _main.label24.Text = banca1 + ":";//TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca1Nome : Properties.Settings.Default.Banca1NomeRegionale + ":";
            _main.label6.Text = banca2 + ":";//TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca2Nome : Properties.Settings.Default.Banca2NomeRegionale + ":";

            _main.label2.Text = banca3 + ":";//TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca3Nome : Properties.Settings.Default.Banca3NomeRegionale + ":";
            _main.label18.Text = banca3 + ":";//TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca3Nome : Properties.Settings.Default.Banca3NomeRegionale + ":";


            _main.RefreshInterface();


            this.Close();

        }
    }
}
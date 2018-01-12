using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace BilancioFenealgest.UI.UIComponents
{
    public partial class FormSelectData : XtraForm
    {
        public FormSelectData()
        {
            InitializeComponent();
            dateEdit1.DateTime = DateTime.Now.Date;
        }

        public DateTime SelectedDate
        {
            get
            {
                return dateEdit1.DateTime ;
            }
           
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            if (SelectedDate == null)
            {
                XtraMessageBox.Show("Selezionare una data", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();

        }
    }
}

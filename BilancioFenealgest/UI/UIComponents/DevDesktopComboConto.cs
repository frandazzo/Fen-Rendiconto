using System;
using System.Collections.Generic;
using System.Text;
using BilancioFenealgest.Middleware;
using BilancioFenealgest.DomainLayer;

namespace BilancioFenealgest.UI.UIComponents
{
    public class DevDesktopComboConto: ILookupList
    {
        private DevExpress.XtraEditors.ComboBoxEdit  underlyingList;
        //private string _banca1 = "Banca1";
        //private string _banca2 = "Banca2";
        //private string _banca3 = "Banca3";

        private string banca1GUI; //= TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca1Nome : Properties.Settings.Default.Banca1NomeRegionale;
        private string banca2GUI; //= TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca2Nome : Properties.Settings.Default.Banca2NomeRegionale;
        private string banca3GUI;// = TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca3Nome : Properties.Settings.Default.Banca3NomeRegionale;
        private string banca4GUI; //= TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca1Nome : Properties.Settings.Default.Banca1NomeRegionale;
        private string banca5GUI; //= TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca2Nome : Properties.Settings.Default.Banca2NomeRegionale;
        private string banca6GUI;// = TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca3Nome : Properties.Settings.Default.Banca3NomeRegionale;





        public DevDesktopComboConto(DevExpress.XtraEditors.ComboBoxEdit underlyingList, string banca1, string banca2, string banca3, string banca4, string banca5, string banca6)
        {

            //banca1GUI = TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca1Nome : Properties.Settings.Default.Banca1NomeRegionale;
            //banca2GUI = TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca2Nome : Properties.Settings.Default.Banca2NomeRegionale;
            //banca3GUI = TipoBilanco.IsProvinciale ? Properties.Settings.Default.Banca3Nome : Properties.Settings.Default.Banca3NomeRegionale;

            banca1GUI= banca1;
            banca2GUI = banca2;
            banca3GUI = banca3;

            banca4GUI = banca4;
            banca5GUI = banca5;
            banca6GUI = banca6;


            this.underlyingList = underlyingList;
            underlyingList.Properties.Sorted = true;


            //underlyingList.Properties.Items.Clear();
            //underlyingList.Properties.Items.Add(banca1GUI);
            //underlyingList.Properties.Items.Add(banca2GUI);
            //underlyingList.Properties.Items.Add(banca3GUI);
            //underlyingList.Properties.Items.Add("Cassa");
            //underlyingList.Properties.Items.Add("Accantonamento");
            //underlyingList.Properties.Items.Add("Contropartita");


            underlyingList.Properties.Items.Add("(Seleziona una contropartita)");
            underlyingList.Properties.Items.Add(banca1GUI);
            underlyingList.Properties.Items.Add(banca2GUI);
            underlyingList.Properties.Items.Add(banca3GUI);
            underlyingList.Properties.Items.Add(banca4GUI);
            underlyingList.Properties.Items.Add(banca5GUI);
            underlyingList.Properties.Items.Add(banca6GUI);
            underlyingList.Properties.Items.Add("Cassa");
            underlyingList.Properties.Items.Add("Altre contropartite");
            //underlyingList.Properties.Items.Add(AbstractBilancio.AREA_BILANCIO_ATTIVITA);
            //underlyingList.Properties.Items.Add(AbstractBilancio.AREA_BILANCIO_PASSIVITA);
            //underlyingList.Properties.Items.Add(AbstractBilancio.AREA_BILANCIO_ENTRATE);
            //underlyingList.Properties.Items.Add(AbstractBilancio.AREA_BILANCIO_SPESE);


           // underlyingList.Text = banca1GUI;
        }

        public void Add(string dto)
        {
            underlyingList.Properties.Items.Add(dto);
        }

        public void Clear()
        {
            underlyingList.Properties.Items.Clear();
        }

        

        public string  SelectedItem
        {
            get
            {

                //if (underlyingList.Text == banca1GUI)
                //    return banca1;

                //if (underlyingList.Text == banca2GUI)
                //    return banca2;

                //if (underlyingList.Text == banca3GUI)
                //    return banca3;


                return underlyingList.Text;
            }
            set
            {
                //if (value == banca1)
                //{
                //    underlyingList.Text = banca1GUI;
                //    return;
                //}

                //if (value == banca2)
                //{
                //    underlyingList.Text = banca2GUI;
                //    return;
                //}

                //if (value == banca3)
                //{
                //    underlyingList.Text = banca3GUI;
                //    return;
                //}

                underlyingList.Text = value;
            }
        }




        #region ILookupList Membri di


        public void SelectAt(int index)
        {
            underlyingList.SelectedIndex = index;
        }

        #endregion

        #region ILookupList Membri di


        public bool Enabled
        {
            set { underlyingList.Enabled = value; }
        }

        #endregion


        public string Text
        {
            get { return underlyingList.Text; }
        }
    }
}

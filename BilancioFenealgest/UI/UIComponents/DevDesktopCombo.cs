using System;
using System.Collections.Generic;
using System.Text;
using BilancioFenealgest.Middleware;

namespace BilancioFenealgest.UI.UIComponents
{
    public class DevDesktopCombo: ILookupList
    {
        private DevExpress.XtraEditors.ComboBoxEdit  underlyingList;

        public DevDesktopCombo(DevExpress.XtraEditors.ComboBoxEdit underlyingList)
        {
            this.underlyingList = underlyingList;
            underlyingList.Properties.Sorted = true;
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
                return underlyingList.Text;
            }
            set
            {
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
            get {return  underlyingList.Text; }
        }
    }
}

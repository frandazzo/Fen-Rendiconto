using System;
using System.Collections.Generic;
using System.Text;
using BilancioFenealgest.Middleware;
using System.Windows.Forms;

namespace BilancioFenealgest.UI.UIComponents
{
    public class DesktopCombo: ILookupList
    {
        private ComboBox  underlyingList;

        public DesktopCombo(ComboBox underlyingList)
        {
            this.underlyingList = underlyingList;
            underlyingList.Sorted = true;
        }

        public void Add(string dto)
        {
            underlyingList.Items.Add(dto);
        }

        public void Clear()
        {
            underlyingList.Items.Clear();
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
            get { return underlyingList.Text; }
        }
    }
}
